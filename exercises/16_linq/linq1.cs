// linq1.cs
//
// LINQ (Language Integrated Query) is one of C#'s superpowers: a set of methods
// that work on ANY collection (anything that's an IEnumerable<T>).
//
//     numbers.Where(n => n > 10)       // filter: keep the items where the lambda is true
//     numbers.Select(n => n * 2)       // transform each item (a.k.a. "map")
//     .ToList()  /  .ToArray()         // collect the results into a list or array
//
// They chain together into a readable pipeline:
//
//     List<string> adultNames = people
//         .Where(p => p.Age >= 18)
//         .Select(p => p.Name)
//         .ToList();
//
// You wrote MyWhere and MySelect yourself in lambdas2 — now you get the real thing!
//
// LINQ is *lazy*: nothing actually runs until you consume the results
// (with foreach, ToList(), Count(), ...).

// I AM NOT DONE

List<int> numbers = [5, 12, 8, 130, 44, 3, 7, 21];

List<int> bigOnes = ???;      // the numbers greater than 10
List<int> doubled = ???;      // every number times 2
List<string> labels = ???;    // only the even numbers, formatted like "#12"

Check.Equal(new List<int> { 12, 130, 44, 21 }, bigOnes);
Check.Equal(new List<int> { 10, 24, 16, 260, 88, 6, 14, 42 }, doubled);
Check.Equal(new List<string> { "#12", "#8", "#130", "#44" }, labels);

string[] words = ["  Apple", "banana ", "", " cherry", "   "];
string[] cleaned = ???;       // trim every word, drop the empty ones, and make them uppercase
Check.Equal(new[] { "APPLE", "BANANA", "CHERRY" }, cleaned);
