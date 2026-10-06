// methods4.cs — solution

void Swap(ref int a, ref int b)
{
    int temp = a;
    a = b;
    b = temp;
}

bool TryDivide(int dividend, int divisor, out int quotient)
{
    if (divisor == 0)
    {
        quotient = 0;
        return false;
    }
    quotient = dividend / divisor;
    return true;
}

int x = 1, y = 2;
Swap(ref x, ref y);
Check.Equal(2, x);
Check.Equal(1, y);

Check.True(TryDivide(10, 3, out int q));
Check.Equal(3, q);
Check.False(TryDivide(5, 0, out int q2));
Check.Equal(0, q2);

int ParseOrZero(string text)
{
    if (int.TryParse(text, out int value))
    {
        return value;
    }
    return 0;
}
Check.Equal(123, ParseOrZero("123"));
Check.Equal(0, ParseOrZero("one two three"));
