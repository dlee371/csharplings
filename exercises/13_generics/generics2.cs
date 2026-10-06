// generics2.cs
//
// Classes can be generic too:
//
//     class Box<T>
//     {
//         public T Value { get; }
//         public Box(T value) => Value = value;
//     }
//
//     var b = new Box<int>(42);
//     var s = new Box<string>("hi");
//
// Let's build a "recent items" list — like the recently-opened files in an editor.
// It holds at most `capacity` items. Adding more pushes out the OLDEST one.

// I AM NOT DONE

var recentPages = new RecentItems<string>(capacity: 3);
recentPages.Add("home");
recentPages.Add("about");
recentPages.Add("blog");
recentPages.Add("contact");

Check.Equal(3, recentPages.Count);
Check.Equal(new List<string> { "contact", "blog", "about" }, recentPages.MostRecentFirst());

var recentNumbers = new RecentItems<int>(capacity: 2);
recentNumbers.Add(1);
recentNumbers.Add(2);
recentNumbers.Add(3);
Check.Equal(new List<int> { 3, 2 }, recentNumbers.MostRecentFirst());

class RecentItems   // TODO: make me generic! (and replace `string` with T everywhere)
{
    private readonly List<string> _items = [];
    private readonly int _capacity;

    public RecentItems(int capacity) => _capacity = capacity;

    public int Count => _items.Count;

    public void Add(string item)
    {
        // TODO: add the item. If there are now more than _capacity items, remove the oldest.
    }

    public List<string> MostRecentFirst()
    {
        // TODO: return a NEW list with the newest item first.
        //       (Tip: lists have a Reverse() method, and `new List<T>(otherList)` makes a copy.)
    }
}
