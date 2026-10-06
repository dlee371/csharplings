// loops2.cs — solution

int[] readings = { 4, 7, 10, 3, -1, 8, 5 };

int oddSum = 0;
foreach (int reading in readings)
{
    if (reading < 0)
    {
        break;
    }
    if (reading % 2 == 0)
    {
        continue;
    }
    oddSum += reading;
}

int bigCount = 0;
foreach (int reading in readings)
{
    if (reading > 5)
    {
        bigCount++;
    }
}

Check.Equal(10, oddSum);
Check.Equal(3, bigCount);
