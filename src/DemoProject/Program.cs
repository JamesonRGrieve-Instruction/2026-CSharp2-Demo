namespace DemoProject;

using System.Net.Http.Headers;
using System.Net.Http.Json;

public class IPDTO
{
    public string ip { get; set; }
}
class Program
{
    static int getInput(string prompt)
    {
        Console.Write(prompt);
        return int.Parse(Console.ReadLine());
    }
    static async Task<IPDTO?> getIP()
    {
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            return await client.GetFromJsonAsync<IPDTO>("https://api.ipify.org?format=json");
        }
    }
    static async Task Main(string[] args)
    {

        IPDTO ip = new IPDTO() { ip = "unknown" };
        try
        {
            ip = await getIP() ?? ip;
        }
        catch
        {

        }
        Console.WriteLine($"{Environment.UserName} on {Environment.MachineName} at {ip.ip}, hello!");
        count(getInput("Enter first number:"), getInput("Enter second number:"));
    }

    static void count(int start, int end)
    {
        Console.WriteLine(start);
        if (start < end) count(start + 1, end);
    }
}
