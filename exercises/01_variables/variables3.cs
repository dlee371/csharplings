// variables3.cs
//
// `const` declares a value that can NEVER change, like MaxPlayers or TaxRate.
// A normal variable can be given a new value with `=`.
//
//     const int MaxPlayers = 4;   // fixed forever
//     int lives = 3;
//     lives = lives - 1;          // fine
//     lives -= 1;                 // shorthand for the line above (also +=, *=, /=)
//
// The score in this game needs to change. Fix it!

// I AM NOT DONE

const int score = 0;
Console.WriteLine($"Starting score: {score}");

score = score + 10;
score += 10;
Console.WriteLine($"Final score: {score}");

Check.Equal(20, score);
