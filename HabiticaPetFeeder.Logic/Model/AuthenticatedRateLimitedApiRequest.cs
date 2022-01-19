namespace HabiticaPetFeeder.Logic.Model;

public class AuthenticatedRateLimitedApiRequest : RateLimitedApiOperation
{
    public UserApiAuthInfo UserApiAuthInfo { get; set; }
}

public class AuthenticatedRateLimitedApiRequest<TRequestBody> : AuthenticatedRateLimitedApiRequest
{
    public TRequestBody Request { get; set; }
}
