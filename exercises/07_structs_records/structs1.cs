// structs1.cs
//
// Classes are *reference types*. A class variable holds a reference — think of
// it as an arrow pointing at the object. Copying the variable copies the ARROW,
// so both variables point at the SAME object.
//
// Structs are *value types*. A struct variable holds the data itself. Copying it
// copies all the data. int, double, bool, char, DateTime... are all structs.
//
//     var a = new PointClass(1, 2);   var b = a;   b.X = 99;   // a.X is now 99 too!
//     var c = new PointStruct(1, 2);  var d = c;   d.X = 99;   // c.X is still 1
//
// Use structs for small, simple values (coordinates, colors, money amounts).
// Use classes for almost everything else.

// I AM NOT DONE

var original = new Point(1, 2);
var copy = original;
copy.X = 99;

// We want Point to behave like a value, so changing `copy` leaves `original` alone.
// Change ONE word in this file to make these checks pass.
Check.Equal(1, original.X);
Check.Equal(99, copy.X);

// List<T> is a class — a reference type. Predict the answer before running it!
var list1 = new List<int> { 1, 2, 3 };
var list2 = list1;
list2.Add(4);
Check.Equal(???, list1.Count);

class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}
