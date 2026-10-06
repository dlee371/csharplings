// linq3.cs — solution

List<Sale> sales =
[
    new("North", "Laptop", 2, 1000m),
    new("South", "Mouse", 10, 20m),
    new("North", "Mouse", 5, 20m),
    new("East", "Laptop", 1, 1000m),
    new("South", "Laptop", 1, 1000m),
    new("North", "Monitor", 2, 300m),
];

Dictionary<string, decimal> revenueByRegion = sales
    .GroupBy(s => s.Region)
    .ToDictionary(g => g.Key, g => g.Sum(s => s.Quantity * s.UnitPrice));
Check.Equal(2700m, revenueByRegion["North"]);
Check.Equal(1200m, revenueByRegion["South"]);
Check.Equal(1000m, revenueByRegion["East"]);

List<string> products = sales.Select(s => s.Product).Distinct().Order().ToList();
Check.Equal(new[] { "Laptop", "Monitor", "Mouse" }, products);

List<(string Product, int Units)> unitsPerProduct = sales
    .GroupBy(s => s.Product)
    .Select(g => (g.Key, g.Sum(s => s.Quantity)))
    .OrderByDescending(t => t.Item2)
    .ToList();
Check.Equal(new[] { ("Mouse", 15), ("Laptop", 4), ("Monitor", 2) }, unitsPerProduct);

List<List<int>> orders = [[1, 2], [3], [4, 5, 6]];
int totalItems = orders.SelectMany(o => o).Sum();
Check.Equal(21, totalItems);

record Sale(string Region, string Product, int Quantity, decimal UnitPrice);
