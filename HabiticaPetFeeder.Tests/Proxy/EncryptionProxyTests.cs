using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Proxy;
using HabiticaPetFeeder.Logic.Proxy.Interface;
using Microsoft.Extensions.Options;
using Xunit;

namespace HabiticaPetFeeder.Tests.Proxy;

public class EncryptionProxyTests_Fixture
{
    public IEncryptionService EncryptionService { get; private set; }

    public EncryptionProxyTests_Fixture()
    {
        EncryptionService = new EncryptionProxy(TestHelpers.GetFakeLoggerFactoryForType<EncryptionProxy>(),
            Options.Create(new EncryptionSettings() { Secret = "59dec600219a454a8ad3d39bf8e41c6b" }));
    }
}

public class EncryptionProxyTests : IClassFixture<EncryptionProxyTests_Fixture>
{
    private readonly EncryptionProxyTests_Fixture fixture;

    public EncryptionProxyTests(EncryptionProxyTests_Fixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public void GetAuthenticationTokenForUser_ReturnsBase64EncodedUserIdAndKey()
    {
        const string inputText = "pet feeds";

        var encrypted = fixture.EncryptionService.Encrypt(inputText);

        var decrypted = fixture.EncryptionService.Decrypt(encrypted);

        Assert.Equal(inputText, decrypted);
    }
}
