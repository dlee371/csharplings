// strings4.cs — solution

string orderLine = "Keyboard;3;49.99";

string[] parts = orderLine.Split(';');
string product = parts[0];
int quantity = int.Parse(parts[1]);
decimal unitPrice = decimal.Parse(parts[2]);
decimal total = quantity * unitPrice;
string receipt = $"{quantity} x {product} = ${total}";

Console.WriteLine(receipt);
Check.Equal(3, parts.Length);
Check.Equal("Keyboard", product);
Check.Equal(3, quantity);
Check.Equal(49.99m, unitPrice);
Check.Equal("3 x Keyboard = $149.97", receipt);

string expectedJson = """{"product": "Keyboard", "quantity": 3}""";
string json = $$"""{"product": "{{product}}", "quantity": {{quantity}}}""";
// With $$, interpolation holes use {{ }} — so single { } can appear as plain text.
Check.Equal(expectedJson, json);
