// methods1.cs — solution

Greet("Grace");
Check.Equal(25, Square(5));
Check.Equal(10.0, Average(5, 15));

void Greet(string name)
{
    Console.WriteLine($"Hello, {name}!");
}

int Square(int n)
{
    return n * n;
}

double Average(double a, double b)
{
    return (a + b) / 2;
}
