// fizzbuzz.cs
//
// FizzBuzz! A famous (infamous?) interview warm-up. For a number n, return:
//
//   * "FizzBuzz" if n is divisible by both 3 and 5
//   * "Fizz"     if n is divisible by 3
//   * "Buzz"     if n is divisible by 5
//   * otherwise, the number itself as text (e.g. "7")
//
// "Divisible by 3" means n % 3 == 0. Think about which check has to come first!



string FizzBuzz(int n)
{
    if (n % 3 == 0 && n % 5 == 0)
    {
        return "FizzBuzz";
    }else if(n % 3 == 0)
    {
        return "Fizz";
    }else if(n % 5 == 0)
    {
        return "Buzz";
    }
    else
    {
        return n.ToString();
    }
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
