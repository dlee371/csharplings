// async2.cs — solution

async Task<decimal> GetPriceAsync(string product)
{
    await Task.Delay(500);
    return product.Length * 1.5m;
}

var timer = System.Diagnostics.Stopwatch.StartNew();

string[] products = { "coffee", "tea", "cake", "cookie" };
Task<decimal>[] tasks = products.Select(p => GetPriceAsync(p)).ToArray();   // start them all
decimal[] results = await Task.WhenAll(tasks);                               // wait for all
var prices = results.ToList();

timer.Stop();
Console.WriteLine($"Took {timer.ElapsedMilliseconds}ms");

Check.Equal(new List<decimal> { 9.0m, 4.5m, 6.0m, 9.0m }, prices);
Check.True(timer.ElapsedMilliseconds < 1000);
