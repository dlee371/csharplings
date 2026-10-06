// quiz3.cs — solution

string[] lines =
[
    "2026-03-14T10:15:02 GET /api/users 200 35ms",
    "2026-03-14T10:15:04 POST /api/orders 201 120ms",
    "2026-03-14T10:15:09 GET /api/users 200 25ms",
    "garbage line",
    "2026-03-14T10:16:00 GET /api/orders 500 300ms",
    "2026-03-14T10:16:30 GET /api/users 404 5ms",
    "2026-03-14T10:17:00 DELETE /api/orders/7 204 60ms",
    "2026-03-14T10:17:05 GET /api/users abc 10ms",
    "2026-03-14T10:18:00 GET /api/orders 500 280ms",
    "2026-03-14T10:19:00 GET /api/users 200 40ms",
];

LogEntry? Parse(string line)
{
    string[] parts = line.Split(' ');
    if (parts.Length != 5) return null;
    if (!DateTime.TryParse(parts[0], out DateTime timestamp)) return null;
    if (!int.TryParse(parts[3], out int status)) return null;
    if (!parts[4].EndsWith("ms") || !int.TryParse(parts[4][..^2], out int duration)) return null;
    return new LogEntry(timestamp, parts[1], parts[2], status, duration);
}

Report BuildReport(List<LogEntry> entries)
{
    var serverErrors = entries.Where(e => e.Status is >= 500 and <= 599).ToList();

    return new Report(
        TotalRequests: entries.Count,
        ServerErrors: serverErrors.Count,
        AverageDurationMs: entries.Average(e => e.DurationMs),
        MostRequestedPath: entries.GroupBy(e => e.Path).OrderByDescending(g => g.Count()).First().Key,
        PathsWithErrors: serverErrors.Select(e => e.Path).Distinct().Order().ToList(),
        RequestsByMethod: entries.GroupBy(e => e.Method).ToDictionary(g => g.Key, g => g.Count()),
        Slowest: entries.MaxBy(e => e.DurationMs)!);   // MaxBy returns null only for an empty list
}

Check.Equal(new LogEntry(new DateTime(2026, 3, 14, 10, 15, 2), "GET", "/api/users", 200, 35), Parse(lines[0]));
Check.Equal(null, Parse("garbage line"));
Check.Equal(null, Parse("2026-03-14T10:15:02 GET /api/users 200"));
Check.Equal(null, Parse("yesterday GET /api/users 200 35ms"));
Check.Equal(null, Parse("2026-03-14T10:15:02 GET /api/users 200 35s"));

List<LogEntry> entries = lines.Select(Parse).OfType<LogEntry>().ToList();
Check.Equal(8, entries.Count);

var report = BuildReport(entries);
Check.Equal(8, report.TotalRequests);
Check.Equal(2, report.ServerErrors);
Check.Close(108.125, report.AverageDurationMs);
Check.Equal("/api/users", report.MostRequestedPath);
Check.Equal(new[] { "/api/orders" }, report.PathsWithErrors);
Check.Equal(6, report.RequestsByMethod["GET"]);
Check.Equal(1, report.RequestsByMethod["POST"]);
Check.Equal(1, report.RequestsByMethod["DELETE"]);
Check.Equal(300, report.Slowest.DurationMs);

Console.WriteLine($"""
    📊 {report.TotalRequests} requests, {report.ServerErrors} server errors
       average {report.AverageDurationMs:F1}ms, slowest: {report.Slowest.Method} {report.Slowest.Path}
    """);

record LogEntry(DateTime Timestamp, string Method, string Path, int Status, int DurationMs);

record Report(
    int TotalRequests,
    int ServerErrors,
    double AverageDurationMs,
    string MostRequestedPath,
    List<string> PathsWithErrors,
    Dictionary<string, int> RequestsByMethod,
    LogEntry Slowest);
