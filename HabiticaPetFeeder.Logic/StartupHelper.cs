using HabiticaPetFeeder.Logic.Client;
using HabiticaPetFeeder.Logic.Service;
using HabiticaPetFeeder.Logic.Service.HabiticaApi;
using HabiticaPetFeeder.Logic.Service.PetFoodFeedSummary;
using Microsoft.Extensions.DependencyInjection;

namespace HabiticaPetFeeder.Logic
{
    public static class StartupHelper
    {
        public static void UseHabiticaPetFeederServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<IHabiticaApiClient>(client => GetApiClient(true));

            services.AddScoped<IHabiticaApiService, HabiticaApiService>();
            services.AddScoped<IDataService, DataService>();
            services.AddScoped<IPetFoodPreferenceService, PetFoodPreferenceService>();
            services.AddScoped<IPetFoodFeedService, PetFoodFeedService>();
            services.AddScoped<IPetFoodFeedSummaryService, PetFoodFeedSummaryService>();
        }

        private static IHabiticaApiClient GetApiClient(bool useLiveEndpoint)
        {
            return useLiveEndpoint ? new HabiticaApiClient(new System.Net.Http.HttpClient()) : new DummyHabiticaApiClient();
        }
    }
}
