// interfaces3.cs — solution

var versions = new List<SemVer>
{
    new(1, 10, 0),
    new(1, 2, 3),
    new(2, 0, 0),
    new(1, 2, 10),
};

versions.Sort();

Check.Equal("1.2.3, 1.2.10, 1.10.0, 2.0.0", string.Join(", ", versions));
Check.True(new SemVer(1, 0, 0).CompareTo(new SemVer(1, 0, 0)) == 0);
Check.True(new SemVer(0, 9, 9).CompareTo(new SemVer(1, 0, 0)) < 0);

class SemVer : IComparable<SemVer>
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

    public int CompareTo(SemVer? other)
    {
        if (other is null) return 1;   // by convention, everything comes after null
        if (Major != other.Major) return Major.CompareTo(other.Major);
        if (Minor != other.Minor) return Minor.CompareTo(other.Minor);
        return Patch.CompareTo(other.Patch);
    }

    public override string ToString() => $"{Major}.{Minor}.{Patch}";
}
