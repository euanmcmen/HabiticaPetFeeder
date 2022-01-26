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
            var useLiveEndpoint = configuration
                .GetSection(HabiticaApiSettings.AppSettingName)
                .GetValue<bool>(nameof(HabiticaApiSettings.UseLiveEndpoint));

            if (useLiveEndpoint)
            {
                services.AddScoped<IHabiticaApiClient>((sp) => new HabiticaApiClient(new System.Net.Http.HttpClient()));
                services.AddScoped<IHabiticaApiService, HabiticaApiService>();
            }
            else
            {
                services.AddScoped<IHabiticaApiService, DummyHabiticaApiService>();
            }

            services.Configure<HabiticaApiSettings>(configuration.GetSection(HabiticaApiSettings.AppSettingName));

            services.Configure<EncryptionSettings>(configuration.GetSection(EncryptionSettings.AppSettingName));

            services.AddScoped<IEncryptionService, EncryptionService>();
            services.AddScoped<IDataService, DataService>();
            services.AddScoped<IPetFoodPreferenceService, PetFoodPreferenceService>();
            services.AddScoped<IPetFoodFeedService, PetFoodFeedService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }
    }
}
