// generics1.cs
//
// Generics let you write code ONCE that works with many types. You've already
// been using generic types: List<int>, Dictionary<string, decimal>...
//
// A generic method has a *type parameter* in angle brackets. T is a placeholder
// for "whatever type the caller uses":
//
//     T FirstOr<T>(List<T> items, T fallback)
//     {
//         if (items.Count == 0) return fallback;
//         return items[0];
//     }
//
//     FirstOr(new List<int>(), 42)       // T is inferred to be int
//     FirstOr<string>(names, "none")     // or you can spell it out

// I AM NOT DONE

// TODO: make Swap generic so it works for any type, not just int.
void Swap(ref int a, ref int b)
{
    int temp = a;
    a = b;
    b = temp;
}

int x = 1, y = 2;
Swap(ref x, ref y);
Check.Equal((2, 1), (x, y));

string s1 = "left", s2 = "right";
Swap(ref s1, ref s2);
Check.Equal(("right", "left"), (s1, s2));

// TODO: write a generic method Repeat that returns a List containing `item` `count` times.
//       Repeat("ha", 3) → ["ha", "ha", "ha"]

Check.Equal(new List<string> { "ha", "ha", "ha" }, Repeat("ha", 3));
Check.Equal(new List<bool> { true, true }, Repeat(true, 2));
Check.Equal(0, Repeat(3.14, 0).Count);
