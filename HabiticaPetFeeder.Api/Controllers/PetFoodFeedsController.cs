using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Model.ApiOperations;
using HabiticaPetFeeder.Logic.Service.ApiService.Feed.Abstraction;
using HabiticaPetFeeder.Logic.Service.ApiService.Fetch.Abstraction;
using HabiticaPetFeeder.Logic.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PetFoodFeedsController : ControllerBase
{
    private readonly ILogger<PetFoodFeedsController> logger;
    private readonly IFetchApiService fetchApiService;
    private readonly IFeedApiService feedApiService;
    private readonly IAuthenticationService authenticationService;
    private readonly IDataService dataService;
    private readonly IPetFoodFeedService petFoodFeedService;

    public PetFoodFeedsController(ILoggerFactory loggerFactory,
                              IFetchApiService fetchApiService,
                              IFeedApiService feedApiService,
                              IAuthenticationService authenticationService,
                              IDataService dataService,
                              IPetFoodFeedService petFoodFeedService)
    {
        logger = loggerFactory.CreateLogger<PetFoodFeedsController>();
        this.fetchApiService = fetchApiService;
        this.feedApiService = feedApiService;
        this.authenticationService = authenticationService;
        this.dataService = dataService;
        this.petFoodFeedService = petFoodFeedService;
    }

    [HttpGet]
    [Route("fetch")]
    public async Task<IActionResult> GetPetFeedsForUserAsync()
    {
        var userApiAuthInfo = GetUserAuthFromRequestHeader(Request);

        if (userApiAuthInfo is null)
            return Unauthorized();

        var userInfoApiRequest = new AuthenticatedApiRequest() { UserApiAuthInfo = userApiAuthInfo };

        var userInfoResponse = await fetchApiService.GetHabiticaUserAsync(userInfoApiRequest);

        var userPetFoodFeeds = GetUserPetFoodFeeds(userInfoResponse);

        var petFeedsResponse =
            new RateLimitedApiResponse<UserPetFoodFeeds>()
            {
                RateLimitInfo = userInfoResponse.RateLimitInfo,
                HttpStatus = userInfoResponse.HttpStatus,
                Body = userPetFoodFeeds
            };

        return HandleApiResponse(nameof(GetPetFeedsForUserAsync), userApiAuthInfo, petFeedsResponse);
    }

    private UserPetFoodFeeds GetUserPetFoodFeeds(RateLimitedApiResponse<UserContentPair> userInfoResponse)
    {
        if (userInfoResponse.HttpStatus != System.Net.HttpStatusCode.OK)
        {
            return null;
        }

        var userContentPair = userInfoResponse.Body;

        var userName = dataService.GetUserName(userContentPair.User);
        var allPets = dataService.GetPets(userContentPair.User, userContentPair.Content);
        var allFoods = dataService.GetFoods(userContentPair.User, userContentPair.Content);

        var feeds = petFoodFeedService.GetPetFoodFeedsWithConfiguredPreferences(allPets, allFoods);

        var userPetFoodFeeds = new UserPetFoodFeeds()
        {
            UserName = userName,
            PetFoodFeeds = feeds
        };

        return userPetFoodFeeds;
    }

    [HttpPost]
    [Route("feed")]
    public async Task<IActionResult> FeedUserPetAsync(PetFoodFeed petFoodFeed)
    {
        if (petFoodFeed is null)
            return BadRequest();

        var userApiAuthInfo = GetUserAuthFromRequestHeader(Request);

        if (userApiAuthInfo is null)
            return Unauthorized();

        var rateLimitInfo = GetRateLimitFromRequestHeader(Request);

        if (rateLimitInfo is null)
            return Forbid();

        var apiRequest = new AuthenticatedRateLimitedApiRequest<PetFoodFeed>()
        {
            Body = petFoodFeed,
            RateLimitInfo = rateLimitInfo,
            UserApiAuthInfo = userApiAuthInfo
        };

        var apiResponse = await feedApiService.FeedPetFoodAsync(apiRequest);

        return HandleApiResponse(nameof(FeedUserPetAsync), userApiAuthInfo, apiResponse);
    }

    private IActionResult HandleApiResponse(string operationName, UserApiAuthInfo userApiAuthInfo, RateLimitedApiResponse rateLimitedApiResponse)
    {
        if (rateLimitedApiResponse.HttpStatus != System.Net.HttpStatusCode.OK)
        {
            logger.LogError($"{operationName} | User Id: {userApiAuthInfo.ApiUserId} | " +
                $"Unexpected API status code: {rateLimitedApiResponse.HttpStatus}.");
        }

        return StatusCode((int)rateLimitedApiResponse.HttpStatus, rateLimitedApiResponse);
    }

    private UserApiAuthInfo GetUserAuthFromRequestHeader(HttpRequest httpRequest)
    {
        var headerValue = httpRequest.Headers["X-Auth-Token"];

        if (headerValue.Count != 1)
            return null;

        var userAuthResult = authenticationService.GetUserAuthFromAuthenticationToken(headerValue[0]);

        return (userAuthResult is null || string.IsNullOrEmpty(userAuthResult.ApiUserId) || string.IsNullOrEmpty(userAuthResult.ApiUserKey))
            ? null
            : userAuthResult;
    }

    private RateLimitInfo GetRateLimitFromRequestHeader(HttpRequest httpRequest)
    {
        var remainingHeaderValue = httpRequest.Headers["X-Rate-Remaining"];
        var resetHeaderValue = httpRequest.Headers["X-Rate-Reset"];

        if (remainingHeaderValue.Count != 1 || resetHeaderValue.Count != 1)
            return null;

        return new RateLimitInfo() { RateLimitRemaining = int.Parse(remainingHeaderValue[0]), RateLimitReset = resetHeaderValue[0] };
    }
}