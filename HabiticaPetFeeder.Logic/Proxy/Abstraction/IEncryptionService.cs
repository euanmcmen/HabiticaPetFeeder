namespace HabiticaPetFeeder.Logic.Proxy.Abstraction;

public interface IEncryptionService
{
    string Decrypt(string encryptedText);
    string Encrypt(string plainText);
}
