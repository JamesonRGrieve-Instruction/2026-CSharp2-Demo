namespace DemoProject;



abstract class PersonClass
{
    public string firstName;
    public string lastName;
    public abstract string upperCaseFullName();
}

class ExampleClass : PersonClass
{
    public ExampleClass()
    {
        firstName = "John";
        lastName = "Doe";
    }
    public ExampleClass(string firstName, string lastName)
    {
        this.firstName = firstName;
        this.lastName = lastName;
    }
    int ExampleProperty { get; set; }

    int _exampleBackingField;
    public int ExampleFullyImplementedProperty
    {
        get
        {
            return _exampleBackingField;
        }
        private set
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

    public override string upperCaseFullName()
    {
        return FullName.ToUpper();
    }



}

class DerivedClass : ExampleClass
{
    public override string upperCaseFullName()
    {
        return FullName.ToUpper();
    }
}
class Program
{
    static void Main(string[] args)
    {
        ExampleClass newObject = new ExampleClass();
        Console.WriteLine(newObject.upperCaseFullName());
        newObject.firstName = "Jane";
        Console.WriteLine(newObject.upperCaseFullName());

        ExampleClass newObject2 = new ExampleClass("Jane", "Sue");
        Console.WriteLine(newObject2.upperCaseFullName());


        List<PersonClass> myList = new List<PersonClass>();
        myList.Add(newObject);
        myList.Add(new DerivedClass());

        foreach (PersonClass thing in myList)
        {
            thing.upperCaseFullName();
        }



    }
}
