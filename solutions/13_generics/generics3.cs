// generics3.cs — solution

T Largest<T>(List<T> items) where T : IComparable<T>
{
    T best = items[0];
    foreach (T item in items)
    {
        if (item.CompareTo(best) > 0)
        {
            best = item;
        }
    }
    return best;
}

Check.Equal(42, Largest([3, 42, 7]));
Check.Equal("pear", Largest(["apple", "pear", "banana"]));

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

class Repository<T> where T : class, IEntity
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
