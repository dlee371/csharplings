// lists1.cs
//
// List<T> is like an array that can grow and shrink. The <T> says what type of
// items it holds: List<string>, List<int>, ... (This is a *generic* type — more
// on generics later.)
//
//     var names = new List<string>();      // an empty list
//     List<int> nums = [1, 2, 3];          // a "collection expression"
//     names.Add("Ada");                    // add to the end
//     names.Insert(0, "Grace");            // insert at an index
//     names.Remove("Ada");                 // remove the first match
//     names.RemoveAt(0);                   // remove by index
//     names.Contains("Ada")                // true / false
//     names.IndexOf("Ada")                 // its index, or -1 if not found
//     names.Count                          // number of items (Count, not Length!)
//     names[0]                             // read or write by index, like an array

// I AM NOT DONE

var todo = new List<string>();

// 1. Add "write code", "test code", "ship it" (in that order).

// 2. Oops, we forgot something. Insert "drink coffee" at the very start.

// 3. We're not testing today 🙈. Remove "test code".

Check.Equal(3, todo.Count);
Check.Equal(new List<string> { "drink coffee", "write code", "ship it" }, todo);
Check.Equal(1, todo.IndexOf("write code"));

// 4. Fill `evens` with every even number from `numbers` (use a loop).
List<int> numbers = [5, 12, 7, 8, 3, 20];
List<int> evens = [];

Check.Equal(new List<int> { 12, 8, 20 }, evens);
