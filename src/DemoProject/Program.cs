namespace DemoProject;

using System.Net.Http.Headers;
using System.Net.Http.Json;

public class JokeDTO
{
    public string id { get; set; }
    public string joke { get; set; }
    public int status { get; set; }
}
class Program
{
    static async Task<string> generateString()
    {
        await Task.Delay(1000);
        return "Hello, World!";
    }
    static async Task<JokeDTO?> getJoke()
    {
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            return await client.GetFromJsonAsync<JokeDTO>("https://icanhazdadjoke.com/");
        }
    }
    static async Task Main(string[] args)
    {
        Console.WriteLine("Start.");
        await Task.Delay(1000);
        Console.WriteLine("Call Function.");
        Console.WriteLine(await generateString());
        Console.WriteLine(factorial(1, 5));
        Console.WriteLine($"{Environment.UserName} on {Environment.MachineName} running {Environment.OSVersion}");
        JokeDTO? joke = await getJoke();
        if (joke != null)
        {
            Console.WriteLine(joke.joke);
        }
    }

    static int factorial(int start, int end)
    {
        return start >= end ? start : start + factorial(start + 1, end);
    }
}
