// generics3.cs
//
// Inside generic code, the compiler only knows that T is *some* type, so you can
// barely do anything with it. *Constraints* narrow down what T can be — and in
// return, let you use the features of those types:
//
//     where T : IComparable<T>    T can be compared  → you can call CompareTo
//     where T : SomeInterface     T implements it    → you can use its members
//     where T : class             T is a reference type (so it can be null)
//     where T : struct            T is a value type
//     where T : new()             T has a parameterless constructor → new T()
//
//     T Largest<T>(List<T> items) where T : IComparable<T> { ... }
//
// Combine several with commas: where T : class, IEntity

// I AM NOT DONE

T Largest<T>(List<T> items)
{
    T best = items[0];
    foreach (T item in items)
    {
        if (item.CompareTo(best) > 0)   // ❌ the compiler doesn't know that T has CompareTo
        {
            best = item;
        }
    }
    return best;
}

Check.Equal(42, Largest([3, 42, 7]));
Check.Equal("pear", Largest(["apple", "pear", "banana"]));

// A tiny in-memory "repository" — the kind of class you'd see in a real web app.
var products = new Repository<Product>();
products.Add(new Product { Id = 1, Name = "Mouse" });
products.Add(new Product { Id = 2, Name = "Monitor" });

Check.Equal("Monitor", products.GetById(2)?.Name);
Check.Equal(null, products.GetById(99));

interface IEntity
{
    int Id { get; }
}

class Product : IEntity
{
    public int Id { get; init; }
    public string Name { get; init; } = "";
}

class Repository<T>   // ❌ needs constraints: T must have an Id, and must be able to be null
{
    private readonly List<T> _items = [];

    public void Add(T item) => _items.Add(item);

    public T? GetById(int id)
    {
        foreach (T item in _items)
        {
            if (item.Id == id)
            {
                return item;
            }
        }
        return null;
    }
}
