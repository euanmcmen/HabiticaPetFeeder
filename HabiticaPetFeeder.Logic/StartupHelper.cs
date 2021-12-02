using HabiticaPetFeeder.Logic.Client;
using HabiticaPetFeeder.Logic.Service;
using HabiticaPetFeeder.Logic.Service.PetFoodFeedSummary;
using Microsoft.Extensions.DependencyInjection;

namespace HabiticaPetFeeder.Logic
{
    public static class StartupHelper
    {
        public static void UseHabiticaPetFeederServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<IHabiticaApiClient, DummyHabiticaApiClient>();

            services.AddScoped<IDataService, DataService>();
            services.AddScoped<IPetFoodPreferenceService, PetFoodPreferenceService>();
            services.AddScoped<IPetFoodFeedService, PetFoodFeedService>();
            services.AddScoped<IPetFoodFeedSummaryService, PetFoodFeedSummaryService>();
        }
    }
}
