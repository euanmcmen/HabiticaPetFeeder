using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Model.ContentResponse;
using HabiticaPetFeeder.Logic.Model.FeedResponse;
using HabiticaPetFeeder.Logic.Model.UserResponse;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.Logic.Service.HabiticaApi;

public interface IHabiticaApiService
{
    Task<(UserResponse userResponse, ContentResponse contentResponse)> GetHabiticaUserAsync(UserApiAuthInfo userApiAuthInfo);

    Task<FeedResponse> FeedPetFoodAsync(UserApiAuthInfo userApiAuthInfo, PetFoodFeed petFoodFeed);
}
