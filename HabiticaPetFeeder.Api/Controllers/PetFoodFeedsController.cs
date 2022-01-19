using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.Api.Controllers;

/*
 * The authentication header has no scheme.  The header value is the encrypted token.
 */

[Route("api/[controller]")]
[ApiController]
public class PetFoodFeedsController : ControllerBase
{
    private readonly ILogger<PetFoodFeedsController> logger;
    private readonly IHabiticaApiService habiticaApiService;
    private readonly IAuthenticationService authenticationService;
    private readonly IDataService dataService;
    private readonly IPetFoodPreferenceService petFoodPreferenceService;
    private readonly IPetFoodFeedService petFoodFeedService;

    public PetFoodFeedsController(ILoggerFactory loggerFactory,
                              IHabiticaApiService habiticaApiService,
                              IAuthenticationService authenticationService,
                              IDataService dataService,
                              IPetFoodPreferenceService petFoodPreferenceService,
                              IPetFoodFeedService petFoodFeedService)
    {
        logger = loggerFactory.CreateLogger<PetFoodFeedsController>();

        this.habiticaApiService = habiticaApiService;
        this.authenticationService = authenticationService;
        this.dataService = dataService;
        this.petFoodPreferenceService = petFoodPreferenceService;
        this.petFoodFeedService = petFoodFeedService;
    }

    [HttpGet]
    [Route("fetch")]
    public async Task<IActionResult> GetPetFeedsForUserAsync()
    {
        var userApiAuthInfo = GetUserAuthFromRequestHeader(Request);

        if (userApiAuthInfo is null)
            return Unauthorized();

        var rateLimitRemaining = GetRateLimitFromRequestHeader(Request);

        if (rateLimitRemaining == 0)
            return Unauthorized();

        var userInfoApiRequest = new AuthenticatedRateLimitedApiRequest() { RateLimitRemaining = rateLimitRemaining, UserApiAuthInfo = userApiAuthInfo };

        var userInfoResponse = await habiticaApiService.GetHabiticaUserAsync(userInfoApiRequest);

        var feeds = GetPetFoodFeedsFromUserPetFoodInfo(userInfoResponse.Response);

        var petFeedsResponse =
            new RateLimitedApiResponse<List<PetFoodFeed>>()
            {
                RateLimitRemaining = userInfoResponse.RateLimitRemaining,
                Response = feeds
            };

        logger.LogInformation($"User Id: {userApiAuthInfo.ApiUserId} | Requests Remaining: {userInfoResponse.RateLimitRemaining} " +
            $"| Number of pet food feeds calculated: {feeds.Count}");

        return Ok(petFeedsResponse);
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

        var rateLimitRemaining = GetRateLimitFromRequestHeader(Request);

        if (rateLimitRemaining == 0)
            return Unauthorized();

        var apiRequest = new AuthenticatedRateLimitedApiRequest<PetFoodFeed>() { Request = petFoodFeed, RateLimitRemaining = rateLimitRemaining, UserApiAuthInfo = userApiAuthInfo };

        var apiResponse = await habiticaApiService.FeedPetFoodAsync(apiRequest);

        logger.LogInformation($"User Id: {userApiAuthInfo.ApiUserId} | Requests Remaining: {apiRequest.RateLimitRemaining} " +
            $"| Pet {petFoodFeed.PetFullName} was fed {petFoodFeed.FoodFullName} x{petFoodFeed.FeedQuantity} ");

        return Ok(apiResponse);
    }

    private List<PetFoodFeed> GetPetFoodFeedsFromUserPetFoodInfo(UserPetFoodInfo userPetFoodInfo)
    {
        var allPets = dataService.GetPets(userPetFoodInfo.User, userPetFoodInfo.Content);
        var allFoods = dataService.GetFoods(userPetFoodInfo.User, userPetFoodInfo.Content);

        var basicPetFoodPreferences = petFoodPreferenceService.GetUserBasicPetPreferredFoods(allPets, allFoods);

        List<PetFoodFeed> feeds = new();
        feeds.AddRange(petFoodFeedService.GetPreferredFoodFeeds(allPets, allFoods, basicPetFoodPreferences));
        feeds.AddRange(petFoodFeedService.GetFoodFeeds(allPets, allFoods));

        return feeds;
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

    private int GetRateLimitFromRequestHeader(HttpRequest httpRequest)
    {
        var headerValue = httpRequest.Headers["X-Rate-Remaining"];

        if (headerValue.Count != 1)
            return 30;

        return int.Parse(headerValue[0]);
    }
}