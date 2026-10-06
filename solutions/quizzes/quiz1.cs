// quiz1.cs — solution

double Average(List<int> scores)
{
    if (scores.Count == 0)
    {
        return 0;
    }
    int sum = 0;
    foreach (int s in scores)
    {
        sum += s;
    }
    return (double)sum / scores.Count;
}

string Letter(double average)
{
    if (average >= 90) return "A";
    if (average >= 80) return "B";
    if (average >= 70) return "C";
    if (average >= 60) return "D";
    return "F";
}

string Report(Dictionary<string, List<int>> gradebook)
{
    var names = new List<string>(gradebook.Keys);
    names.Sort();

    var lines = new List<string>();
    foreach (string name in names)
    {
        double avg = Average(gradebook[name]);
        lines.Add($"{name}: {avg:F1} ({Letter(avg)})");
    }
    return string.Join("\n", lines);
}

Check.Close(85.0, Average([80, 90]));
Check.Close(0.0, Average([]));
Check.Equal("A", Letter(90));
Check.Equal("B", Letter(89.9));
Check.Equal("C", Letter(70));
Check.Equal("D", Letter(65));
Check.Equal("F", Letter(12));

var gradebook = new Dictionary<string, List<int>>
{
    ["Linus"] = [70, 75, 71],
    ["Ada"] = [95, 90],
    ["Grace"] = [88, 91, 79],
};

Console.WriteLine(Report(gradebook));
Check.Equal("Ada: 92.5 (A)\nGrace: 86.0 (B)\nLinus: 72.0 (C)", Report(gradebook));
