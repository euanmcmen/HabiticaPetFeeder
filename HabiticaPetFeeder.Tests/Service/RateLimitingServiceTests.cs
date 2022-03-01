using FakeItEasy;
using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Proxy.Interface;
using HabiticaPetFeeder.Logic.Service;
using HabiticaPetFeeder.Logic.Service.Interfaces;
using Microsoft.Extensions.Options;
using Xunit;

namespace HabiticaPetFeeder.Tests.Service
{
    public class RateLimitingServiceTests
    {
        private readonly IThreadingProxy threadingProxy;
        private readonly IRateLimitingService rateLimitingService;

        const int RateLimitStandardDurationSeconds = 1;
        const int RateLimitThrottleDurationSeconds = 3;
        const int RateLimitThrottleThreshold = 20;

        public RateLimitingServiceTests()
        {
            threadingProxy = A.Fake<IThreadingProxy>();

            var habiticaApiSettings = new HabiticaApiSettings()
            {
                RateLimitStandardDurationSeconds = RateLimitStandardDurationSeconds,
                RateLimitThrottleDurationSeconds = RateLimitThrottleDurationSeconds,
                RateLimitThrottleThreshold = RateLimitThrottleThreshold,
            };

            rateLimitingService = new RateLimitingService(threadingProxy, Options.Create(habiticaApiSettings));
        }

        [Fact]
        public void WaitForRateLimitDelay_WhenBelowThreshhold_ShouldCallThreadingProxyWithThresholdDuration()
        {
            var input = new RateLimitInfo { RateLimitRemaining = 10 };
            
            rateLimitingService.WaitForRateLimitDelayAsync(input);

            AssertWaitForSecondsAsyncWasCalled(RateLimitThrottleDurationSeconds);
        }

        [Fact]
        public void WaitForRateLimitDelay_WhenAtThreshhold_ShouldCallThreadingProxyWithStandardDuration()
        {
            var input = new RateLimitInfo { RateLimitRemaining = RateLimitThrottleThreshold };

            rateLimitingService.WaitForRateLimitDelayAsync(input);

            AssertWaitForSecondsAsyncWasCalled(RateLimitStandardDurationSeconds);
        }

        [Fact]
        public void WaitForRateLimitDelay_WhenAboveThreshhold_ShouldCallThreadingProxyWithStandardDuration()
        {
            var input = new RateLimitInfo { RateLimitRemaining = 29 };

            rateLimitingService.WaitForRateLimitDelayAsync(input);

            AssertWaitForSecondsAsyncWasCalled(RateLimitStandardDurationSeconds);
        }

        private void AssertWaitForSecondsAsyncWasCalled(int seconds)
        {
            A.CallTo(() => threadingProxy.WaitForSecondsAsync(seconds))
                .MustHaveHappenedOnceExactly();
        }
    }

}
