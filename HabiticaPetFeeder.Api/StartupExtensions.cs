using HabiticaPetFeeder.Logic.Client;
using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Service;
using HabiticaPetFeeder.Logic.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HabiticaPetFeeder.Api
{
    public static class StartupExtensions
    {
        public static void UseHabiticaPetFeederServiceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(client => GetApiClient(configuration.GetValue<bool>("UseLiveEndpoint")));

            services.Configure<EncryptionSettings>(configuration.GetSection(EncryptionSettings.AppSettingName));

            services.AddScoped<IHabiticaApiService, HabiticaApiService>();
            services.AddScoped<IEncryptionService, EncryptionService>();
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
