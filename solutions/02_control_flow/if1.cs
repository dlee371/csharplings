// if1.cs — solution

int BiggerOf(int a, int b)
{
    if (a > b)
    {
        return a;
    }
    else
    {
        return b;
    }
    // Shorter alternatives you'll learn later:
    //     return a > b ? a : b;
    //     return Math.Max(a, b);
}

Check.Equal(10, BiggerOf(10, 8));
Check.Equal(42, BiggerOf(32, 42));
Check.Equal(7, BiggerOf(7, 7));
Check.Equal(-1, BiggerOf(-1, -9));
