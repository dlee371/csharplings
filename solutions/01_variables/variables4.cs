// variables4.cs — solution

decimal price = 19.99m;
bool isOnSale = true;
char initial = 'D';
string greeting = "Hello";
long worldPopulation = 8_100_000_000;
double temperature = -3.5;

Check.Equal(19.99m, price);
Check.Equal(true, isOnSale);
Check.Equal('D', initial);
Check.Equal("Hello", greeting);
Check.Equal(8_100_000_000L, worldPopulation);
Check.Equal(-3.5, temperature);
