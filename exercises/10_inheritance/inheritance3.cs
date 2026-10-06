// inheritance3.cs
//
// An `abstract` class can't be created directly — it only exists to be a base
// for other classes. An `abstract` member has no body, and every non-abstract
// subclass MUST override it:
//
//     abstract class Shape
//     {
//         public abstract double Area();                     // no body!
//         public string Describe() => $"Area: {Area():F1}";  // can still call it
//     }
//
//     new Shape()     // ❌ compile error: Shape is abstract
//
// GetType().Name gives the name of an object's actual class, e.g. "Circle".

// I AM NOT DONE

List<Shape> shapes = [new Circle(1), new Rectangle(2, 3), new Square(4)];

Check.Close(Math.PI, shapes[0].Area());
Check.Close(6, shapes[1].Area());
Check.Close(16, shapes[2].Area());
Check.Equal("Rectangle with area 6.00", shapes[1].Describe());
Check.Equal("Square with area 16.00", shapes[2].Describe());
Check.Close(Math.PI + 6 + 16, TotalArea(shapes));

double TotalArea(List<Shape> all)
{
    ???
}

abstract class Shape
{
    public abstract double Area();
    public string Describe() => $"{GetType().Name} with area {Area():F2}";
}

class Circle : Shape
{
    public double Radius { get; }
    public Circle(double radius) => Radius = radius;

    // TODO: area of a circle = π × radius²  (Math.PI)
}

// TODO: Rectangle, with a Width and a Height

// TODO: a Square is a Rectangle whose sides are equal. Reuse Rectangle!
