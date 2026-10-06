// collections1.cs — solution

bool HasDuplicates(int[] values)
{
    var seen = new HashSet<int>();
    foreach (int v in values)
    {
        if (!seen.Add(v))
        {
            return true;
        }
    }
    return false;
}

Check.True(HasDuplicates(new[] { 1, 2, 3, 2 }));
Check.False(HasDuplicates(new[] { 1, 2, 3, 4 }));

var line = new Queue<string>();
line.Enqueue("Ann");
line.Enqueue("Bob");
line.Enqueue("Cat");
string firstServed = line.Dequeue();
Check.Equal("Ann", firstServed);
Check.Equal(2, line.Count);

bool IsBalanced(string code)
{
    var stack = new Stack<char>();
    foreach (char c in code)
    {
        if (c == '(' || c == '[' || c == '{')
        {
            stack.Push(c);
        }
        else if (c == ')' || c == ']' || c == '}')
        {
            if (stack.Count == 0)
            {
                return false;
            }
            char open = stack.Pop();
            if ((c == ')' && open != '(') || (c == ']' && open != '[') || (c == '}' && open != '{'))
            {
                return false;
            }
        }
    }
    return stack.Count == 0;
}

Check.True(IsBalanced("if (x) { list[0] = 1; }"));
Check.True(IsBalanced(""));
Check.False(IsBalanced("(]"));
Check.False(IsBalanced("{(})"));
Check.False(IsBalanced("(("));
