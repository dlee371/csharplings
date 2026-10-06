// exceptions1.cs — solution

int ParseAgeOrDefault(string input)
{
    try
    {
        return int.Parse(input);
    }
    catch (FormatException)
    {
        return -1;
    }
    catch (OverflowException)
    {
        return -1;
    }
    // Or, in one block, with an exception filter:
    //     catch (Exception ex) when (ex is FormatException or OverflowException) { return -1; }
}

Check.Equal(36, ParseAgeOrDefault("36"));
Check.Equal(-1, ParseAgeOrDefault("thirty-six"));
Check.Equal(-1, ParseAgeOrDefault("99999999999"));

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
    finally
    {
        log.Add("done");
    }
}

var log = new List<string>();
Check.Equal("5", Divide(10, 2, log));
Check.Equal("cannot divide by zero", Divide(1, 0, log));
Check.Equal(new List<string> { "done", "done" }, log);
