// loops1.cs — solution

int sum = 0;
for (int i = 1; i <= 100; i++)
{
    sum += i;
}

int value = 1000;
int halvings = 0;
while (value > 0)
{
    value = value / 2;
    halvings++;
}

Console.WriteLine($"Sum: {sum}, halvings: {halvings}");
Check.Equal(5050, sum);
Check.Equal(10, halvings);
