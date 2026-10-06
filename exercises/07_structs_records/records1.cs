// records1.cs
//
// A record is a class designed for holding data. One line gives you:
//
//   * a constructor and read-only (init) properties
//   * value-based equality: two records with the same data are == to each other
//     (normal classes compare references: two separate objects are never ==)
//   * a readable ToString(): "Person { Name = Ada, Age = 36 }"
//   * `with` expressions, to make a modified copy
//
//     public record Person(string Name, int Age);
//
//     var ada = new Person("Ada", 36);
//     var older = ada with { Age = 37 };     // `ada` itself is unchanged
//
// Records can have a body with extra methods, just like classes:
//
//     public record Person(string Name, int Age)
//     {
//         public bool IsAdult => Age >= 18;
//     }
//
// Records are perfect for DTOs (data transfer objects), API requests/responses,
// events, configuration... You'll see them EVERYWHERE in modern C#.

// I AM NOT DONE

var a = new Money(10.00m, "USD");
var b = new Money(10.00m, "USD");

Check.True(a == b);   // same data → equal

var c = ???;          // a copy of `a`, but in "EUR". Use `with`.
Check.Equal(new Money(10.00m, "EUR"), c);
Check.Equal("USD", a.Currency);

Check.Equal("Money { Amount = 10.00, Currency = USD }", a.ToString());

var doubled = a.Times(2);
Check.Equal(new Money(20.00m, "USD"), doubled);

// 🐛 Make me a record (one line!), and give it a Times(int factor) method
//    that returns a new Money with the amount multiplied.
class Money
{
    public decimal Amount { get; }
    public string Currency { get; }

    public Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }
}
