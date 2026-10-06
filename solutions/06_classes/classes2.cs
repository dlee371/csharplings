// classes2.cs — solution

var item = new CartItem("Mechanical keyboard", 89.99m);
item.Quantity = 2;

Check.Equal("Mechanical keyboard", item.Name);
Check.Equal(89.99m, item.Price);
Check.Equal(2, item.Quantity);
Check.Equal(179.98m, item.Total);
Check.Throws<ArgumentException>(() => item.Quantity = -1);
Check.Equal(2, item.Quantity);

class CartItem
{
    private int _quantity;

    public CartItem(string name, decimal price)
    {
        Name = name;
        Price = price;
        Quantity = 1;
    }

    public string Name { get; }
    public decimal Price { get; }

    public int Quantity
    {
        get => _quantity;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Quantity can't be negative");
            }
            _quantity = value;
        }
    }

    public decimal Total => Price * Quantity;
}
