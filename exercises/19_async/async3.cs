// async3.cs
//
// Long-running async work should be *cancellable* — say, when a user closes the
// page or a request times out. .NET uses a CancellationToken for this:
//
//     async Task WorkAsync(CancellationToken ct)
//     {
//         await Task.Delay(1000, ct);           // most async APIs accept a token
//         ct.ThrowIfCancellationRequested();     // or you can check it yourself
//     }
//
//     using var cts = new CancellationTokenSource(TimeSpan.FromMilliseconds(200)); // cancels itself after 200ms
//     await WorkAsync(cts.Token);    // throws an OperationCanceledException once cancelled
//
// Exceptions from async methods come out where you `await` them, so a normal
// try/catch around the await works.
//
// ⚠️ Avoid `async void` methods (except UI event handlers). Nobody can await
//    them, and nobody can catch their exceptions.

// I AM NOT DONE

async Task<int> CountSlowlyAsync(int upTo, CancellationToken ct)
{
    int count = 0;
    for (int i = 0; i < upTo; i++)
    {
        await Task.Delay(50);   // 🐛 pass the token along, so cancelling stops the delay
        count++;
    }
    return count;
}

// 1. This one is allowed to finish.
Check.Equal(3, await CountSlowlyAsync(3, CancellationToken.None));

// 2. Counting to 1000 would take ~50 seconds. Cancel it after 200ms!
//    TODO: create a CancellationTokenSource that cancels after 200ms, and pass its token.
var sw = System.Diagnostics.Stopwatch.StartNew();
await Check.ThrowsAsync<OperationCanceledException>(() => CountSlowlyAsync(1000, ???));
Check.True(sw.ElapsedMilliseconds < 2000);

// 3. Return the count, or -1 if it got cancelled. Use try/catch.
async Task<int> CountOrGiveUpAsync(int upTo, int timeoutMs)
{
    using var cts = new CancellationTokenSource(timeoutMs);
    return await CountSlowlyAsync(upTo, cts.Token);
}

Check.Equal(2, await CountOrGiveUpAsync(2, 1000));
Check.Equal(-1, await CountOrGiveUpAsync(1000, 200));
