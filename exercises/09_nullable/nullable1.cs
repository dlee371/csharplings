// nullable1.cs
//
// A normal int ALWAYS has a value. Sometimes you need "no value at all" — say,
// a user who hasn't entered their age yet. Add ? to the type to allow null:
//
//     int? age = null;
//     age.HasValue               // false
//     age ?? 0                   // 0  — `??` means "if the left side is null, use the right side"
//     age.GetValueOrDefault()    // 0
//     age = 36;
//     age.Value                  // 36 (but throws if age is null!)
//
// null is MUCH clearer than "magic" values like -1 or 0 meaning "nothing".

// I AM NOT DONE

int? FindIndex(string[] items, string target)
{
    for (int i = 0; i < items.Length; i++)
    {
        if (items[i] == target)
        {
            return i;
        }
    }
    return -1;   // 🐛 "not found" should be null, not a fake number
}

string[] colors = { "red", "green", "blue" };

Check.Equal(1, FindIndex(colors, "green"));
Check.Equal(null, FindIndex(colors, "purple"));

int? missing = FindIndex(colors, "purple");
int index = ???;   // use ?? so that a missing color gives 0
Check.Equal(0, index);

int count = null;
Check.False(count.HasValue);
