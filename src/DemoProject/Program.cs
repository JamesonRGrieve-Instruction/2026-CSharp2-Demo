namespace DemoProject;


class Program
{

    static void Main(string[] args)
    {
        string choice = "";
        do
        {
            Console.Write("Select an Entity\n\t1. Class Room\n\t2. Student\n\t0. Exit\nChoose: ");
            choice = Console.ReadLine().Trim();
            if (choice == "1")
            {
                string entityMenuChoice = "";
                do
                {
                    Console.Write("Select an Operation\n\t1. Create\n\t2. Read\n\t3. Update\n\t4. Delete\n\t0. Exit\nChoose: ");

                    entityMenuChoice = Console.ReadLine().Trim();
                    if (entityMenuChoice == "1")
                    {

                    }
                    else if (entityMenuChoice == "2")
                    {

                    }
                    else if (entityMenuChoice == "3")
                    {

                    }
                    else if (entityMenuChoice == "4")
                    {

                    }
                } while (entityMenuChoice != "0");
            }
            else if (choice == "2")
            {
                string entityMenuChoice = "";
                do
                {

                } while (entityMenuChoice != "0");
            }
        } while (choice != "0");
    }
}
