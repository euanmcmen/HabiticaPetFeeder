using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Model.ApiOperations;
using HabiticaPetFeeder.Logic.Service.ApiService.Feed.Abstraction;
using System;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.Logic.Service.ApiService.Feed;

public class FeedApiService : IFeedApiService
{
    public async Task<RateLimitedApiResponse> FeedPetFoodAsync(AuthenticatedRateLimitedApiRequest<PetFoodFeed> apiPetFoodFeedRequest)
    {
        throw new NotImplementedException("Not ready for live.");
    }
}
