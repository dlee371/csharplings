// lambdas2.cs — solution

List<T> MyWhere<T>(List<T> items, Func<T, bool> keep)
{
    var result = new List<T>();
    foreach (T item in items)
    {
        if (keep(item))
        {
            result.Add(item);
        }
    }
    return result;
}

List<TOut> MySelect<TIn, TOut>(List<TIn> items, Func<TIn, TOut> transform)
{
    var result = new List<TOut>();
    foreach (TIn item in items)
    {
        result.Add(transform(item));
    }
    return result;
}

List<int> numbers = [1, 2, 3, 4, 5, 6];
Check.Equal(new List<int> { 2, 4, 6 }, MyWhere(numbers, n => n % 2 == 0));
Check.Equal(new List<int> { 5, 6 }, MyWhere(numbers, n => n > 4));
Check.Equal(new List<string> { "1!", "2!", "3!", "4!", "5!", "6!" }, MySelect(numbers, n => $"{n}!"));

Func<int, int> MakeMultiplier(int factor) => x => x * factor;

var triple = MakeMultiplier(3);
Check.Equal(21, triple(7));
Check.Equal(10, MakeMultiplier(2)(5));

int lastId = 0;
Func<int> nextId = () => ++lastId;   // ++x increments first, then gives the new value
Check.Equal(1, nextId());
Check.Equal(2, nextId());
Check.Equal(3, nextId());
