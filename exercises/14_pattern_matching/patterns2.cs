// patterns2.cs
//
// A switch EXPRESSION turns one value into another, very compactly:
//
//     string size = count switch
//     {
//         0 => "none",
//         1 => "one",
//         < 10 => "a few",
//         _ => "many",          // `_` (the "discard") matches anything
//     };
//
// Arms are checked from top to bottom; the first one that matches wins.
// The compiler warns you (CS8509) if some possible value isn't handled.
//
// Type patterns and *property patterns* work here too:
//
//     shape switch
//     {
//         Circle { Radius: 0 } => "a dot",
//         Circle c => $"circle of radius {c.Radius}",
//         _ => "something else",
//     };
//
// And `throw` is allowed as an arm: `_ => throw new ArgumentException(...)`.

// I AM NOT DONE

// TODO: use a switch expression. 90+ → "A", 80+ → "B", 70+ → "C", 60+ → "D",
//       0 or more → "F", and anything below 0 or above 100 → "invalid".
string Grade(int score) => ???;

Check.Equal("A", Grade(95));
Check.Equal("A", Grade(100));
Check.Equal("B", Grade(85));
Check.Equal("C", Grade(70));
Check.Equal("D", Grade(65));
Check.Equal("F", Grade(0));
Check.Equal("invalid", Grade(101));
Check.Equal("invalid", Grade(-3));

decimal ShippingCost(Package package) => package switch
{
    Letter => 1.50m,
    // TODO: a Parcel weighing 2 kg or less costs 5
    // TODO: any heavier Parcel costs 5, plus 2 for every kg over 2
    // TODO: anything else: throw an ArgumentException
};

Check.Equal(1.50m, ShippingCost(new Letter()));
Check.Equal(5m, ShippingCost(new Parcel(1.5m)));
Check.Equal(9m, ShippingCost(new Parcel(4m)));
Check.Throws<ArgumentException>(() => ShippingCost(new Pallet()));

abstract record Package;
record Letter : Package;
record Parcel(decimal WeightKg) : Package;
record Pallet : Package;
