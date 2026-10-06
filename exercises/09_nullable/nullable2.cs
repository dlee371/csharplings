// nullable2.cs
//
// Reference types (classes, strings, lists...) can also be null. Using a null
// reference throws the infamous NullReferenceException — probably the most
// common bug in all of C#.
//
// C# has operators that make "maybe null" values easy to handle:
//
//     customer?.Address           // null if customer is null, otherwise its Address
//     customer?.Address?.City     // chains: becomes null as soon as anything is null
//     name ?? "anonymous"         // a fallback when the left side is null
//     cache ??= Load();           // assign ONLY if cache is currently null
//
// With "nullable reference types" (turned on in all these exercises, and in
// every new .NET project), the compiler tracks what might be null:
// `string?` may be null; plain `string` should never be. Read the warnings!

// I AM NOT DONE

var withCity = new Customer("Ada", new Address("London"));
var noAddress = new Customer("Grace", null);
Customer? nobody = null;

string CityOf(Customer? customer)
{
    return customer.Address.City;   // 💥 crashes when anything is null. Use ?. and ??
}

Check.Equal("London", CityOf(withCity));
Check.Equal("unknown", CityOf(noAddress));
Check.Equal("unknown", CityOf(nobody));

// Load the settings only the first time they're needed.
string? settings = null;
int loads = 0;
string LoadSettings()
{
    loads++;
    return "dark-mode";
}

settings = LoadSettings();   // 🐛 change these two lines so LoadSettings
settings = LoadSettings();   //    only runs if settings is still null

Check.Equal("dark-mode", settings);
Check.Equal(1, loads);

record Address(string City);
record Customer(string Name, Address? Address);
