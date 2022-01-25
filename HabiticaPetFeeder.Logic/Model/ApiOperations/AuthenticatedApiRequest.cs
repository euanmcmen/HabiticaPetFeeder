namespace HabiticaPetFeeder.Logic.Model.ApiOperations;

public class AuthenticatedApiRequest : Interfaces.IAuthenticatedOperation
{
    public UserApiAuthInfo UserApiAuthInfo { get; set; }
}

public class AuthenticatedApiRequest<TRequestBody> : AuthenticatedApiRequest
{
    public TRequestBody Body { get; set; }
}