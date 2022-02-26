using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Service.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.Logic.Service;

public class RateLimitingService : IRateLimitingService
{
    private readonly HabiticaApiSettings habiticaApiSettings;

    public RateLimitingService(IOptions<HabiticaApiSettings> habiticaApiSettingsOptions)
    {
        habiticaApiSettings = habiticaApiSettingsOptions.Value;
    }

    public async Task WaitForRateLimitDelay(RateLimitInfo rateLimitInfo)
    {
        if (rateLimitInfo.RateLimitRemaining < habiticaApiSettings.RateLimitThrottleThreshold)
        {
            await Task.Delay(habiticaApiSettings.RateLimitThrottleDurationSeconds * 1000);
        }
        else
        {
            await Task.Delay(habiticaApiSettings.RateLimitStandardDurationSeconds * 1000);
        }
    }
}
