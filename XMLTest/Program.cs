using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using XMLTest.FourRefuel;
using XMLTest.FourRefuel.Xml;

internal class Program
{
    private readonly IClient client;

    private static async Task Main(string[] args)
    {
        var builder = Host.CreateDefaultBuilder(args);
        builder.ConfigureServices((context, services) =>
        {
            services.AddHttpClient();
            services.AddTransient<IClient, XmlClient>();
            services.AddSingleton<Program>();
        });

        using var host = builder.Build();

        var program = host.Services.GetRequiredService<Program>();
        await program.RunAsync();
    }

    public Program(IClient client)
    {
        this.client = client;
    }

    public async Task RunAsync()
    {
        var invoices = await this.client.GetAllAsync();

        foreach (var invoice in invoices)
        {
            Console.WriteLine($"Invoice #{invoice.Id} has date {invoice.Date}");
        }
    }
}