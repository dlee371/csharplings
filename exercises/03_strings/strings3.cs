// strings3.cs
//
// Because strings are immutable, gluing many pieces together with + inside a
// loop creates lots of throwaway strings. For that job, use a StringBuilder:
//
//     var sb = new StringBuilder();
//     sb.Append("Hello");
//     sb.Append(", world");
//     sb.AppendLine("!");          // also adds a newline
//     string result = sb.ToString();
//
// And to join a collection of strings with a separator in between:
//
//     string.Join(", ", names)     // "Ada, Grace, Linus"

// I AM NOT DONE

var sb = new StringBuilder();
for (int i = 1; i <= 5; i++)
{
    // Append i, then a "-" — but only if this isn't the last number!
    ???
}
string countdown = sb.ToString();

string[] fruits = { "apple", "banana", "cherry" };
string fruitList = ???;

Check.Equal("1-2-3-4-5", countdown);
Check.Equal("apple, banana, cherry", fruitList);
