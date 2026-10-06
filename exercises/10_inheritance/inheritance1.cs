// inheritance1.cs
//
// A class can inherit from ONE other class, and gets all of its members:
//
//     class Animal
//     {
//         public string Name { get; }
//         public Animal(string name) { Name = name; }
//     }
//
//     class Dog : Animal                                // Dog "is an" Animal
//     {
//         public Dog(string name) : base(name) { }      // pass `name` to Animal's constructor
//         public string Fetch() => $"{Name} fetches!";  // Dog can use Name from Animal
//     }
//
// `protected` members are visible to the class and its subclasses, but not to outsiders.

// I AM NOT DONE

var manager = new Manager("Grace", 100_000m, teamSize: 5);

Check.Equal("Grace", manager.Name);
Check.Equal(100_000m, manager.Salary);
Check.Equal(5, manager.TeamSize);
Check.Equal("Grace earns 100000", manager.Describe());   // inherited from Employee!

Employee asEmployee = manager;   // a Manager IS an Employee, so this is allowed
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

class Manager
{
    public int TeamSize { get; }

    public Manager(string name, decimal salary, int teamSize)
    {
        TeamSize = teamSize;
    }
}
