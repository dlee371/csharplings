// if1.cs
//
// if / else lets your program make decisions:
//
//     if (temperature > 30)
//     {
//         Console.WriteLine("Hot!");
//     }
//     else if (temperature > 15)
//     {
//         Console.WriteLine("Nice.");
//     }
//     else
//     {
//         Console.WriteLine("Brr.");
//     }
//
// Comparison operators: ==  !=  <  >  <=  >=     (== compares, = assigns!)
//
// Below is a *local function*: a named, reusable piece of code. You'll learn all
// about functions (C# calls them "methods") soon. For now: `a` and `b` are the
// inputs, the `int` before the name is the type of the result, and `return`
// hands the result back to whoever called the function.
//
// Complete BiggerOf so it returns whichever number is larger.



int BiggerOf(int a, int b)
{
    if(a > b)
    {
        return a;
    }
    else
    {
        return b;
    }
    // Write your if/else here, and `return` the bigger number.
}

Check.Equal(10, BiggerOf(10, 8));
Check.Equal(42, BiggerOf(32, 42));
Check.Equal(7, BiggerOf(7, 7));
Check.Equal(-1, BiggerOf(-1, -9));
