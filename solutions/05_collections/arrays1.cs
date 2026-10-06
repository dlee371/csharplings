// arrays1.cs — solution

string[] planets = { "Mercury", "Venus", "Earth", "Mars", "Jupiter" };

string first = planets[0];
string last = planets[^1];
int count = planets.Length;
string[] innerPlanets = planets[..4];

int[] squares = new int[5];
for (int i = 0; i < squares.Length; i++)   // < not <= : the last valid index is Length - 1
{
    squares[i] = i * i;
}

Check.Equal("Mercury", first);
Check.Equal("Jupiter", last);
Check.Equal(5, count);
Check.Equal(new[] { "Mercury", "Venus", "Earth", "Mars" }, innerPlanets);
Check.Equal(new[] { 0, 1, 4, 9, 16 }, squares);
