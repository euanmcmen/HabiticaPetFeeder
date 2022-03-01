using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Service;
using HabiticaPetFeeder.Tests.DataFixtures;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HabiticaPetFeeder.Tests.Service;

public class DataServiceTests : IClassFixture<UserResponseDataFixture>, IClassFixture<ContentResponseDataFixture>
{
    private readonly DataService dataService;

    private readonly UserResponseDataFixture userResponseDataFixture;
    private readonly ContentResponseDataFixture contentResponseDataFixture;

    public DataServiceTests(UserResponseDataFixture userResponseDataFixture, ContentResponseDataFixture contentResponseDataFixture)
    {
        this.userResponseDataFixture = userResponseDataFixture;
        this.contentResponseDataFixture = contentResponseDataFixture;

        dataService = new DataService(TestHelpers.GetFakeLoggerFactoryForType<DataService>());
    }

    [Fact]
    public void GetUserName_ReturnsUserLocalAuthUserName()
    {
        var result = GetUserName();

        Assert.Equal(userResponseDataFixture.UserResponse.data.auth.local.username, result);
        Assert.Equal("DressingFrown", result);
    }

    [Fact]
    public void GetPets_ReturnsFeedablePets()
    {
        var result = GetPets();

        //The LionCub White and the Wolf Base are basic pets which have not been raised to a mount.
        Assert.Equal("LionCub-White", result.ElementAt(0).FullName);
        Assert.Equal("Wolf-Base", result.ElementAt(1).FullName);

        //The Tiger Royal Purple is a premium pet which has not been raised into a mount.
        Assert.Equal("TigerCub-RoyalPurple", result.ElementAt(2).FullName);

        //There should be no other pets (unless I add more...)
        Assert.Equal(3, result.Count());
    }

    [Fact]
    public void GetPets_ExcludesNonFeedablePets()
    {
        var result = GetPets();

        //The Dragon Skeleton, while also being a basic pet with a positive fed points value, has been turned into a mount and cannot be fed.
        Assert.DoesNotContain(result, x => x.FullName == "Dragon-Skeleton");

        //The Dragon RoyalPurple has not been hatched and cannot be fed.  It is also a mount.
        Assert.DoesNotContain(result, x => x.FullName == "Dragon-RoyalPurple");

        //The Orca is a special pet and cannot be fed.
        Assert.DoesNotContain(result, x => x.FullName == "Orca-Base");
    }

    [Fact]
    public void GetFood_ReturnsUsableFood()
    {
        var result = GetFoods();

        Assert.Equal(7, result.Count());
    }

    [Fact]
    public void GetFood_ExcludesSaddle()
    {
        var result = GetFoods();

        Assert.DoesNotContain(result, x => x.FullName == "Saddle");
    }

    private string GetUserName()
    {
        return dataService.GetUserName(userResponseDataFixture.UserResponse);
    }

    private IEnumerable<Pet> GetPets()
    {
        return dataService.GetPets(userResponseDataFixture.UserResponse, contentResponseDataFixture.ContentResponse);
    }

    private IEnumerable<Food> GetFoods()
    {
        return dataService.GetFoods(userResponseDataFixture.UserResponse, contentResponseDataFixture.ContentResponse);
    }
}
