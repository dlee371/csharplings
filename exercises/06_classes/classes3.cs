// classes3.cs
//
// `static` members belong to the class itself, not to any one object. There is
// exactly one copy, shared by everyone.
//
//     class Circle
//     {
//         public static int CreatedCount;          // one counter shared by ALL circles
//         public double Radius { get; }
//         public Circle(double r) { Radius = r; CreatedCount++; }
//     }
//
//     Circle.CreatedCount       // accessed through the class name, not an instance
//
// You've used static members since the very first exercise: Console.WriteLine,
// int.Parse, Math.Round, string.Join...
//
// `const` fields are automatically static.

// I AM NOT DONE

var a = new Ticket();
var b = new Ticket();
var c = new Ticket();

Check.Equal(1, a.Number);
Check.Equal(2, b.Number);
Check.Equal(3, c.Number);
Check.Equal(3, Ticket.IssuedCount);

Check.Equal("°C", Temperature.Unit);
Check.Close(212.0, Temperature.CelsiusToFahrenheit(100));
Check.Close(32.0, Temperature.CelsiusToFahrenheit(0));

class Ticket
{
    // Every ticket gets the next number: 1, 2, 3, ...
    // Think: which of these should be shared by all tickets, and which belongs to each ticket?
    public int IssuedCount { get; private set; }
    public int Number { get; }

    public Ticket()
    {
        IssuedCount++;
        Number = IssuedCount;
    }
}

// A static class can ONLY contain static members — a toolbox of helpers, like Math.
static class Temperature
{
    public string Unit = "°C";
    double CelsiusToFahrenheit(double celsius) => celsius * 9 / 5 + 32;
}
