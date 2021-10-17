using HabiticaPetFeeder.App.Model;
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
                .ConfigureLogging(loggingBuilder => loggingBuilder.AddConsole())

                .ConfigureAppConfiguration((app) => {
                    app.Sources.Clear();
                    app.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                })

                .ConfigureServices((services) => {
                    services.AddScoped<IUserResponseParserFactory, UserResponseParserFactory>();

                    services.AddScoped<IUserResponseElementParser, UserResponseElementParser>();

                    services.AddScoped<UserResponsePetParser>()
                        .AddScoped<IUserResponseParser<Pet>, UserResponsePetParser>(s => s.GetService<UserResponsePetParser>());

                    services.AddScoped<UserResponseFoodParser>()
                        .AddScoped<IUserResponseParser<Food>, UserResponseFoodParser>(s => s.GetService<UserResponseFoodParser>());

                    services.AddScoped<IHabiticaApiClient, HabiticaApiClient>();

                    services.AddScoped<IPetService, PetService>();
                    services.AddScoped<IFoodService, FoodService>();
                    services.AddScoped<IPetFoodPreferenceService, PetFoodPreferenceService>();
                    services.AddScoped<IPetFoodFeedService, PetFoodFeedService>();

                    services.AddScoped<PetFeederOperation>();
                });
        }
    }
}
