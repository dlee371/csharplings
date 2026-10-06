// strings4.cs
//
// Real programs constantly pull data out of text. Split breaks a string into an
// array of pieces:
//
//     "a,b,c".Split(',')        // { "a", "b", "c" }
//     parts[0]                  // "a"
//     parts.Length              // 3
//
// Raw string literals (three or more quotes) let you write text containing
// quotes and newlines without any escaping. Handy for JSON, SQL, etc:
//
//     string json = """
//         { "name": "Ada" }
//         """;
//
// Parse the order line below.

// I AM NOT DONE

string orderLine = "Keyboard;3;49.99";

string[] parts = ???;
string product = parts[0];
int quantity = ???;
decimal unitPrice = ???;
decimal total = quantity * unitPrice;
string receipt = ???;

Console.WriteLine(receipt);
Check.Equal(3, parts.Length);
Check.Equal("Keyboard", product);
Check.Equal(3, quantity);
Check.Equal(49.99m, unitPrice);
Check.Equal("3 x Keyboard = $149.97", receipt);

string expectedJson = """{"product": "Keyboard", "quantity": 3}""";
// Build the same text from `product` and `quantity`. The text itself contains { and },
// so use a raw interpolated string with TWO dollar signs: $$"""...""".
// Then {{expression}} is an interpolation hole, and a single { is just a character.
string json = ???;
Check.Equal(expectedJson, json);
