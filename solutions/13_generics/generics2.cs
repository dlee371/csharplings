// generics2.cs — solution

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

class RecentItems<T>
{
    private readonly List<T> _items = [];
    private readonly int _capacity;

    public RecentItems(int capacity) => _capacity = capacity;

    public int Count => _items.Count;

    public void Add(T item)
    {
        _items.Add(item);
        if (_items.Count > _capacity)
        {
            _items.RemoveAt(0);
        }
    }

    public List<T> MostRecentFirst()
    {
        var copy = new List<T>(_items);
        copy.Reverse();
        return copy;
    }
}
