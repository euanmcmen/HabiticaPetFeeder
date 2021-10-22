using HabiticaPetFeeder.Logic.Client;
using HabiticaPetFeeder.Logic.Service;
using Microsoft.Extensions.DependencyInjection;

namespace HabiticaPetFeeder.Logic
{
    public static class StartupHelper
    {
        public static void UseHabiticaPetFeederServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<IHabiticaApiClient, DummyHabiticaApiClient>();

            services.AddScoped<IDataService, DataService>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IFoodService, FoodService>();
            services.AddScoped<IPetFoodPreferenceService, PetFoodPreferenceService>();
            services.AddScoped<IPetFoodFeedService, PetFoodFeedService>();
        }
    }
}
