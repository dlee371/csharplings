// linq2.cs
//
// More LINQ essentials:
//
//     OrderBy(x => x.Age)              sort ascending      (OrderByDescending for the reverse)
//       .ThenBy(x => x.Name)           ...and break ties   (ThenByDescending too)
//     First(x => ...)                  the first match — THROWS if there isn't one!
//     FirstOrDefault(x => ...)         the first match, or null/default if there isn't one
//     Any(x => ...)                    is there at least one match?
//     All(x => ...)                    does every item match?
//     Count(x => ...)                  how many match?
//     Take(n) / Skip(n)                the first n items / everything except the first n
//     Sum(x => ...), Average(...), Min(...), Max(...)

// I AM NOT DONE

List<Employee> staff =
[
    new("Ada", "Engineering", 120_000m, 7),
    new("Grace", "Engineering", 135_000m, 12),
    new("Linus", "Engineering", 98_000m, 3),
    new("Margaret", "Management", 150_000m, 15),
    new("Ken", "Support", 65_000m, 2),
    new("Barbara", "Support", 72_000m, 9),
];

var bySalary = ???;           // the names, highest salary first
Check.Equal(new[] { "Margaret", "Grace", "Ada", "Linus", "Barbara", "Ken" }, bySalary);

var byDeptThenName = ???;     // the names, sorted by Department, then by Name
Check.Equal(new[] { "Ada", "Grace", "Linus", "Margaret", "Barbara", "Ken" }, byDeptThenName);

Employee? firstInSupport = ???;
Check.Equal("Ken", firstInSupport?.Name);

Employee? firstInSales = ???;     // nobody works in "Sales" — this must not throw!
Check.Equal(null, firstInSales);

bool anyoneNew = ???;              // does anyone have fewer than 3 years?
bool allPaidWell = ???;            // does everyone earn at least 60,000?
int veterans = ???;                // how many people have 10 or more years?
decimal engineeringPayroll = ???;  // the total salary of everyone in Engineering
decimal top2Average = ???;         // the average salary of the 2 best-paid people

Check.True(anyoneNew);
Check.True(allPaidWell);
Check.Equal(2, veterans);
Check.Equal(353_000m, engineeringPayroll);
Check.Equal(142_500m, top2Average);

record Employee(string Name, string Department, decimal Salary, int Years);
