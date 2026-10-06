// linq1.cs — solution

List<int> numbers = [5, 12, 8, 130, 44, 3, 7, 21];

List<int> bigOnes = numbers.Where(n => n > 10).ToList();
List<int> doubled = numbers.Select(n => n * 2).ToList();
List<string> labels = numbers.Where(n => n % 2 == 0).Select(n => $"#{n}").ToList();

Check.Equal(new List<int> { 12, 130, 44, 21 }, bigOnes);
Check.Equal(new List<int> { 10, 24, 16, 260, 88, 6, 14, 42 }, doubled);
Check.Equal(new List<string> { "#12", "#8", "#130", "#44" }, labels);

string[] words = ["  Apple", "banana ", "", " cherry", "   "];
string[] cleaned = words
    .Select(w => w.Trim())
    .Where(w => w.Length > 0)
    .Select(w => w.ToUpper())
    .ToArray();
Check.Equal(new[] { "APPLE", "BANANA", "CHERRY" }, cleaned);
