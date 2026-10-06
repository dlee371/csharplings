// lambdas2.cs
//
// Methods that take functions as parameters (or return them) are called
// *higher-order functions*. They let the CALLER decide part of the behavior.
// This is exactly how LINQ — the next section — works.
//
// A lambda can use variables from the code around it. It "captures" them, and
// sees (and can change!) their current values. This is called a *closure*:
//
//     int count = 0;
//     Action increment = () => count++;
//     increment();
//     increment();      // count is now 2

// I AM NOT DONE

// 1. MyWhere: return a NEW list with only the items for which `keep` returns true.
List<T> MyWhere<T>(List<T> items, Func<T, bool> keep)
{
    ???
}

// 2. MySelect: return a NEW list containing `transform` applied to every item.
List<TOut> MySelect<TIn, TOut>(List<TIn> items, Func<TIn, TOut> transform)
{
    ???
}

List<int> numbers = [1, 2, 3, 4, 5, 6];
Check.Equal(new List<int> { 2, 4, 6 }, MyWhere(numbers, n => n % 2 == 0));
Check.Equal(new List<int> { 5, 6 }, MyWhere(numbers, n => n > 4));
Check.Equal(new List<string> { "1!", "2!", "3!", "4!", "5!", "6!" }, MySelect(numbers, n => $"{n}!"));

// 3. A function that RETURNS a function: MakeMultiplier(3) returns a function that triples things.
Func<int, int> MakeMultiplier(int factor) => ???;

var triple = MakeMultiplier(3);
Check.Equal(21, triple(7));
Check.Equal(10, MakeMultiplier(2)(5));

// 4. A closure: each call to nextId should return the next number: 1, then 2, then 3...
int lastId = 0;
Func<int> nextId = ???;
Check.Equal(1, nextId());
Check.Equal(2, nextId());
Check.Equal(3, nextId());
