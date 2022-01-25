namespace HabiticaPetFeeder.Logic.Model.ApiOperations;

public class RateLimitedApiResponse : Interfaces.IRateLimitedOperation
{
    public RateLimitInfo RateLimitInfo { get; set; }
}

public class RateLimitedApiResponse<TResponse> : RateLimitedApiResponse
{
    public TResponse Body { get; set; }
}
