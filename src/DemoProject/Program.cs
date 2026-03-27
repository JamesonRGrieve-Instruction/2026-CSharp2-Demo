using DemoProject.Models;
using Microsoft.EntityFrameworkCore;

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
                    Console.Write("Select an Operation\n\t1. Create\n\t2. Read\n\t3. Update\n\t4. Delete\n\t0. Exit\nChoose: ");

                    entityMenuChoice = Console.ReadLine().Trim();
                    if (entityMenuChoice == "1")
                    {
                        using (ExampleContext context = new ExampleContext())
                        {
                            Student forCreation = new Student();
                            Console.Write("Please enter the First Name: ");
                            forCreation.FirstName = Console.ReadLine().Trim();
                            Console.Write("Please enter the Last Name: ");
                            forCreation.LastName = Console.ReadLine().Trim();
                            foreach (ClassRoom parent in context.ClassRooms.ToList())
                            {
                                Console.WriteLine(parent.ID + ": " + parent.RoomNumber);
                            }
                            Console.Write("Please enter the ID of the Room: ");
                            forCreation.ClassRoomID = int.Parse(Console.ReadLine());
                            context.Add(forCreation);
                            context.SaveChanges();
                        }
                    }
                    else if (entityMenuChoice == "2")
                    {
                        using (ExampleContext context = new ExampleContext())
                        {
                            foreach (Student entity in context.Students.Include(entity => entity.ClassRoom).ToList())
                            {
                                Console.WriteLine($"{entity.ID}: {entity.FirstName} {entity.LastName} of {entity.ClassRoom.RoomNumber}");
                            }
                        }
                    }
                    else if (entityMenuChoice == "3")
                    {
                        using (ExampleContext context = new ExampleContext())
                        {
                            foreach (Student entity in context.Students.Include(entity => entity.ClassRoom).ToList())
                            {
                                Console.WriteLine($"{entity.ID}: {entity.FirstName} {entity.LastName} of {entity.ClassRoom.RoomNumber}");
                            }
                            Console.Write("Please enter the ID of the target for update: ");
                            Student? forEdit = context.Students.Where(entity => entity.ID == int.Parse(Console.ReadLine())).FirstOrDefault();
                            if (forEdit == null)
                            {
                                Console.WriteLine("I can't find that!");
                            }
                            else
                            {
                                Console.Write("Please enter the First Name: ");
                                forEdit.FirstName = Console.ReadLine().Trim();
                                Console.Write("Please enter the Last Name: ");
                                forEdit.LastName = Console.ReadLine().Trim();
                                foreach (ClassRoom parent in context.ClassRooms.ToList())
                                {
                                    Console.WriteLine(parent.ID + ": " + parent.RoomNumber);
                                }
                                Console.Write("Please enter the ID of the Room: ");
                                forEdit.ClassRoomID = int.Parse(Console.ReadLine());

                                context.SaveChanges();
                            }
                        }
                    }
                    else if (entityMenuChoice == "4")
                    {
                        using (ExampleContext context = new ExampleContext())
                        {
                            foreach (Student entity in context.Students.Include(entity => entity.ClassRoom).ToList())
                            {
                                Console.WriteLine($"{entity.ID}: {entity.FirstName} {entity.LastName} of {entity.ClassRoom.RoomNumber}");
                            }
                            Console.Write("Please enter the ID of the target for deletion: ");

                            Student? forRemoval = context.Students.Where(entity => entity.ID == int.Parse(Console.ReadLine())).FirstOrDefault();
                            if (forRemoval == null)
                            {
                                Console.WriteLine("I can't find that!");
                            }
                            else
                            {
                                context.Students.Remove(forRemoval);
                                context.SaveChanges();
                            }
                        }
                    }
                } while (entityMenuChoice != "0");

            }
        } while (choice != "0");
    }
}
