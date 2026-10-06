// methods3.cs
//
// In real projects, methods live inside classes. Here's a sneak peek: a
// `static class` is just a container for methods. Call them with ClassName.Method().
// Class definitions go at the BOTTOM of a file that has top-level statements.
//
// Parameters can have default values, which makes them optional:
//
//     public static string Greet(string name, string greeting = "Hello")
//         => $"{greeting}, {name}!";
//
//     Greet("Ada")                           // "Hello, Ada!"
//     Greet("Ada", "Hi")                     // "Hi, Ada!"
//     Greet(greeting: "Yo", name: "Ada")     // *named* arguments, in any order
//
// Methods in a class can also be *overloaded*: same name, different parameters.
// C# picks the right one based on the arguments you pass.

// I AM NOT DONE

Check.Equal(10m, Shop.Total(10m));
Check.Equal(30m, Shop.Total(10m, 3));
Check.Equal(27m, Shop.Total(10m, 3, 0.1m));
Check.Equal(9m, Shop.Total(10m, discount: 0.1m));

Check.Equal("3 items", Shop.Describe(3));
Check.Equal("3 x apple", Shop.Describe("apple", 3));

static class Shop
{
    // TODO: make `quantity` default to 1 and `discount` default to 0
    public static decimal Total(decimal price, int quantity, decimal discount)
    {
        return price * quantity * (1 - discount);
    }

    public static string Describe(int count) => $"{count} items";

    // TODO: add an overload: Describe(string item, int count) that returns e.g. "3 x apple"
}
