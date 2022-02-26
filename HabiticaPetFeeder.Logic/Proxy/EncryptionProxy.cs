using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Proxy.Interface;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace HabiticaPetFeeder.Logic.Proxy;

public class EncryptionProxy : IEncryptionService
{
    private readonly ILogger<EncryptionProxy> logger;
    private readonly EncryptionSettings encryptionSettings;

    public EncryptionProxy(ILoggerFactory loggerFactory, IOptions<EncryptionSettings> encryptionSettingsOptions)
    {
        logger = loggerFactory.CreateLogger<EncryptionProxy>();

        encryptionSettings = encryptionSettingsOptions.Value;
    }

    public string Encrypt(string plainText)
    {
        var keyBytes = Encoding.UTF8.GetBytes(encryptionSettings.Secret);

        var (iv, cipher) = Encrypt_Aes(plainText, keyBytes);

        return string.Concat(Convert.ToBase64String(iv), Convert.ToBase64String(cipher));
    }

    public string Decrypt(string encryptedText)
    {
        var keyBytes = Encoding.UTF8.GetBytes(encryptionSettings.Secret);

        //Encrypted text contains (iv)(text to decrypt).
        //Both are base64 encoded, with 24 characters.
        var ivPartBytes = Convert.FromBase64String(encryptedText.Substring(0, 24));
        var cipherPartBytes = Convert.FromBase64String(encryptedText.Substring(24));

        return Decrypt_Aes(cipherPartBytes, ivPartBytes, keyBytes);
    }

    //https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.aes?view=net-6.0

    private static (byte[] iv, byte[] cipher) Encrypt_Aes(string plainText, byte[] key)
    {
        // Check arguments.
        if (plainText == null || plainText.Length <= 0)
            throw new ArgumentNullException(nameof(plainText));
        if (key == null || key.Length <= 0)
            throw new ArgumentNullException(nameof(key));

        byte[] iv;
        byte[] encrypted;

        // Create an Aes object with the specified key and random IV.
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = key;

            aesAlg.GenerateIV();

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using MemoryStream msEncrypt = new MemoryStream();
            using CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
            {
                swEncrypt.Write(plainText);
            }

            iv = aesAlg.IV;
            encrypted = msEncrypt.ToArray();
        }

        return (iv, encrypted);
    }

    private static string Decrypt_Aes(byte[] cipher, byte[] iv, byte[] key)
    {
        // Check arguments.
        if (cipher == null || cipher.Length <= 0)
            throw new ArgumentNullException(nameof(cipher));
        if (iv == null || iv.Length <= 0)
            throw new ArgumentNullException(nameof(iv));
        if (key == null || key.Length <= 0)
            throw new ArgumentNullException(nameof(key));

        string plaintext = null;

        // Create an Aes object
        // with the specified key and IV.
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = key;
            aesAlg.IV = iv;

            // Create a decryptor to perform the stream transform.
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            // Create the streams used for decryption.
            using MemoryStream msDecrypt = new MemoryStream(cipher);
            using CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
            using StreamReader srDecrypt = new StreamReader(csDecrypt);

            // Read the decrypted bytes from the decrypting stream
            // and place them in a string.
            plaintext = srDecrypt.ReadToEnd();
        }

        return plaintext;
    }
}
