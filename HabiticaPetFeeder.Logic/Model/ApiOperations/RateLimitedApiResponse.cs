using System.Net;

namespace HabiticaPetFeeder.Logic.Model.ApiOperations;

public class RateLimitedApiResponse : Interfaces.IRateLimitedOperation
{
    public HttpStatusCode HttpStatus { get; set; }
    public RateLimitInfo RateLimitInfo { get; set; }
}

public class RateLimitedApiResponse<TResponse> : RateLimitedApiResponse
{
    public TResponse Body { get; set; }
}
