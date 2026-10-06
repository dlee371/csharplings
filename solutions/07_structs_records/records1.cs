// records1.cs — solution

var a = new Money(10.00m, "USD");
var b = new Money(10.00m, "USD");

Check.True(a == b);

var c = a with { Currency = "EUR" };
Check.Equal(new Money(10.00m, "EUR"), c);
Check.Equal("USD", a.Currency);

Check.Equal("Money { Amount = 10.00, Currency = USD }", a.ToString());

var doubled = a.Times(2);
Check.Equal(new Money(20.00m, "USD"), doubled);

record Money(decimal Amount, string Currency)
{
    public Money Times(int factor) => this with { Amount = Amount * factor };
}
