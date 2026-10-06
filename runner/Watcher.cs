using System.Collections.Concurrent;

namespace Csharplings;

/// <summary>Shows the first unfinished exercise and re-checks it whenever a file is saved.</summary>
public sealed class Watcher(Course course)
{
    enum Signal { FileChanged, Hint, List, Rerun, Quit }

    readonly BlockingCollection<Signal> _signals = new();

    public int Run()
    {
        using var fsw = new FileSystemWatcher(Path.Combine(course.Root, "exercises"), "*.cs")
        {
            IncludeSubdirectories = true,
            NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.Size,
        };
        // Editors save files in different ways (write in place, or write a temp file and rename).
        fsw.Changed += (_, _) => _signals.Add(Signal.FileChanged);
        fsw.Created += (_, _) => _signals.Add(Signal.FileChanged);
        fsw.Renamed += (_, _) => _signals.Add(Signal.FileChanged);
        fsw.EnableRaisingEvents = true;

        if (!Console.IsInputRedirected)
            new Thread(ReadKeys) { IsBackground = true }.Start();

        Exercise? previous = null;
        while (true)
        {
            Ui.Clear();
            Console.WriteLine(Ui.Dim("Checking your progress..."));
            var (current, result) = FindCurrent();
            if (current is null)
            {
                Celebrate();
                return 0;
            }

            var finishedMessage = previous != null && previous != current
                ? Ui.Green($"🎉 Finished {previous.Name}! On to the next one.\n\n")
                : "";
            previous = current;
            var showHint = false;

            void Render()
            {
                Ui.Clear();
                Console.Write(finishedMessage);
                Ui.ProgressBar(course.CountDone(), course.Exercises.Count);
                Console.WriteLine();
                Ui.Result(current, result!, course.Root);
                if (showHint) Ui.Hint(current);
                Console.WriteLine();
                Console.WriteLine(Ui.Dim("Edit the file and save it — I'll re-check automatically."));
                Console.WriteLine(Ui.Dim($"[{Ui.Bold("h")}]int  [{Ui.Bold("l")}]ist  [{Ui.Bold("r")}]erun  [{Ui.Bold("q")}]uit"));
            }

            Render();

            var rerun = false;
            while (!rerun)
            {
                switch (_signals.Take())
                {
                    case Signal.FileChanged:
                        Debounce();
                        rerun = true;
                        break;
                    case Signal.Rerun:
                        rerun = true;
                        break;
                    case Signal.Hint:
                        showHint = !showHint;
                        Render();
                        break;
                    case Signal.List:
                        Ui.Clear();
                        course.PrintList();
                        Console.WriteLine(Ui.Dim("\nPress any key to go back..."));
                        _signals.Take();
                        Render();
                        break;
                    case Signal.Quit:
                        Console.WriteLine("See you next time! 👋");
                        return 0;
                }
            }
        }
    }

    (Exercise?, RunResult?) FindCurrent()
    {
        foreach (var ex in course.Exercises)
        {
            var (done, result) = course.Evaluate(ex);
            if (!done) return (ex, result);
        }
        return (null, null);
    }

    void Debounce()
    {
        // One save often fires several events; wait for things to settle.
        while (_signals.TryTake(out var next, TimeSpan.FromMilliseconds(150)))
        {
            if (next != Signal.FileChanged)
            {
                _signals.Add(next);
                break;
            }
        }
    }

    void ReadKeys()
    {
        while (true)
        {
            var key = Console.ReadKey(intercept: true);
            _signals.Add(char.ToLowerInvariant(key.KeyChar) switch
            {
                'h' => Signal.Hint,
                'l' => Signal.List,
                'q' => Signal.Quit,
                _ => Signal.Rerun,
            });
        }
    }

    void Celebrate()
    {
        Ui.Clear();
        Ui.ProgressBar(course.Exercises.Count, course.Exercises.Count);
        Console.WriteLine(Ui.Green("""

            ╔══════════════════════════════════════════════════════╗
            ║   🏆  You finished every Csharplings exercise!  🏆    ║
            ╚══════════════════════════════════════════════════════╝
            """));
        Console.WriteLine("""
            You can now read and write real C#. Ideas for what to do next:

              • Build a console app from scratch:   dotnet new console -o MyApp
              • Write unit tests with xUnit:         dotnet new xunit -o MyApp.Tests
              • Build a web API with ASP.NET Core:   dotnet new webapi -o MyApi
              • Talk to a database with Entity Framework Core.

            Check the README for a fuller list. Good luck with the job hunt!
            """);
    }
}
