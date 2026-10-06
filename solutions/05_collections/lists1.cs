// lists1.cs — solution

var todo = new List<string>();

todo.Add("write code");
todo.Add("test code");
todo.Add("ship it");

todo.Insert(0, "drink coffee");

todo.Remove("test code");

Check.Equal(3, todo.Count);
Check.Equal(new List<string> { "drink coffee", "write code", "ship it" }, todo);
Check.Equal(1, todo.IndexOf("write code"));

List<int> numbers = [5, 12, 7, 8, 3, 20];
List<int> evens = [];
foreach (int n in numbers)
{
    if (n % 2 == 0)
    {
        evens.Add(n);
    }
}

Check.Equal(new List<int> { 12, 8, 20 }, evens);
