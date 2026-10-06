// variables5.cs
//
// Converting between types:
//
//   * Widening (no data can be lost) happens automatically:
//         int small = 5;
//         long big = small;
//
//   * Narrowing (data might be lost) needs an explicit *cast*:
//         double d = 7.9;
//         int i = (int)d;          // chops off the decimals — it does NOT round!
//
//   * Text → number:   int.Parse("42"), double.Parse("3.5"), decimal.Parse("9.99")
//   * Anything → text: value.ToString()

// I AM NOT DONE

string input = "42";
int parsed = input;          // turn the text into a number
int sum = parsed + 8;

double average = 7.9;
int truncated = average;     // use a cast
int rounded = (int)Math.Round(average);

int count = 3;
string message = count;      // turn the number into text

Check.Equal(50, sum);
Check.Equal(7, truncated);
Check.Equal(8, rounded);
Check.Equal("3", message);
