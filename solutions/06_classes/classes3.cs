// classes3.cs — solution

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
    public static int IssuedCount { get; private set; }   // shared
    public int Number { get; }                            // per ticket

    public Ticket()
    {
        IssuedCount++;
        Number = IssuedCount;
    }
}

static class Temperature
{
    public const string Unit = "°C";
    public static double CelsiusToFahrenheit(double celsius) => celsius * 9 / 5 + 32;
}
