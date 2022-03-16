using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Proxy.Abstraction;
using HabiticaPetFeeder.Logic.Service.Interfaces;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.Logic.Service;

public class RateLimitingService : IRateLimitingService
{
    private readonly HabiticaApiSettings habiticaApiSettings;
    private readonly IThreadingProxy threadingProxy;

    public RateLimitingService(IThreadingProxy threadingProxy, IOptions<HabiticaApiSettings> habiticaApiSettingsOptions)
    {
        habiticaApiSettings = habiticaApiSettingsOptions.Value;
        this.threadingProxy = threadingProxy;
    }

    public async Task WaitForRateLimitDelayAsync(RateLimitInfo rateLimitInfo)
    {
        if (rateLimitInfo.RateLimitRemaining < habiticaApiSettings.RateLimitThrottleThreshold)
        {
            await threadingProxy.WaitForSecondsAsync(habiticaApiSettings.RateLimitThrottleDurationSeconds);
        }
        else
        {
            await threadingProxy.WaitForSecondsAsync(habiticaApiSettings.RateLimitStandardDurationSeconds);
        }
    }
}
