using HabiticaPetFeeder.Logic.Client;
using HabiticaPetFeeder.Logic.Service.Authentication;
using HabiticaPetFeeder.Logic.Service.Data;
using HabiticaPetFeeder.Logic.Service.HabiticaApi;
using HabiticaPetFeeder.Logic.Service.PetFoodFeed;
using HabiticaPetFeeder.Logic.Service.PetFoodPreferences;
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
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }

        private static IHabiticaApiClient GetApiClient(bool useLiveEndpoint)
        {
            return useLiveEndpoint ? new HabiticaApiClient(new System.Net.Http.HttpClient()) : new DummyHabiticaApiClient();
        }
    }
}
