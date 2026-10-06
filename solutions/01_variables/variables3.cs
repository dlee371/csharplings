// variables3.cs — solution

int score = 0;
Console.WriteLine($"Starting score: {score}");

score = score + 10;
score += 10;
Console.WriteLine($"Final score: {score}");

Check.Equal(20, score);
