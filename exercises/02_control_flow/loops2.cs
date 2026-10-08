// loops2.cs
//
// foreach visits every item in a collection:
//
//     int[] numbers = { 3, 8, 1 };    // an array: a fixed-size list of values
//     foreach (int n in numbers)
//     {
//         Console.WriteLine(n);
//     }
//
// Inside any loop:
//     break;      exits the loop immediately
//     continue;   skips the rest of this round and moves on to the next one
//
// % is the remainder operator: 7 % 2 == 1 and 8 % 2 == 0.
// So a number n is even when n % 2 == 0.



int[] readings = { 4, 7, 10, 3, -1, 8, 5 };

// 1. Add up only the ODD readings, but stop completely at the first negative one.
//    (The sensor sends -1 when it breaks; anything after it is garbage.)
int oddSum = 0;
foreach (int reading in readings)
{
    // use `break` and `continue` here
    if(reading % 2 == 1)
    {
        oddSum += reading;
    }
    else if(reading < 0)
    {
        break;
    }
    else
    {
        continue;
    }
}

// 2. Count how many readings are greater than 5 (all of them, including after the -1).
int bigCount = 0;
// write a loop here
foreach(int reading in readings)
{
    if(reading > 5)
    {
        bigCount++;
    }
}

Check.Equal(10, oddSum);    // 7 + 3
Check.Equal(3, bigCount);   // 7, 10, 8
