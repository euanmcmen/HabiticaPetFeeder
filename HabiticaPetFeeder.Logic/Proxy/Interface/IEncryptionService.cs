namespace HabiticaPetFeeder.Logic.Proxy.Interface;

public interface IEncryptionService
{
    string Decrypt(string encryptedText);
    string Encrypt(string plainText);
}
