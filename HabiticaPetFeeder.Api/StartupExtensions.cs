using HabiticaPetFeeder.Logic.Client;
using HabiticaPetFeeder.Logic.Client.Abstraction;
using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Proxy;
using HabiticaPetFeeder.Logic.Proxy.Abstraction;
using HabiticaPetFeeder.Logic.Service;
using HabiticaPetFeeder.Logic.Service.ApiService.Feed;
using HabiticaPetFeeder.Logic.Service.ApiService.Feed.Abstraction;
using HabiticaPetFeeder.Logic.Service.ApiService.Fetch;
using HabiticaPetFeeder.Logic.Service.ApiService.Fetch.Abstraction;
using HabiticaPetFeeder.Logic.Service.Interfaces;
using HabiticaPetFeeder.Logic.Service.PetFoodPreferenceStrategy;
using HabiticaPetFeeder.Logic.Service.PetFoodPreferenceStrategy.Abstraction;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace HabiticaPetFeeder.Api;

public static class StartupExtensions
{
    public static void UseHabiticaPetFeederServiceLayer(this IServiceCollection services, IConfiguration configuration)
    {
        // Configure web client
        services.AddHttpClient<IHabiticaApiClient, HabiticaApiClient>();

        // Configure Mongo
        services.AddScoped<IMongoDbService, MongoDbService>();
        var mongoClient = new MongoClient(configuration.GetConnectionString("MongoDbConnectionString"));
        services.AddSingleton<IMongoClient>(mongoClient);

        // Configure API implementations
        services.AddFetchApi(configuration);
        services.AddFeedApi(configuration);

        //Configure Options
        services.Configure<HabiticaApiSettings>(configuration.GetSection(HabiticaApiSettings.AppSettingName));
        services.Configure<EncryptionSettings>(configuration.GetSection(EncryptionSettings.AppSettingName));
        services.Configure<HabiticaApiClientHeaderSettings>(configuration.GetSection(HabiticaApiClientHeaderSettings.AppSettingName));

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

    private static void AddFetchApi(this IServiceCollection services, IConfiguration configuration)
    {
        var useLiveEndpoint = configuration
            .GetSection(HabiticaApiSettings.AppSettingName)
            .GetValue<bool>(nameof(HabiticaApiSettings.UseLiveFetchEndpoint));

        if (useLiveEndpoint)
        {
            services.AddScoped<IFetchApiService, FetchApiService>();
        }
        else
        {
            services.AddScoped<IFetchApiService, DummyFetchApiService>();
        }
    }

    private static void AddFeedApi(this IServiceCollection services, IConfiguration configuration)
    {
        var useLiveEndpoint = configuration
            .GetSection(HabiticaApiSettings.AppSettingName)
            .GetValue<bool>(nameof(HabiticaApiSettings.UseLiveFeedEndpoint));

        if (useLiveEndpoint)
        {
            services.AddScoped<IFeedApiService, FeedApiService>();
        }
        else
        {
            services.AddScoped<IFeedApiService, DummyFeedApiService>();
        }
    }
}
