// methods3.cs — solution

Check.Equal(10m, Shop.Total(10m));
Check.Equal(30m, Shop.Total(10m, 3));
Check.Equal(27m, Shop.Total(10m, 3, 0.1m));
Check.Equal(9m, Shop.Total(10m, discount: 0.1m));

Check.Equal("3 items", Shop.Describe(3));
Check.Equal("3 x apple", Shop.Describe("apple", 3));

static class Shop
{
    public static decimal Total(decimal price, int quantity = 1, decimal discount = 0)
    {
        return price * quantity * (1 - discount);
    }

    public static string Describe(int count) => $"{count} items";

    public static string Describe(string item, int count) => $"{count} x {item}";
}
