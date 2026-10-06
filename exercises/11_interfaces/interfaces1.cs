// interfaces1.cs
//
// An interface is a contract: a list of members that a type promises to have,
// without saying HOW they work.
//
//     interface IGreeter
//     {
//         string Greet(string name);
//     }
//
//     class FriendlyGreeter : IGreeter
//     {
//         public string Greet(string name) => $"Hey {name}!";
//     }
//
// A class can inherit from only ONE class, but can implement MANY interfaces:
//
//     class Duck : Animal, ISwimmer, IFlyer { ... }
//
// Convention: interface names start with a capital I.

// I AM NOT DONE

var latte = new Coffee("latte", 4.50m);

IDescribable d = latte;
IPriced p = latte;
Check.Equal("A delicious latte", d.Describe());
Check.Equal(4.50m, p.Price);

// This method works with ANYTHING that has a price — coffee, books, cars...
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

// TODO: an IPriced interface with a read-only `decimal Price` property

// TODO: make Coffee implement both interfaces
class Coffee
{
    public string Name { get; }

    public Coffee(string name, decimal price)
    {
        Name = name;
    }
}
