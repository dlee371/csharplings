// methods5.cs
//
// Need to return more than one value? Use a *tuple*:
//
//     (int Min, int Max) Range(int[] numbers)
//     {
//         ...
//         return (smallest, largest);
//     }
//
//     var r = Range(data);
//     Console.WriteLine(r.Min);           // use the element names
//
//     var (lo, hi) = Range(data);         // or "deconstruct" into separate variables
//
// (A cast like `(double)sum` turns an int into a double, so the division keeps its decimals.)

// I AM NOT DONE

??? Stats(int[] numbers)
{
    int min = numbers[0];
    int max = numbers[0];
    int sum = 0;
    foreach (int n in numbers)
    {
        if (n < min) min = n;
        if (n > max) max = n;
        sum += n;
    }
    return (min, max, (double)sum / numbers.Length);
}

int[] data = { 4, 8, 15, 16, 23, 42 };

var stats = Stats(data);
Check.Equal(4, stats.Min);
Check.Equal(42, stats.Max);
Check.Close(18.0, stats.Average);

// Deconstruct the result straight into three variables named lo, hi and avg:
??? = Stats(new[] { 3, 1, 2 });
Check.Equal(1, lo);
Check.Equal(3, hi);
Check.Close(2.0, avg);
