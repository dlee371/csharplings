// patterns1.cs — solution

string Describe(object? value)
{
    if (value is null)
    {
        return "nothing";
    }
    if (value is int n)
    {
        return $"int: {n * 2}";
    }
    if (value is string s)
    {
        return $"string of length {s.Length}";
    }
    if (value is List<int> list)
    {
        return $"list with {list.Count} items";
    }
    return "something else";
}

Check.Equal("nothing", Describe(null));
Check.Equal("int: 42", Describe(21));
Check.Equal("string of length 5", Describe("hello"));
Check.Equal("list with 3 items", Describe(new List<int> { 1, 2, 3 }));
Check.Equal("something else", Describe(3.14));

bool IsValidPercentage(int n) => n is >= 0 and <= 100;
Check.True(IsValidPercentage(0));
Check.True(IsValidPercentage(100));
Check.False(IsValidPercentage(101));
Check.False(IsValidPercentage(-1));

bool IsVowel(char c) => c is 'a' or 'e' or 'i' or 'o' or 'u';
Check.True(IsVowel('e'));
Check.False(IsVowel('z'));
