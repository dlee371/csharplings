// strings2.cs
//
// Strings come with lots of useful methods and properties. Some favorites:
//
//     s.Length               number of characters (a property, so no parentheses)
//     s.ToUpper()            "abc" → "ABC"        (also ToLower())
//     s.Trim()               removes whitespace from both ends
//     s.Contains("x")        true / false         (also StartsWith, EndsWith)
//     s.Replace("a", "b")    replaces every "a" with "b"
//     s.IndexOf("x")         position of "x", or -1 if it isn't there
//     s[0]                   the first character (a char). Indexes start at 0!
//     s[^1]                  the last character
//     s[2..5]                a "range": characters at index 2, 3 and 4 (not 5)
//
// Strings are *immutable*: these methods return a NEW string. The original never changes.

// I AM NOT DONE

string raw = "   Learning C# is fun!   ";

string trimmed = raw;            // 1. remove the extra spaces
string shouting = trimmed;       // 2. make `trimmed` all uppercase
int length = 0;                  // 3. how many characters are in `trimmed`?
bool mentionsCSharp = false;     // 4. does `trimmed` contain "C#"?
char firstLetter = ' ';          // 5. the first character of `trimmed`
string language = "";            // 6. get "C#" out of `trimmed` using a range [start..end]
string happier = trimmed;        // 7. replace "fun" with "awesome"

Check.Equal("Learning C# is fun!", trimmed);
Check.Equal("LEARNING C# IS FUN!", shouting);
Check.Equal(19, length);
Check.True(mentionsCSharp);
Check.Equal('L', firstLetter);
Check.Equal("C#", language);
Check.Equal("Learning C# is awesome!", happier);
Check.Equal("   Learning C# is fun!   ", raw);   // the original is unchanged!
