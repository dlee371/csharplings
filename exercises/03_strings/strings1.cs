// strings1.cs
//
// Building strings:
//
//     string name = "Ada";
//     string a = "Hello, " + name + "!";     // concatenation with +
//     string b = $"Hello, {name}!";          // interpolation: $ before the quote,
//                                            // then any expression inside { }
//     string c = $"Total: {price:F2}";       // format specifier: F2 = 2 decimal places
//     string d = $"Next year: {age + 1}";    // expressions work too
//
// Special characters use a backslash ("escape sequences"):
//     \n  new line     \t  tab     \"  a double quote     \\  a backslash
//
// Replace each ??? so the checks pass. Use interpolation!


string name = "Ada";
int age = 36;
double height = 1.6549;

string greeting = $"Hello, {name}!";
string description = $"Ada is {age} years old and {height:F2}m tall.";
string nextYear = $"Next year {name} will be {age + 1}.";
string quote = $"{name} said \"hi\"";

Console.WriteLine(greeting);
Console.WriteLine(description);
Console.WriteLine(nextYear);
Console.WriteLine(quote);

Check.Equal("Hello, Ada!", greeting);
Check.Equal("Ada is 36 years old and 1.65m tall.", description);
Check.Equal("Next year Ada will be 37.", nextYear);
Check.Equal("Ada said \"hi\"", quote);
