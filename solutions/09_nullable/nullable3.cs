// nullable3.cs — solution

var users = new UserDirectory();
users.Add("ada", "Ada Lovelace");

Check.Equal("Ada Lovelace", users.FindName("ada"));
Check.Equal(null, users.FindName("bob"));
Check.Equal("ADA LOVELACE", users.Shout("ada"));
Check.Equal("NOBODY", users.Shout("bob"));
Check.Equal(12, users.NameLength("ada"));
Check.Equal(0, users.NameLength("bob"));
Check.Equal("bob", users.LastLookup);

class UserDirectory
{
    private readonly Dictionary<string, string> _names = new();

    public string? LastLookup { get; private set; }

    public void Add(string id, string name) => _names[id] = name;

    public string? FindName(string id)
    {
        LastLookup = id;
        return _names.GetValueOrDefault(id);
    }

    public string Shout(string id)
    {
        string? name = FindName(id);
        if (name is null)
        {
            return "NOBODY";
        }
        return name.ToUpper();
    }

    public int NameLength(string id) => FindName(id)?.Length ?? 0;
}
