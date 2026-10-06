// strings2.cs — solution

string raw = "   Learning C# is fun!   ";

string trimmed = raw.Trim();
string shouting = trimmed.ToUpper();
int length = trimmed.Length;
bool mentionsCSharp = trimmed.Contains("C#");
char firstLetter = trimmed[0];
string language = trimmed[9..11];   // or: trimmed.Substring(9, 2)
string happier = trimmed.Replace("fun", "awesome");

Check.Equal("Learning C# is fun!", trimmed);
Check.Equal("LEARNING C# IS FUN!", shouting);
Check.Equal(19, length);
Check.True(mentionsCSharp);
Check.Equal('L', firstLetter);
Check.Equal("C#", language);
Check.Equal("Learning C# is awesome!", happier);
Check.Equal("   Learning C# is fun!   ", raw);
