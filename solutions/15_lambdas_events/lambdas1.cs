// lambdas1.cs — solution

Func<int, int> square = x => x * x;
Func<int, int, int> add = (a, b) => a + b;
Func<string, bool> isLong = s => s.Length > 5;
var messages = new List<string>();
Action<string> log = message => messages.Add(message);

Check.Equal(49, square(7));
Check.Equal(5, add(2, 3));
Check.True(isLong("elephant"));
Check.False(isLong("cat"));
log("hello");
log("world");
Check.Equal(new List<string> { "hello", "world" }, messages);

Func<string, int> parse = int.Parse;
Check.Equal(42, parse("42"));

Func<string, string, string> joinWithDash = (a, b) => $"{a}-{b}";
Check.Equal("left-right", joinWithDash("left", "right"));
