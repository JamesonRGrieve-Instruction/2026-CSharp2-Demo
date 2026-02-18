namespace DemoProject;


class ExampleClass
{
    string firstName;
    string lastName;
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

    public string FullName
    {
        get
        {
            return $"{firstName} {lastName}";
        }
    }

    public string upperCaseFullName()
    {
        return FullName.ToUpper();
    }

}
class Program
{
    static void Main(string[] args)
    {
        ExampleClass newObject = new ExampleClass();
        newObject.upperCaseFullName();
        Console.WriteLine("Hello, World!");
    }
}
