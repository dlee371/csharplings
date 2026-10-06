// structs1.cs — solution

var original = new Point(1, 2);
var copy = original;
copy.X = 99;

Check.Equal(1, original.X);
Check.Equal(99, copy.X);

// list1 and list2 point at the same list, so adding through list2 is visible through list1.
var list1 = new List<int> { 1, 2, 3 };
var list2 = list1;
list2.Add(4);
Check.Equal(4, list1.Count);

struct Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}
