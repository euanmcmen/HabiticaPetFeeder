using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Model.ApiOperations;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.Logic.Service.Interfaces;

public interface IHabiticaApiService
{
    Task<RateLimitedApiResponse<UserContentPair>> GetHabiticaUserAsync(AuthenticatedApiRequest apiRequest);

    Task<RateLimitedApiResponse> FeedPetFoodAsync(AuthenticatedRateLimitedApiRequest<PetFoodFeed> apiPetFoodFeedRequest);
}
