using HabiticaPetFeeder.Logic.Model;

namespace HabiticaPetFeeder.Logic.Service.Authentication
{
    public interface IAuthenticationService
    {
        string GetAuthenticationTokenForUserAuth(UserApiAuthInfo userApiAuthInfo);

        UserApiAuthInfo GetUserAuthFromAuthenticationToken(string authenticationToken);
    }
}