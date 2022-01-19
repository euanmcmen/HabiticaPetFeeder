using System;

namespace HabiticaPetFeeder.Logic.Model.ApiModel;

public class RateLimitedApiResponse<TResponse>
{
    public TResponse Response { get; set; }

    public int? RateLimitRemaining { get; set; }

    public DateTime? RateLimitReset { get; set; }

    public RateLimitedApiResponse(TResponse response)
    {
        Response = response;
    }
}
