// methods5.cs — solution

(int Min, int Max, double Average) Stats(int[] numbers)
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

var (lo, hi, avg) = Stats(new[] { 3, 1, 2 });
Check.Equal(1, lo);
Check.Equal(3, hi);
Check.Close(2.0, avg);
