// variables4.cs
//
// The most common built-in types:
//
//     int      whole numbers               42, -7
//     long     BIG whole numbers           9_000_000_000   (underscores just help readability)
//     double   decimal numbers (fast)      3.14
//     decimal  exact decimal numbers       19.99m          ← the m suffix. Use decimal for money!
//     bool     true or false
//     char     a single character          'A'             ← single quotes
//     string   text                        "Hello"         ← double quotes
//
// Each variable below has the wrong type for its value. Fix the TYPES only —
// don't change the values or the checks.



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
