namespace HabiticaPetFeeder.Logic.Service.Encryption
{
    public interface IEncryptionService
    {
        string Decrypt(string encryptedText);
        string Encrypt(string plainText);
    }
}