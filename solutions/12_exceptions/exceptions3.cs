// exceptions3.cs — solution

var log = new List<string>();

void Transfer(decimal amount)
{
    using var connection = new FakeDbConnection(log);
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

class LimitExceededException : Exception
{
    public decimal Amount { get; }
    public decimal Limit { get; }

    public LimitExceededException(decimal amount, decimal limit)
        : base($"Transfer of {amount} exceeds the limit of {limit}")
    {
        Amount = amount;
        Limit = limit;
    }
}
