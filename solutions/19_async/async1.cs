// async1.cs — solution

async Task<int> FetchUserCountAsync()
{
    await Task.Delay(100);
    return 42;
}

async Task<string> GreetAsync(string name)
{
    await Task.Delay(50);
    return $"Hello, {name}!";
}

int count = await FetchUserCountAsync();
string greeting = await GreetAsync("Ada");

Check.Equal(42, count);
Check.Equal("Hello, Ada!", greeting);
