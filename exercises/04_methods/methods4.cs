// methods4.cs
//
// Normally, arguments are passed *by value*: the method gets its own copy.
//
//     void AddOne(int x) { x++; }           // only changes the copy
//
// `ref` passes the variable itself, so the method can change it:
//
//     void AddOne(ref int x) { x++; }
//     AddOne(ref myNumber);                 // `ref` is required at the call site too
//
// `out` parameters are for extra results. The method MUST assign them. The
// "Try pattern" (return a bool for success, give the result through `out`) is
// everywhere in .NET:
//
//     if (int.TryParse("123", out int number))
//     {
//         // parsing worked, and `number` is 123
//     }

// I AM NOT DONE

void Swap(int a, int b)
{
    int temp = a;
    a = b;
    b = temp;
}

bool TryDivide(int dividend, int divisor, out int quotient)
{
    // If divisor is 0: set quotient to 0 and return false.
    // Otherwise: set quotient to the result and return true.
    ???
}

int x = 1, y = 2;
Swap(x, y);
Check.Equal(2, x);
Check.Equal(1, y);

Check.True(TryDivide(10, 3, out int q));
Check.Equal(3, q);
Check.False(TryDivide(5, 0, out int q2));
Check.Equal(0, q2);

// Use int.TryParse so bad input gives 0 instead of crashing.
int ParseOrZero(string text)
{
    return int.Parse(text);
}
Check.Equal(123, ParseOrZero("123"));
Check.Equal(0, ParseOrZero("one two three"));
