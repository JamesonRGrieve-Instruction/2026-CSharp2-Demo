using DemoProject.Models;

namespace DemoProject;


class Program
{

    static void Main(string[] args)
    {
        using (ExampleContext context = new ExampleContext())
        {
            context.Add(new ExampleParent());
            context.SaveChanges();

            foreach (ExampleParent parent in context.ExampleParents.Where(parent => parent.ID >= 0).ToList())
            {
                Console.WriteLine("Parent: " + parent.ID);
            }

            ExampleParent forEdit = context.ExampleParents.Where(parent => parent.Name == "Temp").First();
            forEdit.Name = "Updated";
            context.SaveChanges();

            List<ExampleParent> forRemoval = context.ExampleParents.Where(parent => parent.Name == "Updated").Where(parent => parent.ExampleTables.Count == 0).ToList();
            context.ExampleParents.RemoveRange(forRemoval);
            context.SaveChanges();

        }
    }
}
