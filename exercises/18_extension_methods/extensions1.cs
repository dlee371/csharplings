// extensions1.cs
//
// Extension methods let you "add" methods to existing types — even ones you
// don't own, like string or int. They're static methods in a static class, with
// `this` in front of the first parameter:
//
//     static class StringExtensions
//     {
//         public static bool IsBlank(this string s) => s.Trim().Length == 0;
//     }
//
//     "   ".IsBlank()      // true — called as if it were a real method on string!
//
// All of LINQ is extension methods on IEnumerable<T>. That's why .Where() and
// .Select() show up on every collection.
//
// (C# 14 also added a newer `extension` block syntax. You'll see the classic
//  form above far more often in existing code, so learn that one first.)

// I AM NOT DONE

Check.True("racecar".IsPalindrome());
Check.True("Never odd or even".IsPalindrome());    // ignore upper/lower case and spaces
Check.False("csharp".IsPalindrome());

Check.Equal("Hello...", "Hello, world".Truncate(5));   // cut to max length, then add "..."
Check.Equal("Hi", "Hi".Truncate(5));                   // short enough: unchanged

Check.True(14.IsBetween(10, 20));
Check.True(10.IsBetween(10, 20));
Check.False(25.IsBetween(10, 20));

Check.Equal(new[] { "a", "c", "e" }, new[] { "a", "b", "c", "d", "e" }.EveryOther());
Check.Equal(new[] { 1, 3 }, new List<int> { 1, 2, 3, 4 }.EveryOther());

static class Extensions
{
    // TODO: IsPalindrome(this string ...)
    // TODO: Truncate(this string ..., int maxLength)
    // TODO: IsBetween(this int ..., int min, int max)   (inclusive)
    // TODO: EveryOther<T>(this IEnumerable<T> ...)      (items at index 0, 2, 4, ...)
}
