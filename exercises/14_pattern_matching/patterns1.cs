// patterns1.cs
//
// Pattern matching tests the "shape" of a value and pulls data out of it, in one step.
//
//     object thing = 42;               // every type in C# derives from `object`
//
//     if (thing is int number)         // type pattern: is it an int? if so, name it `number`
//     {
//         Console.WriteLine(number + 1);
//     }
//
//     if (thing is null) ...           // null check (preferred over == null)
//     if (thing is not string) ...     // `not` pattern
//     if (n is > 0 and < 10) ...       // relational patterns, combined with `and` / `or`
//     if (c is 'a' or 'e' or 'i') ...

// I AM NOT DONE

string Describe(object? value)
{
    if (value is null)
    {
        return "nothing";
    }
    // TODO: if value is an int, return "int: <value doubled>"        e.g. 21 → "int: 42"
    // TODO: if value is a string, return "string of length <length>"
    // TODO: if value is a List<int>, return "list with <count> items"
    return "something else";
}

Check.Equal("nothing", Describe(null));
Check.Equal("int: 42", Describe(21));
Check.Equal("string of length 5", Describe("hello"));
Check.Equal("list with 3 items", Describe(new List<int> { 1, 2, 3 }));
Check.Equal("something else", Describe(3.14));

bool IsValidPercentage(int n) => ???;   // use `is`, relational patterns and `and`
Check.True(IsValidPercentage(0));
Check.True(IsValidPercentage(100));
Check.False(IsValidPercentage(101));
Check.False(IsValidPercentage(-1));

bool IsVowel(char c) => ???;            // use `is` and `or`
Check.True(IsVowel('e'));
Check.False(IsVowel('z'));
