// async3.cs — solution

async Task<int> CountSlowlyAsync(int upTo, CancellationToken ct)
{
    int count = 0;
    for (int i = 0; i < upTo; i++)
    {
        await Task.Delay(50, ct);
        count++;
    }
    return count;
}

Check.Equal(3, await CountSlowlyAsync(3, CancellationToken.None));

var sw = System.Diagnostics.Stopwatch.StartNew();
using var cts = new CancellationTokenSource(TimeSpan.FromMilliseconds(200));
await Check.ThrowsAsync<OperationCanceledException>(() => CountSlowlyAsync(1000, cts.Token));
Check.True(sw.ElapsedMilliseconds < 2000);

async Task<int> CountOrGiveUpAsync(int upTo, int timeoutMs)
{
    using var cts = new CancellationTokenSource(timeoutMs);
    try
    {
        return await CountSlowlyAsync(upTo, cts.Token);
    }
    catch (OperationCanceledException)
    {
        return -1;
    }
}

Check.Equal(2, await CountOrGiveUpAsync(2, 1000));
Check.Equal(-1, await CountOrGiveUpAsync(1000, 200));
