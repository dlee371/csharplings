// patterns2.cs — solution

string Grade(int score) => score switch
{
    < 0 or > 100 => "invalid",
    >= 90 => "A",
    >= 80 => "B",
    >= 70 => "C",
    >= 60 => "D",
    _ => "F",
};

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
    Parcel { WeightKg: <= 2 } => 5m,
    Parcel p => 5m + (p.WeightKg - 2) * 2,
    _ => throw new ArgumentException($"Can't ship a {package.GetType().Name}", nameof(package)),
};

Check.Equal(1.50m, ShippingCost(new Letter()));
Check.Equal(5m, ShippingCost(new Parcel(1.5m)));
Check.Equal(9m, ShippingCost(new Parcel(4m)));
Check.Throws<ArgumentException>(() => ShippingCost(new Pallet()));

abstract record Package;
record Letter : Package;
record Parcel(decimal WeightKg) : Package;
record Pallet : Package;
