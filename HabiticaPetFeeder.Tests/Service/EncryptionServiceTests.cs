﻿using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Service;
using HabiticaPetFeeder.Logic.Service.Interfaces;
using Microsoft.Extensions.Options;
using Xunit;

namespace HabiticaPetFeeder.Tests.Service;

public class EncryptionServiceTests_Fixture
{
    public IEncryptionService EncryptionService { get; private set; }

    public EncryptionServiceTests_Fixture()
    {
        EncryptionService = new EncryptionService(TestHelpers.GetMockedLogFactoryForType<EncryptionService>().Object,
            Options.Create(new EncryptionSettings() { Secret = "59dec600219a454a8ad3d39bf8e41c6b" }));
    }
}

public class EncryptionServiceTests : IClassFixture<EncryptionServiceTests_Fixture>
{
    private readonly EncryptionServiceTests_Fixture fixture;

    public EncryptionServiceTests(EncryptionServiceTests_Fixture fixture)
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