namespace HabiticaPetFeeder.Logic.Model.ApiOperations.Interfaces;

public interface IRateLimitedOperation
{
    public RateLimitInfo RateLimitInfo { get; set; }
}
