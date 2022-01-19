namespace HabiticaPetFeeder.Logic.Model;

public class EncryptionSettings
{
    public const string AppSettingName = "Encryption";

    public string Secret { get; set; }
}