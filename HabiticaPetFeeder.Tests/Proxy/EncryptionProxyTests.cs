using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Proxy;
using HabiticaPetFeeder.Logic.Proxy.Interface;
using Microsoft.Extensions.Options;
using Xunit;

namespace HabiticaPetFeeder.Tests.Proxy;

public class EncryptionProxyTests
{
    private readonly IEncryptionService encryptionService;

    public EncryptionProxyTests()
    {
        var encryptionSettings = new EncryptionSettings() { Secret = "59dec600219a454a8ad3d39bf8e41c6b" };

        encryptionService = new EncryptionProxy(TestHelpers.GetFakeLoggerFactoryForType<EncryptionProxy>(), Options.Create(encryptionSettings));
    }

    [Fact]
    public void EncryptAndDecryptProduceSymmetricalResult()
    {
        const string inputText = "pet feeds";

        var encrypted = encryptionService.Encrypt(inputText);

        var decrypted = encryptionService.Decrypt(encrypted);

        Assert.Equal(inputText, decrypted);
    }
}
