// linq4.cs
//
// LINQ also has a SQL-like *query syntax*. It compiles to the very same method
// calls, so use whichever reads better. You'll meet both in real code — and
// almost the same syntax in Entity Framework, which turns LINQ into real SQL!
//
//     var adults = from p in people
//                  where p.Age >= 18
//                  orderby p.Name
//                  select p.Name;
//
// Joining two collections on a shared key:
//
//     var rows = from o in orders
//                join c in customers on o.CustomerId equals c.Id
//                select $"{c.Name} ordered {o.Total}";
//
// You can also `select new { c.Name, o.Total }` to create an *anonymous type*:
// a quick, unnamed object with read-only properties.

// I AM NOT DONE

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

// 1. With QUERY syntax: the names of customers NOT in London, alphabetically.
var notLondon = ???;
Check.Equal(new[] { "Grace", "Linus" }, notLondon);

// 2. With QUERY syntax and a join: "<name>: <total>" for every order over 30, ordered by order Id.
var bigOrders = ???;
Check.Equal(new[] { "Ada: 50", "Grace: 75", "Grace: 200" }, bigOrders);

// 3. Any syntax you like: each customer's total spending, biggest spender first.
var spending = ???;
Check.Equal(new[] { "Grace: 275", "Ada: 75", "Linus: 10" }, spending);

record Customer(int Id, string Name, string City);
record Order(int Id, int CustomerId, decimal Total);
