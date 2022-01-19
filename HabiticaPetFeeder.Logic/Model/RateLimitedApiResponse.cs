using System;

namespace HabiticaPetFeeder.Logic.Model;

public class RateLimitedApiResponse : RateLimitedApiOperation
{

}

public class RateLimitedApiResponse<TResponse> : RateLimitedApiResponse
{
    public TResponse Response { get; set; }
}
