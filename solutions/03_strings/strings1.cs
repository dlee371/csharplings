// strings1.cs — solution

string name = "Ada";
int age = 36;
double height = 1.6549;

string greeting = $"Hello, {name}!";
string description = $"{name} is {age} years old and {height:F2}m tall.";
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
