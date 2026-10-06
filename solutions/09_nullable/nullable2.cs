// nullable2.cs — solution

var withCity = new Customer("Ada", new Address("London"));
var noAddress = new Customer("Grace", null);
Customer? nobody = null;

string CityOf(Customer? customer)
{
    return customer?.Address?.City ?? "unknown";
}

Check.Equal("London", CityOf(withCity));
Check.Equal("unknown", CityOf(noAddress));
Check.Equal("unknown", CityOf(nobody));

string? settings = null;
int loads = 0;
string LoadSettings()
{
    loads++;
    return "dark-mode";
}

settings ??= LoadSettings();
settings ??= LoadSettings();

Check.Equal("dark-mode", settings);
Check.Equal(1, loads);

record Address(string City);
record Customer(string Name, Address? Address);
