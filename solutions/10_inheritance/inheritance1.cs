// inheritance1.cs — solution

var manager = new Manager("Grace", 100_000m, teamSize: 5);

Check.Equal("Grace", manager.Name);
Check.Equal(100_000m, manager.Salary);
Check.Equal(5, manager.TeamSize);
Check.Equal("Grace earns 100000", manager.Describe());

Employee asEmployee = manager;
Check.Equal("Grace", asEmployee.Name);

class Employee
{
    public string Name { get; }
    public decimal Salary { get; }

    public Employee(string name, decimal salary)
    {
        Name = name;
        Salary = salary;
    }

    public string Describe() => $"{Name} earns {Salary}";
}

class Manager : Employee
{
    public int TeamSize { get; }

    public Manager(string name, decimal salary, int teamSize) : base(name, salary)
    {
        TeamSize = teamSize;
    }
}
