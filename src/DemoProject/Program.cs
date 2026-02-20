using System.Drawing;

namespace DemoProject;


public class Pen
{
    public Pen(string brand, string colour)
    {
        Brand = brand;
        Colour = colour;
        InkLevel = 100;
    }
    public string Brand
    {
        get; set;
    }

    public string Colour
    {
        get; set;
    }

    private float _inkLevel;
    public float InkLevel
    {
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            _inkLevel = value;
        }
        get
        {
            return _inkLevel;
        }
    }
    public void write(int letters)
    {
        InkLevel -= letters * 0.5f;
    }

}
class Program
{
    static void Main(string[] args)
    {
        Pen myPen = new Pen("Bic", "Blue");
        myPen.write(100);
        myPen.write(42);
        try
        {
            myPen.write(200);
        }
        catch
        {

        }
        Console.WriteLine(myPen.InkLevel);
    }
}
