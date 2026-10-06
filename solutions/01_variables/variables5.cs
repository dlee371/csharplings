// variables5.cs — solution

string input = "42";
int parsed = int.Parse(input);
int sum = parsed + 8;

double average = 7.9;
int truncated = (int)average;
int rounded = (int)Math.Round(average);

int count = 3;
string message = count.ToString();

Check.Equal(50, sum);
Check.Equal(7, truncated);
Check.Equal(8, rounded);
Check.Equal("3", message);
