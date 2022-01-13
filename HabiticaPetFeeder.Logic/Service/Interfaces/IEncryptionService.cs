namespace HabiticaPetFeeder.Logic.Service.Interfaces;

public interface IEncryptionService
{
    string Decrypt(string encryptedText);
    string Encrypt(string plainText);
}
