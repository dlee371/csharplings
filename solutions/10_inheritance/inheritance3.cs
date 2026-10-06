// inheritance3.cs — solution

List<Shape> shapes = [new Circle(1), new Rectangle(2, 3), new Square(4)];

Check.Close(Math.PI, shapes[0].Area());
Check.Close(6, shapes[1].Area());
Check.Close(16, shapes[2].Area());
Check.Equal("Rectangle with area 6.00", shapes[1].Describe());
Check.Equal("Square with area 16.00", shapes[2].Describe());
Check.Close(Math.PI + 6 + 16, TotalArea(shapes));

double TotalArea(List<Shape> all)
{
    double total = 0;
    foreach (Shape s in all)
    {
        total += s.Area();
    }
    return total;
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

    public override double Area() => Math.PI * Radius * Radius;
}

class Rectangle : Shape
{
    public double Width { get; }
    public double Height { get; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public override double Area() => Width * Height;
}

class Square : Rectangle
{
    public Square(double side) : base(side, side) { }
}
