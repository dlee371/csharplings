// strings3.cs — solution

var sb = new StringBuilder();
for (int i = 1; i <= 5; i++)
{
    sb.Append(i);
    if (i < 5)
    {
        sb.Append('-');
    }
}
string countdown = sb.ToString();

string[] fruits = { "apple", "banana", "cherry" };
string fruitList = string.Join(", ", fruits);

Check.Equal("1-2-3-4-5", countdown);
Check.Equal("apple, banana, cherry", fruitList);
