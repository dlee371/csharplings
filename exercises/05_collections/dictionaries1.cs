// dictionaries1.cs
//
// Dictionary<TKey, TValue> maps keys to values, with very fast lookups by key.
//
//     var ages = new Dictionary<string, int>();
//     ages["Ada"] = 36;                       // add, or overwrite if it exists
//     ages.Add("Grace", 45);                  // add (throws if the key already exists!)
//     int a = ages["Ada"];                    // read (throws KeyNotFoundException if missing!)
//     ages.ContainsKey("Linus")               // false
//     ages.TryGetValue("Linus", out int x)    // safe read: false if missing (x is then 0)
//     ages.GetValueOrDefault("Linus")         // 0 (the default for int) if missing
//     ages.Count                              // number of entries
//
//     foreach (var (name, age) in ages) { ... }   // loop over key/value pairs
//
// Counting words is a classic interview question. Let's do it!

// I AM NOT DONE

Dictionary<string, int> CountWords(string text)
{
    var counts = new Dictionary<string, int>();
    foreach (string word in text.ToLower().Split(' '))
    {
        // Add 1 to this word's count. Careful: the first time you see a word,
        // it isn't in the dictionary yet!
        counts[word] = counts[word] + 1;
    }
    return counts;
}

var counts = CountWords("The cat and the hat and the bat");

Check.Equal(3, counts["the"]);
Check.Equal(2, counts["and"]);
Check.Equal(1, counts["cat"]);
Check.Equal(5, counts.Count);

// Look up a price safely, returning -1 when the item isn't on the menu.
var menu = new Dictionary<string, decimal>
{
    ["coffee"] = 3.50m,
    ["tea"] = 2.75m,
};

decimal PriceOf(string item)
{
    return menu[item];
}

Check.Equal(3.50m, PriceOf("coffee"));
Check.Equal(-1m, PriceOf("pizza"));
