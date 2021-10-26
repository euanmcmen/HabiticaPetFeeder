using HabiticaPetFeeder.Logic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.App
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            using IServiceScope scope = host.Services.CreateScope();
            var instance = scope.ServiceProvider.GetRequiredService<PetFeederOperation>();

            await instance.RunOperationAsync();

            await host.StartAsync();
        }

        static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureLogging(loggingBuilder => loggingBuilder.AddSimpleConsole(x => x.SingleLine = true))

                .ConfigureAppConfiguration((app) => {
                    app.Sources.Clear();
                    app.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                })

                .ConfigureServices((services) => {
                    services.UseHabiticaPetFeederServiceLayer();

                    services.AddScoped<PetFeederOperation>();
                });
        }
    }
}
