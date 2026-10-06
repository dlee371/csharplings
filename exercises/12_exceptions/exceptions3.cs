// exceptions3.cs
//
// 1. Custom exceptions: inherit from Exception to describe errors in YOUR domain.
//    Pass the message to the base constructor:
//
//        class OutOfStockException : Exception
//        {
//            public string Sku { get; }
//            public OutOfStockException(string sku) : base($"{sku} is out of stock") => Sku = sku;
//        }
//
// 2. `using` and IDisposable: objects that hold resources (files, network or
//    database connections) implement IDisposable, which has one method: Dispose().
//    A `using` declaration calls Dispose() automatically at the end of the
//    enclosing block — EVEN IF an exception is thrown. It's a built-in try/finally.
//
//        using var file = File.OpenRead("data.txt");
//        ...   // file.Dispose() runs automatically when this block ends

// I AM NOT DONE

var log = new List<string>();

void Transfer(decimal amount)
{
    var connection = new FakeDbConnection(log);   // 🐛 this must ALWAYS get disposed!
    if (amount > 100)
    {
        throw new LimitExceededException(amount, 100);
    }
    connection.Execute($"transfer {amount}");
}

Transfer(50);
var error = Check.Throws<LimitExceededException>(() => Transfer(500));
Check.Equal(500m, error.Amount);
Check.Equal(100m, error.Limit);
Check.Equal("Transfer of 500 exceeds the limit of 100", error.Message);

Check.Equal(new List<string> { "open", "transfer 50", "close", "open", "close" }, log);

class FakeDbConnection : IDisposable
{
    private readonly List<string> _log;

    public FakeDbConnection(List<string> log)
    {
        _log = log;
        _log.Add("open");
    }

    public void Execute(string command) => _log.Add(command);

    public void Dispose() => _log.Add("close");
}

// TODO: create LimitExceededException, with Amount and Limit properties and the message shown above.
