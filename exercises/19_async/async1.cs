// async1.cs
//
// Much of a program's time is spent WAITING: for a web request, a database, a
// file. async/await lets your code wait without blocking a thread:
//
//     async Task<string> DownloadAsync(string url)
//     {
//         using var http = new HttpClient();
//         string html = await http.GetStringAsync(url);   // pause here; the thread is free meanwhile
//         return html;
//     }
//
//   * An async method returns `Task` (no result) or `Task<T>` (a result of type T).
//   * Inside it, `await` a task to pause until it finishes and get its result.
//   * Only async methods can use await. (Top-level code, like this file, can too.)
//   * By convention, async method names end in "Async".
//
// Task.Delay(milliseconds) is an async "sleep" — we use it here to fake slow work.

// I AM NOT DONE

int FetchUserCount()
{
    await Task.Delay(100);   // pretend we're querying a database
    return 42;
}

Task<string> GreetAsync(string name)
{
    await Task.Delay(50);
    return $"Hello, {name}!";
}

int count = FetchUserCount();
string greeting = GreetAsync("Ada");

Check.Equal(42, count);
Check.Equal("Hello, Ada!", greeting);
