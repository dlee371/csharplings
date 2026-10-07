// variables1.cs
//
// Variables store values. In C#, every variable has a *type*, and it never changes.
// You declare a variable by writing its type, a name, and (usually) a starting value:
//
//     int age = 36;
//     string name = "Ada";
//
// Or let the compiler figure out the type from the value with `var`:
//
//     var age = 36;   // still an int! `var` doesn't mean "any type".
//
// About the `Check.Equal(expected, actual)` line at the bottom: these are the
// tests for each exercise. If a check fails, the runner tells you why.
// Don't change the checks — change the code above them!
//
// (`$"x has the value {x}"` puts the value of x inside the text. More on that soon.)
//
// Fix the code so that `x` is declared.



var x = 5;

Console.WriteLine($"x has the value {x}");
Check.Equal(5, x);
