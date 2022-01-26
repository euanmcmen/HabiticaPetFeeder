namespace HabiticaPetFeeder.Logic.Model;

public class HabiticaApiSettings
{
    public const string AppSettingName = "HabiticaApi";

    public bool UseLiveEndpoint { get; set; }

    public int RateLimitThrottleThreshold { get; set; }

    public int RateLimitThrottleDurationSeconds { get; set; }
}
