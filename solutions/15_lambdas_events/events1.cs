// events1.cs — solution

var ticker = new StockTicker();
var alerts = new List<string>();
int changes = 0;

ticker.PriceChanged += (symbol, price) => changes++;
ticker.PriceChanged += (symbol, price) =>
{
    if (price > 100)
    {
        alerts.Add($"{symbol} is above 100!");
    }
};

ticker.Update("MSFT", 95m);
ticker.Update("MSFT", 105m);
ticker.Update("MSFT", 105m);
ticker.Update("AAPL", 101m);

Check.Equal(3, changes);
Check.Equal(new List<string> { "MSFT is above 100!", "AAPL is above 100!" }, alerts);

class StockTicker
{
    private readonly Dictionary<string, decimal> _prices = new();

    public event Action<string, decimal>? PriceChanged;

    public void Update(string symbol, decimal price)
    {
        if (_prices.TryGetValue(symbol, out decimal old) && old == price)
        {
            return;
        }
        _prices[symbol] = price;
        PriceChanged?.Invoke(symbol, price);
    }
}
