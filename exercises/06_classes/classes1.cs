// classes1.cs
//
// A class is a blueprint for objects. It bundles data (fields) with behavior (methods).
//
//     class Dog
//     {
//         public string Name;                    // a field
//
//         public Dog(string name)                // a constructor: runs on `new Dog(...)`
//         {
//             Name = name;
//         }
//
//         public string Bark() => $"{Name} says woof!";   // a method
//     }
//
//     var rex = new Dog("Rex");      // create an object (an "instance" of Dog)
//     rex.Bark();                    // "Rex says woof!"
//
// `public` means code outside the class can use it. Members without an access
// modifier are `private`: only code inside the class can see them.

// I AM NOT DONE

var counter = new Counter("clicks");
counter.Increment();
counter.Increment();
counter.Increment();
counter.Reset();
counter.Increment();

Check.Equal("clicks", counter.Name);
Check.Equal(1, counter.Value);
Check.Equal("clicks: 1", counter.Describe());

class Counter
{
    public string Name;
    int Value;

    // TODO: a constructor that takes the name

    // TODO: Increment() adds 1 to Value

    // TODO: Reset() sets Value back to 0

    // TODO: Describe() returns text like "clicks: 1"
}
