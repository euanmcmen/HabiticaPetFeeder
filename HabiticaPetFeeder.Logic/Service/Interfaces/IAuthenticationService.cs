using HabiticaPetFeeder.Logic.Model;

namespace HabiticaPetFeeder.Logic.Service.Interfaces;

public interface IAuthenticationService
{
    string GetAuthenticationTokenForUserAuth(UserApiAuthInfo userApiAuthInfo);

    UserApiAuthInfo GetUserAuthFromAuthenticationToken(string authenticationToken);
}
