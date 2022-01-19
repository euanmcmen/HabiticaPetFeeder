namespace HabiticaPetFeeder.Logic.Model;

public abstract class RateLimitedApiOperation
{
    public int? RateLimitRemaining { get; set; }
}
