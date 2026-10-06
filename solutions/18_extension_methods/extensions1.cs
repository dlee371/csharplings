// extensions1.cs — solution

Check.True("racecar".IsPalindrome());
Check.True("Never odd or even".IsPalindrome());
Check.False("csharp".IsPalindrome());

Check.Equal("Hello...", "Hello, world".Truncate(5));
Check.Equal("Hi", "Hi".Truncate(5));

Check.True(14.IsBetween(10, 20));
Check.True(10.IsBetween(10, 20));
Check.False(25.IsBetween(10, 20));

Check.Equal(new[] { "a", "c", "e" }, new[] { "a", "b", "c", "d", "e" }.EveryOther());
Check.Equal(new[] { 1, 3 }, new List<int> { 1, 2, 3, 4 }.EveryOther());

static class Extensions
{
    public static bool IsPalindrome(this string text)
    {
        string cleaned = text.Replace(" ", "").ToLower();
        string reversed = new string(cleaned.Reverse().ToArray());
        return cleaned == reversed;
    }

    public static string Truncate(this string text, int maxLength) =>
        text.Length <= maxLength ? text : text[..maxLength] + "...";

    public static bool IsBetween(this int value, int min, int max) => value >= min && value <= max;

    public static IEnumerable<T> EveryOther<T>(this IEnumerable<T> source) =>
        source.Where((item, index) => index % 2 == 0);
}
