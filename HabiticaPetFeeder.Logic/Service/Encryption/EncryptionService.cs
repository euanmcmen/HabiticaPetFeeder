using HabiticaPetFeeder.Logic.Model;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace HabiticaPetFeeder.Logic.Service.Encryption;

public class EncryptionService : IEncryptionService
{
    private readonly ILogger<EncryptionService> logger;
    private readonly EncryptionSettings encryptionSettings;

    public EncryptionService(ILoggerFactory loggerFactory, IOptions<EncryptionSettings> encryptionSettingsOptions)
    {
        logger = loggerFactory.CreateLogger<EncryptionService>();

        encryptionSettings = encryptionSettingsOptions.Value;
    }

    public string Encrypt(string plainText)
    {
        var keyBytes = Encoding.ASCII.GetBytes(encryptionSettings.Secret);

        var encryptedBytes = EncryptStringToBytes_Aes(plainText, keyBytes);

        return Convert.ToBase64String(encryptedBytes);
    }

    public string Decrypt(string encryptedText)
    {
        var encryptedBytes = Encoding.UTF8.GetBytes(encryptedText);
        var keyBytes = Encoding.ASCII.GetBytes(encryptionSettings.Secret);

        return DecryptStringFromBytes_Aes(encryptedBytes, keyBytes);
    }

    //https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.aes?view=net-6.0

    static byte[] EncryptStringToBytes_Aes(string plainText, byte[] key)
    {
        // Check arguments.
        if (plainText == null || plainText.Length <= 0)
            throw new ArgumentNullException(nameof(plainText));
        if (key == null || key.Length <= 0)
            throw new ArgumentNullException(nameof(key));
        //if (iv is null || iv.Length <= 0)
        //    throw new ArgumentNullException(nameof(iv));

        byte[] encrypted;

        // Create an Aes object
        // with the specified key and IV.
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = key;

            aesAlg.GenerateIV();

            //KeySizes[] ks = aesAlg.LegalKeySizes;
            //foreach (KeySizes item in ks)
            //{
            //    Debug.WriteLine("Legal min key size = " + item.MinSize);
            //    Debug.WriteLine("Legal max key size = " + item.MaxSize);
            //    //Output
            //    // Legal min key size = 128
            //    // Legal max key size = 256
            //}

            // Create an encryptor to perform the stream transform.
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            // Create the streams used for encryption.
            using MemoryStream msEncrypt = new MemoryStream();
            using CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
            using (StreamWriter swEncrypt = new(csEncrypt))
            {
                //Write all data to the stream.
                swEncrypt.Write(plainText);
            }
            encrypted = msEncrypt.ToArray();
        }

        // Return the encrypted bytes from the memory stream.
        return encrypted;
    }

    static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] key)
    {
        // Check arguments.
        if (cipherText == null || cipherText.Length <= 0)
            throw new ArgumentNullException(nameof(cipherText));
        if (key == null || key.Length <= 0)
            throw new ArgumentNullException(nameof(key));
        //if (iv is null || iv.Length <= 0)
        //    throw new ArgumentNullException(nameof(iv));

        // Declare the string used to hold
        // the decrypted text.
        string plaintext = null;

        // Create an Aes object
        // with the specified key and IV.
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = key;

            aesAlg.GenerateIV();

            // Create a decryptor to perform the stream transform.
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            // Create the streams used for decryption.
            using MemoryStream msDecrypt = new MemoryStream(cipherText);
            using CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
            using StreamReader srDecrypt = new StreamReader(csDecrypt);

            // Read the decrypted bytes from the decrypting stream
            // and place them in a string.
            plaintext = srDecrypt.ReadToEnd();
        }

        return plaintext;
    }
}
