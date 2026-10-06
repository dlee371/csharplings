using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Csharplings;

public sealed record Exercise(string Name, string Path, string Hint, bool Strict = false)
{
    static readonly Regex Marker = new(@"^\s*//\s*I AM NOT DONE\s*$", RegexOptions.Multiline);

    public string FullPath(string root) => System.IO.Path.Combine(root, Path);

    public string ReadSource(string root) => File.ReadAllText(FullPath(root));

    public static bool HasMarker(string source) => Marker.IsMatch(source);

    public static string Hash(string source) =>
        Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(source)));
}

public sealed class ExerciseList
{
    sealed record InfoFile(List<Exercise> Exercises);

    public static List<Exercise> Load(string root)
    {
        var json = File.ReadAllText(System.IO.Path.Combine(root, "info.json"));
        var info = JsonSerializer.Deserialize<InfoFile>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                   ?? throw new InvalidDataException("info.json is empty");
        return info.Exercises;
    }
}

/// <summary>Remembers which exact file contents already passed, so finished exercises aren't re-run every time.</summary>
public sealed class ProgressCache
{
    readonly string _file;
    readonly Dictionary<string, string> _passed;

    public ProgressCache(string root)
    {
        _file = System.IO.Path.Combine(root, ".csharplings", "passed.json");
        _passed = File.Exists(_file)
            ? JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText(_file)) ?? new()
            : new();
    }

    public bool IsKnownPass(Exercise ex, string source) =>
        _passed.TryGetValue(ex.Name, out var hash) && hash == Exercise.Hash(source);

    public void RecordPass(Exercise ex, string source)
    {
        _passed[ex.Name] = Exercise.Hash(source);
        Directory.CreateDirectory(System.IO.Path.GetDirectoryName(_file)!);
        File.WriteAllText(_file, JsonSerializer.Serialize(_passed, new JsonSerializerOptions { WriteIndented = true }));
    }
}
