using HabiticaPetFeeder.Logic.Client;
using HabiticaPetFeeder.Logic.Service;
using HabiticaPetFeeder.Logic.Service.HabiticaApi;
using Microsoft.Extensions.DependencyInjection;

namespace HabiticaPetFeeder.Logic
{
    public static class StartupHelper
    {
        public static void UseHabiticaPetFeederServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<IHabiticaApiClient>(client => GetApiClient(false));

            services.AddScoped<IHabiticaApiService, HabiticaApiService>();
            services.AddScoped<IDataService, DataService>();
            services.AddScoped<IPetFoodPreferenceService, PetFoodPreferenceService>();
            services.AddScoped<IPetFoodFeedService, PetFoodFeedService>();
        }

        private static IHabiticaApiClient GetApiClient(bool useLiveEndpoint)
        {
            return useLiveEndpoint ? new HabiticaApiClient(new System.Net.Http.HttpClient()) : new DummyHabiticaApiClient();
        }
    }
}
