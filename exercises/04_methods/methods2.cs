// methods2.cs
//
// When a method's body is a single expression, you can use the short
// "expression-bodied" form with => :
//
//     int Double(int x) => x * 2;
//
// Every possible path through a non-void method must `return` a value of the
// right type — the compiler checks this for you.

// I AM NOT DONE

bool IsEven(int n) => ???;

string Describe(int n)
{
    if (IsEven(n))
    {
        "even";
    }
    else
    {
        "odd";
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
    // what about all the other values?
}

Check.True(IsEven(4));
Check.False(IsEven(7));
Check.Equal("even", Describe(10));
Check.Equal("odd", Describe(3));
Check.Equal(0, Clamp(-5, 0, 10));
Check.Equal(10, Clamp(50, 0, 10));
Check.Equal(7, Clamp(7, 0, 10));
