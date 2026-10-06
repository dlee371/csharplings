// interfaces1.cs — solution

var latte = new Coffee("latte", 4.50m);

IDescribable d = latte;
IPriced p = latte;
Check.Equal("A delicious latte", d.Describe());
Check.Equal(4.50m, p.Price);

decimal TotalPrice(List<IPriced> items)
{
    decimal total = 0;
    foreach (IPriced item in items)
    {
        total += item.Price;
    }
    return total;
}

Check.Equal(9.25m, TotalPrice([latte, new Coffee("mocha", 4.75m)]));

interface IDescribable
{
    string Describe();
}

interface IPriced
{
    decimal Price { get; }
}

class Coffee : IDescribable, IPriced
{
    public string Name { get; }
    public decimal Price { get; }

    public Coffee(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public string Describe() => $"A delicious {Name}";
}
