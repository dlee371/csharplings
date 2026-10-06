// events1.cs
//
// Events let an object notify others when something happens, without knowing
// who's listening (the "observer" pattern). Think of a button's Click in a UI,
// or an "OrderPlaced" notification in a web shop.
//
//     class Button
//     {
//         public event Action<string>? Clicked;             // declare the event
//
//         public void Click() => Clicked?.Invoke("OK");     // raise it (?. in case nobody is listening)
//     }
//
//     button.Clicked += name => Console.WriteLine($"{name} was clicked");   // subscribe
//     button.Clicked -= someHandler;                                        // unsubscribe
//
// Many listeners can subscribe to the same event. Only the class that declares
// an event can raise it.

// I AM NOT DONE

var ticker = new StockTicker();
var alerts = new List<string>();
int changes = 0;

// TODO: subscribe to PriceChanged so that `changes` goes up by one on every change.
// TODO: subscribe again, so that a new price above 100 adds "<symbol> is above 100!" to alerts.

ticker.Update("MSFT", 95m);
ticker.Update("MSFT", 105m);
ticker.Update("MSFT", 105m);   // same price as before: no event
ticker.Update("AAPL", 101m);

Check.Equal(3, changes);
Check.Equal(new List<string> { "MSFT is above 100!", "AAPL is above 100!" }, alerts);

class StockTicker
{
    private readonly Dictionary<string, decimal> _prices = new();

    // TODO: declare a PriceChanged event of type Action<string, decimal>  (the symbol and its new price)

    public void Update(string symbol, decimal price)
    {
        if (_prices.TryGetValue(symbol, out decimal old) && old == price)
        {
            return;
        }
        _prices[symbol] = price;
        // TODO: raise PriceChanged
    }
}
