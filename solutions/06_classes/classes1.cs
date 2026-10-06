// classes1.cs — solution

var counter = new Counter("clicks");
counter.Increment();
counter.Increment();
counter.Increment();
counter.Reset();
counter.Increment();

Check.Equal("clicks", counter.Name);
Check.Equal(1, counter.Value);
Check.Equal("clicks: 1", counter.Describe());

class Counter
{
    public string Name;
    public int Value;

    public Counter(string name)
    {
        Name = name;
    }

    public void Increment()
    {
        Value++;
    }

    public void Reset()
    {
        Value = 0;
    }

    public string Describe() => $"{Name}: {Value}";
}
