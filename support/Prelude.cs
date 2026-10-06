// ─────────────────────────────────────────────────────────────────────────────
//  This file is automatically compiled together with every exercise.
//  It provides the `Check` helpers the exercises use to test your code.
//  You don't need to edit it — but feel free to read it once you've reached
//  the classes, generics and exceptions sections!
// ─────────────────────────────────────────────────────────────────────────────
using System.Collections;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;

public sealed class CheckFailedException(string message) : Exception(message);

public static class Check
{
    /// <summary>Checks that two values are equal. Collections are compared element by element.</summary>
    public static void Equal<T>(T expected, T actual,
        [CallerArgumentExpression(nameof(actual))] string expression = "",
        [CallerLineNumber] int line = 0)
    {
        if (AreEqual(expected, actual)) return;
        Fail(line, expression, $"expected: {Show(expected)}\n   actual:   {Show(actual)}");
    }

    /// <summary>Checks that two sequences (arrays, lists, LINQ results...) contain the same items in the same order.</summary>
    public static void Equal<T>(IEnumerable<T> expected, IEnumerable<T> actual,
        [CallerArgumentExpression(nameof(actual))] string expression = "",
        [CallerLineNumber] int line = 0)
    {
        if (AreEqual(expected, actual)) return;
        Fail(line, expression, $"expected: {Show(expected)}\n   actual:   {Show(actual)}");
    }

    /// <summary>Checks that two decimal numbers are (almost) equal.</summary>
    public static void Close(double expected, double actual, double tolerance = 0.0001,
        [CallerArgumentExpression(nameof(actual))] string expression = "",
        [CallerLineNumber] int line = 0)
    {
        if (Math.Abs(expected - actual) <= tolerance) return;
        Fail(line, expression, $"expected: {Show(expected)} (± {Show(tolerance)})\n   actual:   {Show(actual)}");
    }

    public static void True(bool condition,
        [CallerArgumentExpression(nameof(condition))] string expression = "",
        [CallerLineNumber] int line = 0)
    {
        if (!condition) Fail(line, expression, "expected this to be true, but it was false");
    }

    public static void False(bool condition,
        [CallerArgumentExpression(nameof(condition))] string expression = "",
        [CallerLineNumber] int line = 0)
    {
        if (condition) Fail(line, expression, "expected this to be false, but it was true");
    }

    /// <summary>Checks that running <paramref name="action"/> throws an exception of type <typeparamref name="TException"/>.</summary>
    public static TException Throws<TException>(Action action,
        [CallerArgumentExpression(nameof(action))] string expression = "",
        [CallerLineNumber] int line = 0) where TException : Exception
    {
        try
        {
            action();
        }
        catch (TException ex)
        {
            return ex;
        }
        catch (Exception ex)
        {
            Fail(line, expression, $"expected a {typeof(TException).Name}, but got a {ex.GetType().Name}: {ex.Message}");
        }
        Fail(line, expression, $"expected a {typeof(TException).Name} to be thrown, but nothing was thrown");
        return null!;
    }

    public static async Task<TException> ThrowsAsync<TException>(Func<Task> action,
        [CallerArgumentExpression(nameof(action))] string expression = "",
        [CallerLineNumber] int line = 0) where TException : Exception
    {
        try
        {
            await action();
        }
        catch (TException ex)
        {
            return ex;
        }
        catch (Exception ex)
        {
            Fail(line, expression, $"expected a {typeof(TException).Name}, but got a {ex.GetType().Name}: {ex.Message}");
        }
        Fail(line, expression, $"expected a {typeof(TException).Name} to be thrown, but nothing was thrown");
        return null!;
    }

    static bool AreEqual(object? expected, object? actual)
    {
        if (expected is IEnumerable e && actual is IEnumerable a && expected is not string && actual is not string)
        {
            var left = e.Cast<object?>().ToList();
            var right = a.Cast<object?>().ToList();
            return left.Count == right.Count && left.Zip(right).All(p => AreEqual(p.First, p.Second));
        }
        return Equals(expected, actual);
    }

    static string Show(object? value) => value switch
    {
        null => "null",
        string s => $"\"{s}\"",
        char c => $"'{c}'",
        bool b => b ? "true" : "false",
        double d => d.ToString("R", CultureInfo.InvariantCulture),
        float f => f.ToString("R", CultureInfo.InvariantCulture),
        decimal m => m.ToString(CultureInfo.InvariantCulture) + "m",
        IDictionary dict => "{ " + string.Join(", ", dict.Keys.Cast<object?>().Select(k => $"{Show(k)}: {Show(dict[k!])}")) + " }",
        IEnumerable seq => "[" + string.Join(", ", seq.Cast<object?>().Select(Show)) + "]",
        IFormattable fmt => fmt.ToString(null, CultureInfo.InvariantCulture),
        _ => value.ToString() ?? "null",
    };

    [DoesNotReturn]
    static void Fail(int line, string expression, string details) =>
        throw new CheckFailedException($"✗ Check failed on line {line}: {expression}\n   {details}");
}

static class CsharplingsBootstrap
{
    [ModuleInitializer]
    internal static void Init()
    {
        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

        // Print a friendly message instead of a giant stack trace when something goes wrong.
        AppDomain.CurrentDomain.UnhandledException += (_, e) =>
        {
            var ex = (Exception)e.ExceptionObject;
            while (ex is AggregateException { InnerException: { } inner }) ex = inner;
            Console.Out.Flush();
            if (ex is CheckFailedException)
            {
                Console.Error.WriteLine(ex.Message);
            }
            else
            {
                var frame = new StackTrace(ex, fNeedFileInfo: true).GetFrames()
                    .FirstOrDefault(f => f.GetFileName() is { } file && !file.EndsWith("Prelude.cs"));
                var where = frame is null ? "" : $" (thrown on line {frame.GetFileLineNumber()})";
                Console.Error.WriteLine($"💥 Unhandled {ex.GetType().Name}{where}: {ex.Message}");
            }
            Console.Error.Flush();
            Environment.Exit(1);
        };
    }
}
