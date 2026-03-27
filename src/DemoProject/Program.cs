using DemoProject.Models;

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
                        using (ExampleContext context = new ExampleContext())
                        {
                            Console.Write("Please enter the Room Number: ");
                            context.Add(new ClassRoom()
                            {
                                RoomNumber = int.Parse(Console.ReadLine())
                            });
                            context.SaveChanges();
                        }
                    }
                    else if (entityMenuChoice == "2")
                    {
                        using (ExampleContext context = new ExampleContext())
                        {
                            foreach (ClassRoom parent in context.ClassRooms.ToList())
                            {
                                Console.WriteLine(parent.ID + ": " + parent.RoomNumber);
                            }
                        }
                    }
                    else if (entityMenuChoice == "3")
                    {
                        using (ExampleContext context = new ExampleContext())
                        {
                            foreach (ClassRoom parent in context.ClassRooms.ToList())
                            {
                                Console.WriteLine(parent.ID + ": " + parent.RoomNumber);
                            }
                            Console.Write("Please enter the ID of the target for update: ");
                            ClassRoom? forEdit = context.ClassRooms.Where(parent => parent.ID == int.Parse(Console.ReadLine())).FirstOrDefault();
                            if (forEdit == null)
                            {
                                Console.WriteLine("I can't find that!");
                            }
                            else
                            {
                                Console.Write("Please enter the new Room Number: ");
                                forEdit.RoomNumber = int.Parse(Console.ReadLine());
                                context.SaveChanges();
                            }
                        }
                    }
                    else if (entityMenuChoice == "4")
                    {
                        using (ExampleContext context = new ExampleContext())
                        {
                            foreach (ClassRoom parent in context.ClassRooms.ToList())
                            {
                                Console.WriteLine(parent.ID + ": " + parent.RoomNumber);
                            }
                            Console.Write("Please enter the ID of the target for deletion: ");

                            ClassRoom? forRemoval = context.ClassRooms.Where(parent => parent.ID == int.Parse(Console.ReadLine())).FirstOrDefault();
                            if (forRemoval == null)
                            {
                                Console.WriteLine("I can't find that!");
                            }
                            else
                            {
                                context.ClassRooms.Remove(forRemoval);
                                context.SaveChanges();
                            }
                        }
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
