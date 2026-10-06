// methods1.cs
//
// Functions in C# are called *methods*. A method declaration looks like:
//
//     returnType Name(type parameter1, type parameter2)
//     {
//         return ...;
//     }
//
// Use `void` as the return type when a method doesn't return anything.
// Every parameter needs a type, and so does the return value.
//
// Fill in the missing types so this compiles.

// I AM NOT DONE

Greet("Grace");
Check.Equal(25, Square(5));
Check.Equal(10.0, Average(5, 15));

??? Greet(string name)
{
    Console.WriteLine($"Hello, {name}!");
}

int Square(??? n)
{
    return n * n;
}

??? Average(double a, double b)
{
    return (a + b) / 2;
}
