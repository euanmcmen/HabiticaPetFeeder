using HabiticaPetFeeder.Logic.Client;
using HabiticaPetFeeder.Logic.Client.Interface;
using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Proxy;
using HabiticaPetFeeder.Logic.Proxy.Interface;
using HabiticaPetFeeder.Logic.Service;
using HabiticaPetFeeder.Logic.Service.Interfaces;
using HabiticaPetFeeder.Logic.Service.PetFoodPreferenceStrategy;
using HabiticaPetFeeder.Logic.Service.PetFoodPreferenceStrategy.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace HabiticaPetFeeder.Api
{
    public static class StartupExtensions
    {
        public static void UseHabiticaPetFeederServiceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            //Configure clients

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
                var mongoClient = new MongoClient(configuration.GetConnectionString("MongoDbConnectionString"));
                services.AddSingleton<IMongoClient>(mongoClient);

                services.AddScoped<IMongoDbService, MongoDbService>();
                services.AddScoped<IHabiticaApiService, DummyHabiticaApiService>();
            }

            //Configure Options
            services.Configure<HabiticaApiSettings>(configuration.GetSection(HabiticaApiSettings.AppSettingName));
            services.Configure<EncryptionSettings>(configuration.GetSection(EncryptionSettings.AppSettingName));

            //Configure Pet Food Preference strategies
            services.AddScoped<IPetFoodPreferenceStrategy, BasicPetFoodPreferenceStrategy>();
            services.AddScoped<IPetFoodPreferenceStrategy, EmptyPetFoodPreferenceStrategy>();

            //Configure app services.
            services.AddScoped<IThreadingProxy, ThreadingProxy>();
            services.AddScoped<IRateLimitingService, RateLimitingService>();
            services.AddScoped<IEncryptionService, EncryptionProxy>();
            services.AddScoped<IDataService, DataService>();
            services.AddScoped<IPetFoodFeedService, PetFoodFeedService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }
    }
}
