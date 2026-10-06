// linq3.cs
//
// Grouping and summarizing data — the bread and butter of business software:
//
//     var byCity = people.GroupBy(p => p.City);     // a sequence of groups
//     foreach (var group in byCity)
//     {
//         // group.Key is the city; the group itself is a sequence of the people in it
//         Console.WriteLine($"{group.Key}: {group.Count()} people");
//     }
//
//     people.ToDictionary(p => p.Id, p => p.Name)   // build a dictionary: key selector, value selector
//     names.Distinct()                              // remove duplicates
//     orders.SelectMany(o => o.Lines)               // flatten a list of lists into one sequence
//
// Select can create tuples on the fly:  .Select(g => (g.Key, g.Count()))

// I AM NOT DONE

List<Sale> sales =
[
    new("North", "Laptop", 2, 1000m),
    new("South", "Mouse", 10, 20m),
    new("North", "Mouse", 5, 20m),
    new("East", "Laptop", 1, 1000m),
    new("South", "Laptop", 1, 1000m),
    new("North", "Monitor", 2, 300m),
];

// 1. Total revenue (Quantity × UnitPrice) per region.
Dictionary<string, decimal> revenueByRegion = ???;
Check.Equal(2700m, revenueByRegion["North"]);
Check.Equal(1200m, revenueByRegion["South"]);
Check.Equal(1000m, revenueByRegion["East"]);

// 2. The names of the products sold, without duplicates, in alphabetical order.
List<string> products = ???;
Check.Equal(new[] { "Laptop", "Monitor", "Mouse" }, products);

// 3. For each product, the total number of units sold — most units first.
List<(string Product, int Units)> unitsPerProduct = ???;
Check.Equal(new[] { ("Mouse", 15), ("Laptop", 4), ("Monitor", 2) }, unitsPerProduct);

// 4. Each order is a list of item quantities. How many items are there across ALL orders?
List<List<int>> orders = [[1, 2], [3], [4, 5, 6]];
int totalItems = ???;   // try SelectMany!
Check.Equal(21, totalItems);

record Sale(string Region, string Product, int Quantity, decimal UnitPrice);
