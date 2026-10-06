// iterators1.cs — solution

IEnumerable<long> Fibonacci()
{
    long a = 0, b = 1;
    while (true)
    {
        yield return a;
        (a, b) = (b, a + b);   // tuple swap: both sides are evaluated before assigning
    }
}

Check.Equal(new long[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 }, Fibonacci().Take(10));
Check.Equal(4181L, Fibonacci().Skip(19).First());
Check.Equal(514229L, Fibonacci().First(n => n > 500_000));

IEnumerable<T> Filter<T>(IEnumerable<T> source, Func<T, bool> keep)
{
    foreach (T item in source)
    {
        if (keep(item))
        {
            yield return item;
        }
    }
}

Check.Equal(new[] { 2, 4 }, Filter(new[] { 1, 2, 3, 4, 5 }, n => n % 2 == 0));

int produced = 0;
IEnumerable<int> Naturals()
{
    for (int i = 0; ; i++)
    {
        produced++;
        yield return i;
    }
}

var firstThreeOdd = Filter(Naturals(), n => n % 2 == 1).Take(3).ToList();
Check.Equal(new List<int> { 1, 3, 5 }, firstThreeOdd);
Check.Equal(6, produced);
