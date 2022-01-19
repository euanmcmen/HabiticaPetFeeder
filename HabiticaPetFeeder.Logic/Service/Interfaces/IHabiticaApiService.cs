using HabiticaPetFeeder.Logic.Model;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.Logic.Service.Interfaces;

public interface IHabiticaApiService
{
    Task<RateLimitedApiResponse<UserPetFoodInfo>> GetHabiticaUserAsync(AuthenticatedRateLimitedApiRequest apiRequest);

    Task<RateLimitedApiResponse> FeedPetFoodAsync(AuthenticatedRateLimitedApiRequest<PetFoodFeed> apiPetFoodFeedRequest);
}
