// patterns3.cs — solution

Result Play(Hand you, Hand them) => (you, them) switch
{
    var (a, b) when a == b => Result.Draw,
    (Hand.Rock, Hand.Scissors) or (Hand.Paper, Hand.Rock) or (Hand.Scissors, Hand.Paper) => Result.Win,
    _ => Result.Lose,
};

Check.Equal(Result.Draw, Play(Hand.Rock, Hand.Rock));
Check.Equal(Result.Draw, Play(Hand.Paper, Hand.Paper));
Check.Equal(Result.Win, Play(Hand.Rock, Hand.Scissors));
Check.Equal(Result.Win, Play(Hand.Paper, Hand.Rock));
Check.Equal(Result.Win, Play(Hand.Scissors, Hand.Paper));
Check.Equal(Result.Lose, Play(Hand.Rock, Hand.Paper));
Check.Equal(Result.Lose, Play(Hand.Scissors, Hand.Rock));

decimal Discount(Order order) => order switch
{
    { Total: > 100, Customer.IsVip: true } => 0.20m,
    { Customer.IsVip: true } => 0.10m,
    { Total: > 100 } => 0.05m,
    _ => 0m,
};

Check.Equal(0.20m, Discount(new Order(150m, new Customer("Ada", IsVip: true))));
Check.Equal(0.10m, Discount(new Order(50m, new Customer("Ada", IsVip: true))));
Check.Equal(0.05m, Discount(new Order(150m, new Customer("Bob", IsVip: false))));
Check.Equal(0m, Discount(new Order(50m, new Customer("Bob", IsVip: false))));

enum Hand { Rock, Paper, Scissors }
enum Result { Win, Lose, Draw }
record Customer(string Name, bool IsVip);
record Order(decimal Total, Customer Customer);
