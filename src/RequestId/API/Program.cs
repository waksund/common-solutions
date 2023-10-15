using Microsoft.AspNetCore;
namespace API;

public class Program
{
    public static void Main(string[] args)
    {
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .UseUrls($"http://+:3000")
            .Build()
            .Run();
    }
}