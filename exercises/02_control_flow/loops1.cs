// loops1.cs
//
// Loops repeat code.
//
//     for (int i = 0; i < 5; i++)     // start; keep going while this is true; after each round
//     {
//         Console.WriteLine(i);       // prints 0 1 2 3 4
//     }
//
//     while (condition)               // repeats as long as condition is true
//     {
//         ...
//     }
//
// i++ means "add 1 to i", i-- means "subtract 1".
//
// Watch out: dividing two ints gives an int — the remainder is thrown away. 7 / 2 == 3

// I AM NOT DONE

// 1. Add up all the numbers from 1 to 100 (inclusive) with a for loop.
int sum = 0;
for (???)
{
    sum += i;
}

// 2. How many times can you halve 1000 (using integer division) before it reaches 0?
//    1000 → 500 → 250 → 125 → 62 → 31 → 15 → 7 → 3 → 1 → 0
int value = 1000;
int halvings = 0;
while (value > 0)
{
    value = value / 2;
    // something's missing here...
}

Console.WriteLine($"Sum: {sum}, halvings: {halvings}");
Check.Equal(5050, sum);
Check.Equal(10, halvings);
