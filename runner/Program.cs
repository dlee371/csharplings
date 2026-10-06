using Csharplings;

var root = FindRoot();
if (root is null)
{
    Console.Error.WriteLine("Couldn't find info.json. Run csharplings from the folder that contains it.");
    return 1;
}

var exercises = ExerciseList.Load(root);
var course = new Course(root, exercises);
course.SnapshotOriginals();

var command = args.Length > 0 ? args[0] : "watch";
var name = args.Length > 1 ? args[1] : null;

switch (command)
{
    case "watch":
        return new Watcher(course).Run();

    case "list":
        course.PrintList();
        return 0;

    case "run" or "hint" or "reset" or "solution" when name is null:
        Console.Error.WriteLine($"Usage: dotnet run -- {command} <exercise name>   (e.g. dotnet run -- {command} variables1)");
        return 1;

    case "run":
    {
        if (course.Find(name!) is not { } ex) return 1;
        var result = course.Runner.Run(ex);
        Ui.Result(ex, result, root);
        return result.Passed ? 0 : 1;
    }

    case "hint":
    {
        if (course.Find(name!) is not { } ex) return 1;
        Ui.Hint(ex);
        return 0;
    }

    case "reset":
    {
        if (course.Find(name!) is not { } ex) return 1;
        course.Reset(ex);
        Console.WriteLine(Ui.Green($"Reset {ex.Path} back to its original contents."));
        return 0;
    }

    case "solution":
    {
        if (course.Find(name!) is not { } ex) return 1;
        var path = Path.Combine(root, ex.Path.Replace("exercises", "solutions"));
        Console.WriteLine(Ui.Dim($"// {Path.GetRelativePath(root, path)}"));
        Console.WriteLine(File.ReadAllText(path));
        return 0;
    }

    case "verify":
        return course.VerifyAll() ? 0 : 1;

    case "check-solutions": // for course maintainers
        return course.CheckSolutions() ? 0 : 1;

    default:
        Console.WriteLine("""
            Csharplings — small exercises to get you reading and writing C#.

            Usage:  dotnet run [-- <command>]

            Commands:
              (none)            Watch mode: shows the current exercise and re-checks it every time you save.
              list              Show all exercises and your progress.
              run <name>        Run a single exercise.
              hint <name>       Show the hint for an exercise.
              solution <name>   Show a reference solution (try hard first!).
              reset <name>      Restore an exercise to how it started.
              verify            Re-check every exercise from scratch, in order.
            """);
        return command is "help" or "--help" or "-h" ? 0 : 1;
}

static string? FindRoot()
{
    foreach (var start in new[] { Directory.GetCurrentDirectory(), AppContext.BaseDirectory })
    {
        for (var dir = new DirectoryInfo(start); dir != null; dir = dir.Parent)
            if (File.Exists(Path.Combine(dir.FullName, "info.json")))
                return dir.FullName;
    }
    return null;
}
