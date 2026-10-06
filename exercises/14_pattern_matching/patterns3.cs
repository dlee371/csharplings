// patterns3.cs
//
// You can switch on several values at once by making a tuple:
//
//     (x, y) switch
//     {
//         (0, 0) => "origin",
//         (_, 0) => "on the x-axis",
//         (0, _) => "on the y-axis",
//         _ => "somewhere else",
//     };
//
// You can match nested properties too:
//
//     order switch
//     {
//         { Total: > 100, Customer.IsVip: true } => ...,
//         ...
//     };
//
// A `when` clause adds an extra condition to an arm:
//
//     (a, b) switch { (var p, var q) when p == q => "same", _ => "different" };

// I AM NOT DONE

Result Play(Hand you, Hand them) => (you, them) switch
{
    ???
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
    // TODO: VIP customers get 0.20 off orders over 100, and 0.10 off other orders.
    // TODO: everyone else gets 0.05 off orders over 100, and nothing otherwise.
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
