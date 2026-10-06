// classes2.cs
//
// In C#, public data is almost always exposed through *properties*, not public
// fields. From the outside a property looks like a field, but the class stays in
// control of how it's read and written:
//
//     public string Name { get; set; }               // auto-property: read & write
//     public int Id { get; }                         // read-only: only settable in the constructor
//     public decimal Balance { get; private set; }   // anyone can read, only the class can write
//     public bool IsEmpty => Count == 0;             // computed: no storage, calculated on each read
//
//     private int _age;                              // a private "backing field"
//     public int Age
//     {
//         get => _age;
//         set
//         {
//             if (value < 0)                         // `value` is whatever the caller assigned
//                 throw new ArgumentException("Age can't be negative");
//             _age = value;
//         }
//     }
//
// `throw` stops the method with an error (an *exception*). More on that later.
// Naming convention: PascalCase for public members, _camelCase for private fields.
//
// (In the checks, `() => item.Quantity = -1` is a *lambda*: a tiny inline function.
//  Check.Throws runs it and expects an exception. Lambdas get their own section later.)

// I AM NOT DONE

var item = new CartItem("Mechanical keyboard", 89.99m);
item.Quantity = 2;

Check.Equal("Mechanical keyboard", item.Name);
Check.Equal(89.99m, item.Price);
Check.Equal(2, item.Quantity);
Check.Equal(179.98m, item.Total);
Check.Throws<ArgumentException>(() => item.Quantity = -1);
Check.Equal(2, item.Quantity);   // the bad value was rejected

// item.Name = "Something else";
// ↑ Once you're done, try uncommenting this line: it should NOT compile,
//   because Name is read-only. Then put the comment back.

class CartItem
{
    public CartItem(string name, decimal price)
    {
        Name = name;
        Price = price;
        Quantity = 1;
    }

    // TODO: Name — read-only
    // TODO: Price — read-only
    // TODO: Quantity — read/write, using a backing field; throw an ArgumentException if set below 0
    // TODO: Total — computed: Price * Quantity
}
