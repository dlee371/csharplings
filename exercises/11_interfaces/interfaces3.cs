// interfaces3.cs
//
// .NET is full of built-in interfaces. Implement one, and lots of framework
// features start working with your type. For example, IComparable<T> makes your
// type sortable:
//
//     int CompareTo(T other)
//         returns a negative number if `this` comes BEFORE `other`,
//                 zero if they're equal,
//                 a positive number if `this` comes AFTER `other`.
//
// Built-in types already implement it, so you can lean on them:
//     3.CompareTo(5)        // negative
//     "b".CompareTo("a")    // positive
//
// Other built-in interfaces you'll meet: IEquatable<T>, IDisposable, IEnumerable<T>.

// I AM NOT DONE

var versions = new List<SemVer>
{
    new(1, 10, 0),
    new(1, 2, 3),
    new(2, 0, 0),
    new(1, 2, 10),
};

versions.Sort();   // 💥 throws until SemVer implements IComparable<SemVer>

Check.Equal("1.2.3, 1.2.10, 1.10.0, 2.0.0", string.Join(", ", versions));
Check.True(new SemVer(1, 0, 0).CompareTo(new SemVer(1, 0, 0)) == 0);
Check.True(new SemVer(0, 9, 9).CompareTo(new SemVer(1, 0, 0)) < 0);

// A "semantic version" number like 1.2.3 (Major.Minor.Patch).
// TODO: implement IComparable<SemVer>: compare Major first; if equal, Minor; if equal, Patch.
//       Note that 1.10.0 is NEWER than 1.2.3 — compare numbers, not text!
class SemVer
{
    public int Major { get; }
    public int Minor { get; }
    public int Patch { get; }

    public SemVer(int major, int minor, int patch)
    {
        Major = major;
        Minor = minor;
        Patch = patch;
    }

    public override string ToString() => $"{Major}.{Minor}.{Patch}";
}
