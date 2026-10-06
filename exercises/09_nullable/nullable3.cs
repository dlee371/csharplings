// nullable3.cs
//
// In this exercise, nullable WARNINGS are treated as ERRORS — many teams do this
// in real projects (<TreatWarningsAsErrors>true</TreatWarningsAsErrors>).
//
// Make the compiler happy by being honest about what can be null:
//   * mark things that can be null with `?`
//   * handle the null case where they're used
//
// The compiler understands null checks, and narrows the type after them:
//
//     if (name is null) return "nobody";
//     return name.ToUpper();      // fine: here the compiler knows name isn't null
//
// ⚠️ No cheating with the `!` "null-forgiving" operator (name!.ToUpper()). It just
//    tells the compiler to stop warning — it doesn't make the code any safer.

// I AM NOT DONE

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

    // The id most recently looked up — there isn't one until the first lookup!
    public string LastLookup { get; private set; }

    public void Add(string id, string name) => _names[id] = name;

    // Returns the user's name, or null if there's no such user.
    public string FindName(string id)
    {
        LastLookup = id;
        return _names.GetValueOrDefault(id);
    }

    // Returns the name in uppercase, or "NOBODY" if there's no such user.
    public string Shout(string id)
    {
        string name = FindName(id);
        return name.ToUpper();
    }

    // Returns the length of the name, or 0 if there's no such user.
    public int NameLength(string id) => FindName(id).Length;
}
