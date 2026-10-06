// iterators1.cs
//
// `yield return` lets a method produce a sequence ONE ITEM AT A TIME, only when
// someone asks for the next one. Such a method returns IEnumerable<T>:
//
//     IEnumerable<int> CountTo(int max)
//     {
//         for (int i = 1; i <= max; i++)
//         {
//             yield return i;     // hand out i, then pause right here until the next item is requested
//         }
//     }
//
// Because it's lazy, a sequence can even be infinite: the caller simply stops
// asking (for example with Take(10)). This is how LINQ's Where and Select are
// implemented under the hood.

// I AM NOT DONE

// 1. An infinite sequence of Fibonacci numbers: 0, 1, 1, 2, 3, 5, 8, 13, ...
//    (each number is the sum of the two before it)
IEnumerable<long> Fibonacci()
{
    ???
}

Check.Equal(new long[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 }, Fibonacci().Take(10));
Check.Equal(4181L, Fibonacci().Skip(19).First());
Check.Equal(514229L, Fibonacci().First(n => n > 500_000));

// 2. Your own lazy version of LINQ's Where, using yield return.
IEnumerable<T> Filter<T>(IEnumerable<T> source, Func<T, bool> keep)
{
    ???
}

Check.Equal(new[] { 2, 4 }, Filter(new[] { 1, 2, 3, 4, 5 }, n => n % 2 == 0));

// 3. Proof that it's lazy: Filter over an infinite sequence still finishes,
//    and only as many items as needed are ever produced.
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
