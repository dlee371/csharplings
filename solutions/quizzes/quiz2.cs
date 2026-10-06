// quiz2.cs — solution

var checking = new Account("Ada");
checking.Deposit(100);
checking.Withdraw(30);
Check.Equal("Ada", checking.Owner);
Check.Equal(70m, checking.Balance);
Check.Equal(new List<string> { "+100", "-30" }, checking.History);

Check.Throws<ArgumentOutOfRangeException>(() => checking.Deposit(0));
Check.Throws<ArgumentOutOfRangeException>(() => checking.Withdraw(-5));
var error = Check.Throws<InsufficientFundsException>(() => checking.Withdraw(100));
Check.Equal(30m, error.Shortfall);
Check.Equal(70m, checking.Balance);

var savings = new SavingsAccount("Grace", interestRate: 0.05m);
savings.Deposit(1000);
savings.ApplyInterest();
Check.Equal(1050m, savings.Balance);
savings.Withdraw(1);
savings.Withdraw(1);
savings.Withdraw(1);
Check.Throws<InvalidOperationException>(() => savings.Withdraw(1));
Check.Equal(1047m, savings.Balance);

List<IAccount> all = [checking, savings];
decimal total = 0;
foreach (IAccount account in all)
{
    total += account.Balance;
}
Check.Equal(1117m, total);

interface IAccount
{
    string Owner { get; }
    decimal Balance { get; }
    void Deposit(decimal amount);
    void Withdraw(decimal amount);
}

class Account : IAccount
{
    private readonly List<string> _history = [];

    public Account(string owner) => Owner = owner;

    public string Owner { get; }
    public decimal Balance { get; private set; }
    public IReadOnlyList<string> History => _history;

    public void Deposit(decimal amount)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);
        Balance += amount;
        _history.Add($"+{amount}");
    }

    public virtual void Withdraw(decimal amount)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);
        if (amount > Balance)
        {
            throw new InsufficientFundsException(amount - Balance);
        }
        Balance -= amount;
        _history.Add($"-{amount}");
    }
}

class SavingsAccount : Account
{
    private const int MaxWithdrawals = 3;
    private int _withdrawals;

    public SavingsAccount(string owner, decimal interestRate) : base(owner) => InterestRate = interestRate;

    public decimal InterestRate { get; }

    public void ApplyInterest() => Deposit(Balance * InterestRate);

    public override void Withdraw(decimal amount)
    {
        if (_withdrawals >= MaxWithdrawals)
        {
            throw new InvalidOperationException($"Savings accounts allow only {MaxWithdrawals} withdrawals");
        }
        base.Withdraw(amount);
        _withdrawals++;
    }
}

class InsufficientFundsException(decimal shortfall)
    : Exception($"Insufficient funds: short by {shortfall}")
{
    public decimal Shortfall { get; } = shortfall;
}
