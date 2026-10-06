// generics1.cs — solution

void Swap<T>(ref T a, ref T b)
{
    T temp = a;
    a = b;
    b = temp;
}

int x = 1, y = 2;
Swap(ref x, ref y);
Check.Equal((2, 1), (x, y));

string s1 = "left", s2 = "right";
Swap(ref s1, ref s2);
Check.Equal(("right", "left"), (s1, s2));

List<T> Repeat<T>(T item, int count)
{
    var result = new List<T>();
    for (int i = 0; i < count; i++)
    {
        result.Add(item);
    }
    return result;
}

Check.Equal(new List<string> { "ha", "ha", "ha" }, Repeat("ha", 3));
Check.Equal(new List<bool> { true, true }, Repeat(true, 2));
Check.Equal(0, Repeat(3.14, 0).Count);
