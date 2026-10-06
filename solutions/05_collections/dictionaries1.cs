// dictionaries1.cs — solution

Dictionary<string, int> CountWords(string text)
{
    var counts = new Dictionary<string, int>();
    foreach (string word in text.ToLower().Split(' '))
    {
        counts[word] = counts.GetValueOrDefault(word) + 1;
    }
    return counts;
}

var counts = CountWords("The cat and the hat and the bat");

Check.Equal(3, counts["the"]);
Check.Equal(2, counts["and"]);
Check.Equal(1, counts["cat"]);
Check.Equal(5, counts.Count);

var menu = new Dictionary<string, decimal>
{
    ["coffee"] = 3.50m,
    ["tea"] = 2.75m,
};

decimal PriceOf(string item)
{
    if (menu.TryGetValue(item, out decimal price))
    {
        return price;
    }
    return -1;
}

Check.Equal(3.50m, PriceOf("coffee"));
Check.Equal(-1m, PriceOf("pizza"));
