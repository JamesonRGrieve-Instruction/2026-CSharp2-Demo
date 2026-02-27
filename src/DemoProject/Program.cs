namespace DemoProject;



abstract class WritingUtensil
{
    public string Brand { get; set; }
    public abstract void write(int characters);
}

class Pen : WritingUtensil
{
    public Pen()
    {
        Brand = "Bic";
        Colour = "Black";
        InkLevel = 100;
    }

    public string Colour { get; set; }
    private float _inkLevel;
    public float InkLevel
    {
        get
        {
            return _inkLevel;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception("Ink percentage cannot be negative!");
            }
            _inkLevel = value;
        }
    }
    public override void write(int characters)
    {
        InkLevel -= characters * 0.5f;
    }
}

class Pencil : WritingUtensil
{
    public Pencil()
    {
        Brand = "Ticonderoga";
        Length = 20;
    }
    private float _length;
    public float Length
    {
        get
        {
            return _length;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception("Length cannot be negative!");
            }
        }
    }
    public override void write(int characters)
    {
        Length -= characters * 0.25f;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter P for pen or C for pencil: ");
        char choice = char.Parse(Console.ReadLine().Trim().ToUpper());
        WritingUtensil utensil = (choice == 'P' ? new Pen() : new Pencil());
        string letters;
        do
        {
            Console.Write("Enter a number of characters to write or 'exit': ");
            letters = Console.ReadLine().Trim();
            if (letters != "exit")
            {
                utensil.write(int.Parse(letters));
            }
        } while (letters != "exit");



    }
}
