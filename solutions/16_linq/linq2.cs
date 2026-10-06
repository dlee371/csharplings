// linq2.cs — solution

List<Employee> staff =
[
    new("Ada", "Engineering", 120_000m, 7),
    new("Grace", "Engineering", 135_000m, 12),
    new("Linus", "Engineering", 98_000m, 3),
    new("Margaret", "Management", 150_000m, 15),
    new("Ken", "Support", 65_000m, 2),
    new("Barbara", "Support", 72_000m, 9),
];

var bySalary = staff.OrderByDescending(e => e.Salary).Select(e => e.Name).ToList();
Check.Equal(new[] { "Margaret", "Grace", "Ada", "Linus", "Barbara", "Ken" }, bySalary);

var byDeptThenName = staff.OrderBy(e => e.Department).ThenBy(e => e.Name).Select(e => e.Name).ToList();
Check.Equal(new[] { "Ada", "Grace", "Linus", "Margaret", "Barbara", "Ken" }, byDeptThenName);

Employee? firstInSupport = staff.First(e => e.Department == "Support");
Check.Equal("Ken", firstInSupport?.Name);

Employee? firstInSales = staff.FirstOrDefault(e => e.Department == "Sales");
Check.Equal(null, firstInSales);

bool anyoneNew = staff.Any(e => e.Years < 3);
bool allPaidWell = staff.All(e => e.Salary >= 60_000m);
int veterans = staff.Count(e => e.Years >= 10);
decimal engineeringPayroll = staff.Where(e => e.Department == "Engineering").Sum(e => e.Salary);
decimal top2Average = staff.OrderByDescending(e => e.Salary).Take(2).Average(e => e.Salary);

Check.True(anyoneNew);
Check.True(allPaidWell);
Check.Equal(2, veterans);
Check.Equal(353_000m, engineeringPayroll);
Check.Equal(142_500m, top2Average);

record Employee(string Name, string Department, decimal Salary, int Years);
