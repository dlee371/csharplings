// quiz1.cs
//
// 🧩 Quiz time! This one uses everything so far: variables, strings, if/switch,
// loops, methods and collections. No new concepts — just put them together.
//
// You're building a tiny gradebook for a teacher:
//
//   * Average(scores)   → the average of a list of scores, as a double.
//                         An empty list should give 0.
//   * Letter(average)   → "A" for 90 and up, "B" for 80+, "C" for 70+, "D" for 60+,
//                         and "F" for anything lower.
//   * Report(gradebook) → one line per student, in ALPHABETICAL order, like
//                             Ada: 92.5 (A)
//                         with the average shown to exactly 1 decimal place,
//                         and lines separated by "\n" (no newline after the last one).
//
// Tips: a list of strings can be sorted in place with list.Sort().
//       A dictionary's keys are available as dict.Keys.

// I AM NOT DONE

double Average(List<int> scores)
{
    ???
}

string Letter(double average)
{
    ???
}

string Report(Dictionary<string, List<int>> gradebook)
{
    ???
}

Check.Close(85.0, Average([80, 90]));
Check.Close(0.0, Average([]));
Check.Equal("A", Letter(90));
Check.Equal("B", Letter(89.9));
Check.Equal("C", Letter(70));
Check.Equal("D", Letter(65));
Check.Equal("F", Letter(12));

var gradebook = new Dictionary<string, List<int>>
{
    ["Linus"] = [70, 75, 71],
    ["Ada"] = [95, 90],
    ["Grace"] = [88, 91, 79],
};

Console.WriteLine(Report(gradebook));
Check.Equal("Ada: 92.5 (A)\nGrace: 86.0 (B)\nLinus: 72.0 (C)", Report(gradebook));
