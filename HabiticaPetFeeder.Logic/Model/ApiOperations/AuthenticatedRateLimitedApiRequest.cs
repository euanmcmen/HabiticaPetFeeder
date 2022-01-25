namespace HabiticaPetFeeder.Logic.Model.ApiOperations;

public class AuthenticatedRateLimitedApiRequest : Interfaces.IAuthenticatedOperation, Interfaces.IRateLimitedOperation
{
    public UserApiAuthInfo UserApiAuthInfo { get; set; }

    public RateLimitInfo RateLimitInfo { get; set; }
}

public class AuthenticatedRateLimitedApiRequest<TRequestBody> : AuthenticatedRateLimitedApiRequest
{
    public TRequestBody Body { get; set; }
}
