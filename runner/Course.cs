namespace Csharplings;

public sealed class Course(string root, List<Exercise> exercises)
{
    public string Root { get; } = root;
    public List<Exercise> Exercises { get; } = exercises;
    public ExerciseRunner Runner { get; } = new(root);
    readonly ProgressCache _cache = new(root);

    string OriginalsDir => Path.Combine(Root, ".csharplings", "originals");

    public Exercise? Find(string name)
    {
        var ex = Exercises.FirstOrDefault(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (ex is null)
            Console.Error.WriteLine(Ui.Red($"No exercise called '{name}'. Use `dotnet run -- list` to see them all."));
        return ex;
    }

    /// <summary>Done = the marker is gone and the exercise passes. Only runs the exercise if we haven't seen these exact contents pass before.</summary>
    public (bool Done, RunResult? Result) Evaluate(Exercise ex)
    {
        var source = ex.ReadSource(Root);
        if (!Exercise.HasMarker(source) && _cache.IsKnownPass(ex, source))
            return (true, null);

        var result = Runner.Run(ex);
        var done = result.Passed && !Exercise.HasMarker(result.Source);
        if (done) _cache.RecordPass(ex, result.Source);
        return (done, result);
    }

    /// <summary>Done according to what we already know, without running anything.</summary>
    public bool IsDoneCached(Exercise ex)
    {
        var source = ex.ReadSource(Root);
        return !Exercise.HasMarker(source) && _cache.IsKnownPass(ex, source);
    }

    public int CountDone() => Exercises.Count(IsDoneCached);

    public void PrintList()
    {
        var current = Exercises.FirstOrDefault(e => !IsDoneCached(e));
        Console.WriteLine(Ui.Bold($"{"",2} {"Name",-16} {"Status",-10} Path"));
        foreach (var ex in Exercises)
        {
            var (icon, status) = IsDoneCached(ex) ? (Ui.Green("✓"), Ui.Green("Done     "))
                : ex == current ? (Ui.Yellow("▶"), Ui.Yellow("Current  "))
                : (Ui.Dim("·"), Ui.Dim("Pending  "));
            Console.WriteLine($"{icon,2} {ex.Name,-16} {status}  {Ui.Dim(ex.Path)}");
        }
        Console.WriteLine();
        Ui.ProgressBar(CountDone(), Exercises.Count);
    }

    public bool VerifyAll()
    {
        for (var i = 0; i < Exercises.Count; i++)
        {
            var ex = Exercises[i];
            Console.Write($"\r{Ui.Dim($"Checking {ex.Name}...")}            ");
            var result = Runner.Run(ex);
            if (!result.Passed || Exercise.HasMarker(result.Source))
            {
                Console.WriteLine();
                Ui.ProgressBar(i, Exercises.Count);
                Console.WriteLine();
                Ui.Result(ex, result, Root);
                return false;
            }
            _cache.RecordPass(ex, result.Source);
        }
        Console.WriteLine();
        Ui.ProgressBar(Exercises.Count, Exercises.Count);
        Console.WriteLine(Ui.Green("Every exercise passes. Amazing work! 🏆"));
        return true;
    }

    /// <summary>Keeps a pristine copy of every exercise so `reset` can restore it.</summary>
    public void SnapshotOriginals()
    {
        foreach (var ex in Exercises)
        {
            var copy = Path.Combine(OriginalsDir, ex.Path);
            if (File.Exists(copy) || !File.Exists(ex.FullPath(Root))) continue;
            Directory.CreateDirectory(Path.GetDirectoryName(copy)!);
            File.Copy(ex.FullPath(Root), copy);
        }
    }

    public void Reset(Exercise ex) => File.Copy(Path.Combine(OriginalsDir, ex.Path), ex.FullPath(Root), overwrite: true);

    /// <summary>Maintainer check: every exercise must fail (or still have its marker) as shipped, and every solution must pass.</summary>
    public bool CheckSolutions()
    {
        var ok = true;
        foreach (var ex in Exercises)
        {
            var exerciseSource = ex.ReadSource(Root);
            var exercise = Runner.Run(ex);
            var solutionPath = Path.Combine(Root, ex.Path.Replace("exercises", "solutions"));
            if (!File.Exists(solutionPath))
            {
                Console.WriteLine(Ui.Red($"✗ {ex.Name}: missing solution"));
                ok = false;
                continue;
            }
            var solutionSource = File.ReadAllText(solutionPath);
            var solution = Runner.Run(ex, solutionSource, solutionPath);

            var problems = new List<string>();
            if (!Exercise.HasMarker(exerciseSource)) problems.Add("exercise has no marker");
            if (exercise.Passed && ex.Name != "intro1") problems.Add("exercise already passes");
            if (!solution.Passed) problems.Add($"solution fails ({solution.Outcome})");
            if (solution.Diagnostics.Count > 0) problems.Add($"solution has diagnostics: {string.Join("; ", solution.Diagnostics.Select(d => d.Id + " " + d.GetMessage()))}");
            if (Exercise.HasMarker(solutionSource)) problems.Add("solution still has marker");

            if (problems.Count == 0)
                Console.WriteLine(Ui.Green($"✓ {ex.Name,-16}") + Ui.Dim($" exercise: {exercise.Outcome}"));
            else
            {
                ok = false;
                Console.WriteLine(Ui.Red($"✗ {ex.Name,-16} {string.Join(", ", problems)}"));
                if (!solution.Passed) Console.WriteLine(Ui.Dim(solution.Output + string.Join("\n", solution.Diagnostics)));
            }
        }
        return ok;
    }
}
