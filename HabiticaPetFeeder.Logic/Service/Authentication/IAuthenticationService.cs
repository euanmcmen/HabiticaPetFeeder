using HabiticaPetFeeder.Logic.Model;

namespace HabiticaPetFeeder.Logic.Service.Authentication
{
    public interface IAuthenticationService
    {
        string GetAuthenticationTokenForUser(UserApiAuthInfo userApiAuthInfo);
    }
}