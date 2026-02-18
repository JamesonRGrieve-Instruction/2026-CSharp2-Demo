namespace DemoProject;


class ExampleClass
{
    int exampleField;

    int ExampleProperty { get; set; }

    int _exampleBackingField;
    int ExampleFullyImplementedProperty
    {
        get
        {
            return _exampleBackingField;
        }
        set
        {
            _exampleBackingField = value;
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        ExampleClass newObject = new ExampleClass();
        Console.WriteLine("Hello, World!");
    }
}
