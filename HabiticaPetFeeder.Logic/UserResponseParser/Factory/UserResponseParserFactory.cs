using HabiticaPetFeeder.Logic.Model;
using System;

namespace HabiticaPetFeeder.Logic.UserResponseParser.Factory
{
    public class UserResponseParserFactory : IUserResponseParserFactory
    {
        private readonly IServiceProvider serviceProvider;

        public UserResponseParserFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IUserResponseParser<T> GetUserResponseParser<T>() where T : class
        {
            if (typeof(T) == typeof(Pet))
            {
                return (IUserResponseParser<T>)serviceProvider.GetService(typeof(UserResponsePetParser));
            }

            if (typeof(T) == typeof(Food))
            {
                return (IUserResponseParser<T>)serviceProvider.GetService(typeof(UserResponseFoodParser));
            }

            throw new NotImplementedException();
        }
    }
}
