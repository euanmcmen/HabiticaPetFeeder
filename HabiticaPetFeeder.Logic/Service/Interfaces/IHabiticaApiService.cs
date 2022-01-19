using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Model.ApiModel.ContentResponse;
using HabiticaPetFeeder.Logic.Model.ApiModel.UserResponse;
using HabiticaPetFeeder.Logic.Model.FeedResponse;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.Logic.Service.Interfaces;

public interface IHabiticaApiService
{
    Task<(UserResponse userResponse, ContentResponse contentResponse)> GetHabiticaUserAsync(UserApiAuthInfo userApiAuthInfo);

    Task<FeedResponse> FeedPetFoodAsync(UserApiAuthInfo userApiAuthInfo, PetFoodFeed petFoodFeed);
}
