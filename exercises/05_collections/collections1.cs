// collections1.cs
//
// More collections you'll use all the time:
//
//     HashSet<T>   unique items, super fast Contains().
//                  set.Add(x) returns false if x was already in the set.
//     Queue<T>     first in, first out — like a line at a shop.
//                  Enqueue(x), Dequeue(), Peek(), Count
//     Stack<T>     last in, first out — like a stack of plates.
//                  Push(x), Pop(), Peek(), Count

// I AM NOT DONE

// 1. HashSet: return true if the array contains any value more than once.
bool HasDuplicates(int[] values)
{
    var seen = new HashSet<int>();
    // TODO
    return false;
}

Check.True(HasDuplicates(new[] { 1, 2, 3, 2 }));
Check.False(HasDuplicates(new[] { 1, 2, 3, 4 }));

// 2. Queue: customers are served in the order they arrived.
var line = new Queue<string>();
line.Enqueue("Ann");
line.Enqueue("Bob");
line.Enqueue("Cat");
string firstServed = ???;   // take the next customer out of the queue
Check.Equal("Ann", firstServed);
Check.Equal(2, line.Count);

// 3. Stack: the classic "balanced brackets" interview question!
//    Push every opening bracket. For every closing bracket, the top of the stack
//    must be the matching opening bracket. At the end, nothing should be left open.
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
            // TODO: return false if `open` doesn't match `c`
        }
    }
    return true;   // 🐛 is that always right?
}

Check.True(IsBalanced("if (x) { list[0] = 1; }"));
Check.True(IsBalanced(""));
Check.False(IsBalanced("(]"));
Check.False(IsBalanced("{(})"));
Check.False(IsBalanced("(("));
