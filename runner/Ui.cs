using Microsoft.CodeAnalysis;

namespace Csharplings;

public static class Ui
{
    static readonly bool UseColor = Environment.GetEnvironmentVariable("NO_COLOR") is null && !Console.IsOutputRedirected;

    static string Paint(string code, string text) => UseColor ? $"\e[{code}m{text}\e[0m" : text;
    public static string Red(string s) => Paint("31", s);
    public static string Green(string s) => Paint("32", s);
    public static string Yellow(string s) => Paint("33", s);
    public static string Cyan(string s) => Paint("36", s);
    public static string Dim(string s) => Paint("2", s);
    public static string Bold(string s) => Paint("1", s);

    public static void Clear()
    {
        if (!Console.IsOutputRedirected) Console.Write("\e[2J\e[3J\e[H");
    }

    public static void ProgressBar(int done, int total)
    {
        const int width = 40;
        var filled = total == 0 ? 0 : done * width / total;
        var bar = new string('#', filled) + (filled < width ? ">" + new string('-', width - filled - 1) : "");
        Console.WriteLine($"Progress: [{Green(bar[..filled])}{bar[filled..]}] {done}/{total} ({(total == 0 ? 0 : done * 100 / total)}%)");
    }

    public static void Result(Exercise ex, RunResult result, string root)
    {
        Console.WriteLine(Bold($"━━━ {ex.Path} ━━━"));
        Console.WriteLine();

        if (result.Diagnostics.Count > 0)
            Diagnostics(result);

        if (result.Outcome != Outcome.CompileError && result.Output.Length > 0)
        {
            Console.WriteLine(Dim("── output ──"));
            Console.Write(result.Output);
            Console.WriteLine(Dim("────────────"));
            Console.WriteLine();
        }

        var marker = Exercise.HasMarker(result.Source);
        switch (result.Outcome)
        {
            case Outcome.CompileError:
                Console.WriteLine(Red($"✗ {ex.Name} doesn't compile yet. Read the errors above, then fix the code!"));
                break;
            case Outcome.Failed:
                Console.WriteLine(Red($"✗ {ex.Name} compiled, but its checks failed. Keep going, you're close!"));
                break;
            case Outcome.TimedOut:
                Console.WriteLine(Red($"✗ {ex.Name} took too long to run."));
                break;
            case Outcome.Passed when marker:
                Console.WriteLine(Green($"✓ {ex.Name} compiles and all checks pass! 🎉"));
                Console.WriteLine();
                Console.WriteLine($"  Take a moment to re-read the code and make sure you understand it.");
                Console.WriteLine($"  When you're ready, delete the {Yellow("// I AM NOT DONE")} line to move on.");
                break;
            case Outcome.Passed:
                Console.WriteLine(Green($"✓ {ex.Name} is done!"));
                break;
        }
    }

    static void Diagnostics(RunResult result)
    {
        var lines = result.Source.Split('\n');

        // `???` marks a blank for the learner to fill in. The parser errors it causes are just noise,
        // so point at the blanks directly and hide errors on those lines.
        var blankLines = lines
            .Select((text, index) => (text, index))
            .Where(l => l.text.Contains("???") && !l.text.TrimStart().StartsWith("//"))
            .Select(l => l.index)
            .ToHashSet();
        if (blankLines.Count > 0)
        {
            Console.WriteLine(Yellow("✏️  Replace each ??? with your own code:"));
            foreach (var i in blankLines)
                Console.WriteLine(Dim($"{i + 1,4} | ") + lines[i].TrimEnd('\r').Replace("???", Yellow("???")));
            Console.WriteLine();
        }

        var diagnostics = result.Diagnostics
            .Where(d => !d.Location.IsInSource || !blankLines.Contains(d.Location.GetLineSpan().StartLinePosition.Line))
            .ToList();
        if (blankLines.Count > 0)
        {
            // Blanks cause cascading errors elsewhere; show those only once the blanks are filled in.
            if (diagnostics.Count > 0)
                Console.WriteLine(Dim($"({diagnostics.Count} other compiler message(s) hidden until the blanks are filled in.)\n"));
            return;
        }

        foreach (var d in diagnostics.Take(6))
        {
            var isError = d.Severity == DiagnosticSeverity.Error;
            var label = isError ? Red($"error {d.Id}") : Yellow($"warning {d.Id}");
            if (!d.Location.IsInSource)
            {
                Console.WriteLine($"{label}: {d.GetMessage()}\n");
                continue;
            }
            var span = d.Location.GetLineSpan();
            var lineNo = span.StartLinePosition.Line;
            var col = span.StartLinePosition.Character;
            Console.WriteLine($"{label} {Dim($"(line {lineNo + 1}, column {col + 1})")}: {Bold(d.GetMessage())}");
            if (lineNo < lines.Length)
            {
                var code = lines[lineNo].TrimEnd('\r');
                var gutter = $"{lineNo + 1,4} | ";
                Console.WriteLine(Dim(gutter) + code);
                var length = span.EndLinePosition.Line == lineNo
                    ? Math.Max(1, span.EndLinePosition.Character - col)
                    : Math.Max(1, code.Length - col);
                var pad = new string(' ', gutter.Length) +
                          new string(code[..Math.Min(col, code.Length)].Select(c => c == '\t' ? '\t' : ' ').ToArray());
                Console.WriteLine(pad + (isError ? Red(new string('^', length)) : Yellow(new string('^', length))));
            }
            Console.WriteLine();
        }
        if (diagnostics.Count > 6)
            Console.WriteLine(Dim($"…and {diagnostics.Count - 6} more. Fix the first ones first — later errors are often caused by earlier ones.\n"));
    }

    public static void Hint(Exercise ex)
    {
        Console.WriteLine();
        Console.WriteLine(Cyan(Bold("💡 Hint:")));
        foreach (var line in ex.Hint.Split('\n'))
            Console.WriteLine(Cyan("   " + line));
    }
}
