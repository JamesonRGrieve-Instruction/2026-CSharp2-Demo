namespace DemoProject;

using System.Net.Http.Headers;
using System.Net.Http.Json;

public class AddressDTO
{
    public int number { get; set; }
    public string name { get; set; }
}
public class LocationDTO
{
    public AddressDTO street { get; set; }
    public string city { get; set; }
    public string state { get; set; }
    public string country { get; set; }
}
public class NameDTO
{
    public string first { get; set; }
    public string last { get; set; }
    public string full
    {
        get => first + " " + last;
    }
}
public class PersonDTO
{
    public NameDTO name { get; set; }
    public LocationDTO location { get; set; }
    public string email { get; set; }
}
public class ResultsDTO
{
    public List<PersonDTO> results { get; set; }
}
class Program
{
    static async Task<ResultsDTO?> getPeople(int count)
    {
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            return await client.GetFromJsonAsync<ResultsDTO>($"https://randomuser.me/api/?nat=gb,ca,us,au&results={count}");
        }
    }
    static async Task Main(string[] args)
    {
        List<PersonDTO> people = (await getPeople(5)).results;
        int choice = 0;
        do
        {
            Console.Write("1. Create\n2. Read\n3. Update\n4. Delete\n0. Exit\n\tChoice: ");
            choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                people.Add((await getPeople(1)).results[0]);
            }
            else if (choice == 2)
            {
                foreach (PersonDTO person in people)
                {
                    Console.WriteLine($"{person.name.full} of {person.location.street.number} {person.location.street.name}, {person.location.city} {person.location.state} {person.location.country} at {person.email}");
                }
            }
            else if (choice == 3)
            {
                for (int i = 1; i <= people.Count; i++)
                {
                    Console.WriteLine($"{i}. {people[i - 1].name.full}");

                }
                Console.Write("Choice: ");
                int selection = int.Parse(Console.ReadLine());
                Console.Write("New Name (2 Words Supported): ");
                string newName = Console.ReadLine();
                people[selection - 1].name = new NameDTO()
                {
                    first = newName.Split(' ')[0],
                    last = newName.Split(' ')[1],
                };
            }
            else if (choice == 4)
            {
                for (int i = 1; i <= people.Count; i++)
                {
                    Console.WriteLine($"{i}. {people[i - 1].name.full}");

                }
                Console.Write("Choice: ");
                int selection = int.Parse(Console.ReadLine());
                people.RemoveAt(selection - 1);
            }
        } while (choice != 0);
    }


}
