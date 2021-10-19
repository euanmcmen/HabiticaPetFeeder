using HabiticaPetFeeder.Logic.Client;
using HabiticaPetFeeder.Logic.ContentResponseParser;
using HabiticaPetFeeder.Logic.Service;
using HabiticaPetFeeder.Logic.Service.Data;
using Microsoft.Extensions.DependencyInjection;

namespace HabiticaPetFeeder.Logic
{
    public static class StartupHelper
    {
        public static void UseHabiticaPetFeederServiceLayer(this IServiceCollection services)
        {
            //services.AddScoped<IUserResponseParserFactory, UserResponseParserFactory>();

            //services.AddScoped<IUserResponseElementParser, UserResponseElementParser>();

            //services.AddScoped<UserResponsePetParser>()
            //    .AddScoped<IUserResponseParser<Pet>, UserResponsePetParser>(s => s.GetService<UserResponsePetParser>());

            //services.AddScoped<UserResponseFoodParser>()
            //    .AddScoped<IUserResponseParser<Food>, UserResponseFoodParser>(s => s.GetService<UserResponseFoodParser>());

            services.AddScoped<IContentResponseElementParser, ContentResponseElementParser>();

            services.AddScoped<IHabiticaApiClient, DummyHabiticaApiClient>();

            services.AddScoped<IDataService, DataService>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IFoodService, FoodService>();
            services.AddScoped<IPetFoodPreferenceService, PetFoodPreferenceService>();
            services.AddScoped<IPetFoodFeedService, PetFoodFeedService>();
        }
    }
}
