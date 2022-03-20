using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Model.ApiModel.ContentResponse;
using HabiticaPetFeeder.Logic.Model.ApiModel.UserResponse;
using HabiticaPetFeeder.Logic.Model.ApiOperations;
using HabiticaPetFeeder.Logic.Service.ApiService.Fetch.Abstraction;
using HabiticaPetFeeder.Logic.Service.Interfaces;
using HabiticaPetFeeder.Logic.Util;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.Logic.Service.ApiService.Fetch;

public class DummyFetchApiService : IFetchApiService
{
    private readonly ILogger<DummyFetchApiService> logger;
    private readonly IMongoDbService mongoDbService;

    public DummyFetchApiService(ILoggerFactory loggerFactory, IMongoDbService mongoDbService)
    {
        logger = loggerFactory.CreateLogger<DummyFetchApiService>();
        this.mongoDbService = mongoDbService;
    }

    public async Task<RateLimitedApiResponse<UserContentPair>> GetHabiticaUserAsync(AuthenticatedApiRequest apiRequest)
    {
        var userResponse = await mongoDbService.GetDummyRecordByFriendlyNameAsync<UserResponse>("UserResponse");

        var contentResponse = await mongoDbService.GetDummyRecordByFriendlyNameAsync<ContentResponse>("ContentResponse");

        var userPetFoodInfo = new UserContentPair() { User = userResponse, Content = contentResponse };

        var responseRateInfo = new RateLimitInfo { RateLimitReset = DateTimeHelper.DateToString(DateTime.UtcNow), RateLimitRemaining = 28 };

        var rateLimitedResponse = new RateLimitedApiResponse<UserContentPair> { RateLimitInfo = responseRateInfo, Body = userPetFoodInfo };

        return rateLimitedResponse;
    }

}