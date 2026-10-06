// exceptions1.cs
//
// When something goes wrong at runtime, .NET *throws* an exception. If nothing
// *catches* it, the program crashes. You catch exceptions with try/catch:
//
//     try
//     {
//         int n = int.Parse(text);
//     }
//     catch (FormatException ex)        // only catches this type of exception (and subtypes)
//     {
//         Console.WriteLine($"Bad input: {ex.Message}");
//     }
//     catch (OverflowException)         // you can have several catch blocks
//     {
//         ...
//     }
//     finally                           // ALWAYS runs: after success, after a catch, even after a return
//     {
//         ...
//     }
//
// Only catch exceptions you actually know how to handle.
// (For parsing user input, TryParse is usually better — but often you'll be
//  calling code that only throws, so you need to know try/catch.)

// I AM NOT DONE

int ParseAgeOrDefault(string input)
{
    // Return the parsed number, or -1 if the text isn't a valid int.
    return int.Parse(input);
}

Check.Equal(36, ParseAgeOrDefault("36"));
Check.Equal(-1, ParseAgeOrDefault("thirty-six"));    // FormatException
Check.Equal(-1, ParseAgeOrDefault("99999999999"));   // too big for an int: OverflowException

string Divide(int a, int b, List<string> log)
{
    try
    {
        return (a / b).ToString();
    }
    catch (DivideByZeroException)
    {
        return "cannot divide by zero";
    }
    // TODO: add a `finally` that adds "done" to the log — whatever happens above.
}

var log = new List<string>();
Check.Equal("5", Divide(10, 2, log));
Check.Equal("cannot divide by zero", Divide(1, 0, log));
Check.Equal(new List<string> { "done", "done" }, log);
