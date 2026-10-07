// variables2.cs
//
// C# won't let you read a variable before you've given it a value.
// Other languages might hand you garbage or a surprise default — C# refuses to
// compile instead. This saves you from a whole category of bugs!



int number = 11;
Console.WriteLine("hello?");

if (number > 10)
{
    Console.WriteLine("Big number!");
}
else
{
    Console.WriteLine("Small number!");
}

Check.True(number > 10);
