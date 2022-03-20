using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Model.ApiOperations;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.Logic.Service.ApiService.Feed.Abstraction;

public interface IFeedApiService
{
    public Task<RateLimitedApiResponse> FeedPetFoodAsync(AuthenticatedRateLimitedApiRequest<PetFoodFeed> apiPetFoodFeedRequest);
}
