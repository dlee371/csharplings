// nullable1.cs — solution

int? FindIndex(string[] items, string target)
{
    for (int i = 0; i < items.Length; i++)
    {
        if (items[i] == target)
        {
            return i;
        }
    }
    return null;
}

string[] colors = { "red", "green", "blue" };

Check.Equal(1, FindIndex(colors, "green"));
Check.Equal(null, FindIndex(colors, "purple"));

int? missing = FindIndex(colors, "purple");
int index = missing ?? 0;
Check.Equal(0, index);

int? count = null;
Check.False(count.HasValue);
