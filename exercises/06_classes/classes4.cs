// classes4.cs
//
// Class features you'll see in every modern codebase:
//
//   * `init` accessor: the property can only be set while the object is being created.
//   * `required`: callers MUST set this property when creating the object.
//   * Object initializers set properties right after construction:
//
//         var p = new Person { Name = "Ada", Age = 36 };
//
//   * Every class inherits a ToString() method. By default it just returns the
//     class name, which isn't very useful. `override` it:
//
//         public override string ToString() => $"{Name} ({Age})";
//
//     String interpolation and Console.WriteLine call ToString() automatically.
//
// ⚠️ In this exercise, compiler WARNINGS count as errors. Watch for warning CS8618:
//    a non-nullable string property that might never be set. `required` fixes that!

// I AM NOT DONE

var book = new Book { Title = "The Pragmatic Programmer", Author = "Hunt & Thomas", Year = 1999 };

Console.WriteLine(book);
Check.Equal("The Pragmatic Programmer by Hunt & Thomas (1999)", book.ToString());
Check.Equal("Book: The Pragmatic Programmer by Hunt & Thomas (1999)", $"Book: {book}");

var draft = new Book { Title = "Untitled", Author = "Me" };   // Year and Pages are optional
Check.Equal(0, draft.Pages);

// var broken = new Book { Year = 2000 };
// ↑ Once you're done, uncomment this: it should NOT compile, because Title and
//   Author are required. Then put the comment back.

class Book
{
    public string Title { get; }
    public string Author { get; }
    public int Year { get; }
    public int Pages { get; }
}
