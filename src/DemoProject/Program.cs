namespace DemoProject;


public abstract class Shape
{
    public abstract double Perimeter { get; }
    public abstract double Area { get; }
    public abstract Rectangle Contain();
}

public class Rectangle : Shape
{
    public Rectangle(double length, double width)
    {
        Length = length;
        Width = width;
    }
    public double Length { get; set; }
    public double Width { get; set; }

    public bool IsSquare
    {
        get
        {
            return Length == Width;
        }
    }
    public override double Area
    {
        get
        {
            return Length * Width;
        }
    }
    public override double Perimeter
    {
        get
        {
            return Length * 2 + Width * 2;
        }
    }
    public override Rectangle Contain()
    {
        double side = Math.Max(Length, Width);
        return new Rectangle(side, side);
    }
}
public class Triangle : Shape
{
    public Triangle(double bottom, double height)
    {
        Base = bottom;
        Height = height;
    }
    public double Base { get; set; }
    public double Height { get; set; }

    public override double Perimeter
    {
        get
        {
            return Base + Math.Sqrt(Math.Pow(Base, 2) + 4 * Math.Pow(Height, 2));
        }
    }

    public override double Area
    {
        get
        {
            return Base * Height / 2;
        }
    }

    public override Rectangle Contain()
    {
        double side = Math.Max(Base, Height);
        return new Rectangle(side, side);
    }

}
public class Circle : Shape
{
    public Circle(double radius)
    {
        Radius = radius;
    }

    public double Radius { get; set; }

    public double Diameter
    {
        get
        {
            return 2 * Radius;
        }
    }
    public override double Area
    {
        get
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
    public double Circumference
    {
        get
        {
            return Math.PI * Diameter;
        }
    }
    public override double Perimeter => Circumference;
    public override Rectangle Contain()
    {
        return new Rectangle(Diameter, Diameter);
    }
}
class Program
{
    static double getNumber(string prompt)
    {
        Console.Write(prompt);
        return double.Parse(Console.ReadLine());
    }
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        string choice = "";
        do

        {
            Console.Write("Create a Shape\n\t1. Rectangle\n\t2. Triangle\n\t3. Circle\n\t0. Done\nChoose: ");
            choice = Console.ReadLine().Trim();
            if (choice == "1") shapes.Add(new Rectangle(getNumber("Please enter rectangle Length: "), getNumber("Please enter rectangle Width: ")));
            else if (choice == "2") shapes.Add(new Triangle(getNumber("Please enter triangle Base: "), getNumber("Please enter triangle Height: ")));
            else if (choice == "3") shapes.Add(new Circle(getNumber("Please enter circle Radius: ")));
            Console.WriteLine($"Total Perimeter: {shapes.Sum(shape => shape.Perimeter)} | Total Area: {shapes.Sum(shape => shape.Area)} | Total Containing Area: {shapes.Sum(shape => shape.Contain().Area)}");
        } while (choice != "0");
    }
}
