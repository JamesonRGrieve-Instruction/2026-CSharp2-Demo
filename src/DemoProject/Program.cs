namespace DemoProject;


class Rectangle
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
    public double Area
    {
        get
        {
            return Length * Width;
        }
    }
    public double Perimeter
    {
        get
        {
            return Length * 2 + Width * 2;
        }
    }
    public Rectangle containWithSquare()
    {
        double max = Math.Max(Length, Width);
        return new Rectangle(max, max);
    }
}
class Triangle
{
    public Triangle(double bottom, double height)
    {
        Base = bottom;
        Height = height;
    }
    public double Base { get; set; }
    public double Height { get; set; }

    public double Area
    {
        get
        {
            return Base * Height / 2;
        }
    }

    public Rectangle containWithRectangle()
    {
        return new Rectangle(Base, Height);
    }

}
class Circle
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
    public double Area
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
        Rectangle rect = new Rectangle(getNumber("Please enter rectangle Length: "), getNumber("Please enter rectangle Width: "));
        Triangle tri = new Triangle(getNumber("Please enter triangle Base: "), getNumber("Please enter triangle Height: "));
        Circle circ = new Circle(getNumber("Please enter cirlce Radius: "));

        Console.WriteLine($"Rectangle: L: {rect.Length} W: {rect.Width} A: {rect.Area} P: {rect.Perimeter} S?: {rect.IsSquare}");
        Rectangle containing = rect.containWithSquare();
        Console.WriteLine($"Square Containing Rectangle: L: {containing.Length} W: {containing.Width} A: {containing.Area} P: {containing.Perimeter} S?: {containing.IsSquare}");
        Console.WriteLine($"Triangle: L: {tri.Base} W: {tri.Height} A: {rect.Area}");
        containing = tri.containWithRectangle();
        Console.WriteLine($"Rectangle Containing Triangle: L: {containing.Length} W: {containing.Width} A: {containing.Area} P: {containing.Perimeter} S?: {containing.IsSquare}");
        Console.WriteLine($"Circle: R: {circ.Radius} D: {circ.Diameter} A: {circ.Area} C: {circ.Circumference}");



    }
}
