// fizzbuzz.cs — solution

string FizzBuzz(int n)
{
    if (n % 15 == 0)   // divisible by 3 AND 5 — must be checked first!
    {
        return "FizzBuzz";
    }
    if (n % 3 == 0)
    {
        return "Fizz";
    }
    if (n % 5 == 0)
    {
        return "Buzz";
    }
    return n.ToString();
}

for (int i = 1; i <= 15; i++)
{
    Console.WriteLine(FizzBuzz(i));
}

Check.Equal("1", FizzBuzz(1));
Check.Equal("Fizz", FizzBuzz(3));
Check.Equal("Buzz", FizzBuzz(5));
Check.Equal("7", FizzBuzz(7));
Check.Equal("Fizz", FizzBuzz(9));
Check.Equal("Buzz", FizzBuzz(10));
Check.Equal("FizzBuzz", FizzBuzz(15));
Check.Equal("FizzBuzz", FizzBuzz(90));
