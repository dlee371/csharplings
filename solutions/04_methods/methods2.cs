// methods2.cs — solution

bool IsEven(int n) => n % 2 == 0;

string Describe(int n)
{
    if (IsEven(n))
    {
        return "even";
    }
    else
    {
        return "odd";
    }
}

int Clamp(int value, int min, int max)
{
    if (value < min)
    {
        return min;
    }
    if (value > max)
    {
        return max;
    }
    return value;
}

Check.True(IsEven(4));
Check.False(IsEven(7));
Check.Equal("even", Describe(10));
Check.Equal("odd", Describe(3));
Check.Equal(0, Clamp(-5, 0, 10));
Check.Equal(10, Clamp(50, 0, 10));
Check.Equal(7, Clamp(7, 0, 10));
