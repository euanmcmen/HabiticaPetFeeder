using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Model.ApiModel.ContentResponse;
using HabiticaPetFeeder.Logic.Model.ApiModel.UserResponse;
using HabiticaPetFeeder.Logic.Model.ApiOperations;
using HabiticaPetFeeder.Logic.Model.FeedResponse;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.Logic.Client.Interface;

public interface IHabiticaApiClient
{
    Task AuthenticateAsync(UserApiAuthInfo userApiAuthInfo);

    Task<RateLimitedApiResponse<UserResponse>> GetUserAsync();

    Task<RateLimitedApiResponse<ContentResponse>> GetContentAsync();

    Task<RateLimitedApiResponse<FeedResponse>> FeedPetFoodAsync(PetFoodFeed petFoodFeed);
}
