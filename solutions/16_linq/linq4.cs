// linq4.cs — solution

List<Customer> customers =
[
    new(1, "Ada", "London"),
    new(2, "Grace", "New York"),
    new(3, "Linus", "Helsinki"),
];
List<Order> orders =
[
    new(100, 1, 50m),
    new(101, 2, 75m),
    new(102, 1, 25m),
    new(103, 3, 10m),
    new(104, 2, 200m),
];

var notLondon = from c in customers
                where c.City != "London"
                orderby c.Name
                select c.Name;
Check.Equal(new[] { "Grace", "Linus" }, notLondon);

var bigOrders = from o in orders
                join c in customers on o.CustomerId equals c.Id
                where o.Total > 30
                orderby o.Id
                select $"{c.Name}: {o.Total}";
Check.Equal(new[] { "Ada: 50", "Grace: 75", "Grace: 200" }, bigOrders);

var spending = customers
    .Select(c => new { c.Name, Total = orders.Where(o => o.CustomerId == c.Id).Sum(o => o.Total) })
    .OrderByDescending(x => x.Total)
    .Select(x => $"{x.Name}: {x.Total}");
Check.Equal(new[] { "Grace: 275", "Ada: 75", "Linus: 10" }, spending);

record Customer(int Id, string Name, string City);
record Order(int Id, int CustomerId, decimal Total);
