// async2.cs
//
// The real power of async: doing several things AT THE SAME TIME.
//
//     Task<int> a = GetAAsync();       // start A — but don't await it yet!
//     Task<int> b = GetBAsync();       // start B while A is still running
//     int[] results = await Task.WhenAll(a, b);   // now wait for both
//
// Awaiting one after another takes (time A + time B).
// Starting both and using WhenAll takes only max(time A, time B).
//
// Combine with LINQ to start a task for every item in a collection:
//
//     Task<int>[] tasks = items.Select(item => ProcessAsync(item)).ToArray();

// I AM NOT DONE

async Task<decimal> GetPriceAsync(string product)
{
    await Task.Delay(500);   // each price lookup takes half a second
    return product.Length * 1.5m;
}

var timer = System.Diagnostics.Stopwatch.StartNew();

string[] products = { "coffee", "tea", "cake", "cookie" };
var prices = new List<decimal>();
foreach (string product in products)
{
    prices.Add(await GetPriceAsync(product));   // 🐢 one at a time: 4 × 0.5s = 2 seconds
}

timer.Stop();
Console.WriteLine($"Took {timer.ElapsedMilliseconds}ms");

Check.Equal(new List<decimal> { 9.0m, 4.5m, 6.0m, 9.0m }, prices);
Check.True(timer.ElapsedMilliseconds < 1000);   // must finish in under a second!
