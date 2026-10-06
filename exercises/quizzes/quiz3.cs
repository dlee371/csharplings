// quiz3.cs
//
// 🧩 Final quiz! You've joined a team that runs a web service, and your first
// ticket is to write a small log analyzer. Each log line looks like:
//
//     2026-03-14T10:15:02 GET /api/users 200 35ms
//     <timestamp>         <method> <path> <status> <duration>
//
// Your tasks:
//
//   1. Define:  record LogEntry(DateTime Timestamp, string Method, string Path, int Status, int DurationMs)
//
//   2. Write Parse(line): return a LogEntry, or null if the line is malformed
//      (wrong number of parts, a bad date, a bad number, a duration without "ms"...).
//      Useful: DateTime.TryParse, int.TryParse, EndsWith, and ranges like text[..^2].
//
//   3. Write BuildReport(entries) using LINQ. The Report record is already defined below.
//        - ServerErrors: requests with a status from 500 to 599
//        - MostRequestedPath: the path that appears most often
//        - PathsWithErrors: distinct paths that had a 5xx error, alphabetically
//        - RequestsByMethod: how many requests used each method ("GET" → 6, ...)
//        - Slowest: the entry with the highest duration
//
// Use whatever you've learned — there are many correct solutions!

// I AM NOT DONE

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
    ???
}

Report BuildReport(List<LogEntry> entries)
{
    ???
}

// --- Parsing ---
Check.Equal(new LogEntry(new DateTime(2026, 3, 14, 10, 15, 2), "GET", "/api/users", 200, 35), Parse(lines[0]));
Check.Equal(null, Parse("garbage line"));
Check.Equal(null, Parse("2026-03-14T10:15:02 GET /api/users 200"));
Check.Equal(null, Parse("yesterday GET /api/users 200 35ms"));
Check.Equal(null, Parse("2026-03-14T10:15:02 GET /api/users 200 35s"));

List<LogEntry> entries = lines.Select(Parse).OfType<LogEntry>().ToList();   // OfType skips the nulls
Check.Equal(8, entries.Count);

// --- Report ---
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

// TODO: define the LogEntry record here

record Report(
    int TotalRequests,
    int ServerErrors,
    double AverageDurationMs,
    string MostRequestedPath,
    List<string> PathsWithErrors,
    Dictionary<string, int> RequestsByMethod,
    LogEntry Slowest);
