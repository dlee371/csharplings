// lambdas1.cs
//
// In C#, functions are values too. A *lambda* is a small, unnamed, inline function:
//
//     x => x * 2                     one parameter
//     (a, b) => a + b                several parameters
//     () => Console.WriteLine("hi")  no parameters
//     x => { var y = x * 2; return y + 1; }    a block body
//
// You store lambdas in *delegate* types. The built-in ones cover almost everything:
//
//     Func<int, int>          takes an int, returns an int   (the LAST type is always the return type)
//     Func<int, int, bool>    takes two ints, returns a bool
//     Func<string>            takes nothing, returns a string
//     Action<string>          takes a string, returns nothing
//     Action                  takes nothing, returns nothing

// I AM NOT DONE

Func<int, int> square = ???;
Func<int, int, int> add = ???;
Func<string, bool> isLong = ???;    // true when the text has more than 5 characters
var messages = new List<string>();
Action<string> log = ???;           // adds the message to `messages`

Check.Equal(49, square(7));
Check.Equal(5, add(2, 3));
Check.True(isLong("elephant"));
Check.False(isLong("cat"));
log("hello");
log("world");
Check.Equal(new List<string> { "hello", "world" }, messages);

// Existing methods can be stored in delegates too — use the name without ():
Func<string, int> parse = int.Parse;
Check.Equal(42, parse("42"));

// What type does this need to be? (Hint: it takes two strings and returns a string.)
??? joinWithDash = (a, b) => $"{a}-{b}";
Check.Equal("left-right", joinWithDash("left", "right"));
