// classes4.cs — solution

var book = new Book { Title = "The Pragmatic Programmer", Author = "Hunt & Thomas", Year = 1999 };

Console.WriteLine(book);
Check.Equal("The Pragmatic Programmer by Hunt & Thomas (1999)", book.ToString());
Check.Equal("Book: The Pragmatic Programmer by Hunt & Thomas (1999)", $"Book: {book}");

var draft = new Book { Title = "Untitled", Author = "Me" };
Check.Equal(0, draft.Pages);

class Book
{
    public required string Title { get; init; }
    public required string Author { get; init; }
    public int Year { get; init; }
    public int Pages { get; init; }

    public override string ToString() => $"{Title} by {Author} ({Year})";
}
