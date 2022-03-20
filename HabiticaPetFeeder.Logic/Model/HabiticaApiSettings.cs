namespace HabiticaPetFeeder.Logic.Model;

public class HabiticaApiSettings
{
    public const string AppSettingName = "HabiticaApi";

    public bool UseLiveFetchEndpoint { get; set; }

    public bool UseLiveFeedEndpoint { get; set; }

    public int RateLimitStandardDurationSeconds { get; set; }

    public int RateLimitThrottleThreshold { get; set; }

    public int RateLimitThrottleDurationSeconds { get; set; }
}
