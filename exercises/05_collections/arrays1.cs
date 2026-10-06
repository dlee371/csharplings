// arrays1.cs
//
// An array holds a FIXED number of items, all of the same type.
//
//     int[] scores = { 90, 85, 77 };      // create with values
//     int[] zeros = new int[5];           // five items, all 0
//     scores[0]                           // first item — indexes start at 0!
//     scores[^1]                          // last item
//     scores.Length                       // 3
//     scores[1..]                         // a new array from index 1 to the end: { 85, 77 }
//     scores[..2]                         // a new array of the first two: { 90, 85 }
//
// Reading or writing an index that doesn't exist throws an IndexOutOfRangeException.

// I AM NOT DONE

string[] planets = { "Mercury", "Venus", "Earth", "Mars", "Jupiter" };

string first = ???;
string last = ???;
int count = ???;
string[] innerPlanets = ???;   // the first four, using a range

// Arrays have a fixed size, but you can change the items:
int[] squares = new int[5];
for (int i = 0; i <= squares.Length; i++)   // 🐛 there's a bug on this line
{
    squares[i] = i * i;
}

Check.Equal("Mercury", first);
Check.Equal("Jupiter", last);
Check.Equal(5, count);
Check.Equal(new[] { "Mercury", "Venus", "Earth", "Mars" }, innerPlanets);
Check.Equal(new[] { 0, 1, 4, 9, 16 }, squares);
