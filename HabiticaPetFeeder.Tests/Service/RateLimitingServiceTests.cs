using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Proxy.Interface;
using HabiticaPetFeeder.Logic.Service;
using HabiticaPetFeeder.Logic.Service.Interfaces;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HabiticaPetFeeder.Tests.Service
{
    public class RateLimitingServiceTests_Fixture
    {
        public Mock<IThreadingProxy> MockThreadingProxy { get; private set; }
        public IRateLimitingService RateLimitingService { get; private set; }

        public const int RateLimitStandardDurationSeconds = 1;

        public const int RateLimitThrottleDurationSeconds = 3;

        public const int RateLimitThrottleThreshold = 20;

        public RateLimitingServiceTests_Fixture()
        {
            MockThreadingProxy = new Mock<IThreadingProxy>();

            var habiticaApiSettings = new HabiticaApiSettings()
            {
                RateLimitStandardDurationSeconds = RateLimitStandardDurationSeconds,
                RateLimitThrottleDurationSeconds = RateLimitThrottleDurationSeconds,
                RateLimitThrottleThreshold = RateLimitThrottleThreshold,
            };

            RateLimitingService = new RateLimitingService(MockThreadingProxy.Object, Options.Create(habiticaApiSettings));
        }
    }

    public class RateLimitingServiceTests : IClassFixture<RateLimitingServiceTests_Fixture>
    {
        private readonly RateLimitingServiceTests_Fixture fixture;

        public RateLimitingServiceTests(RateLimitingServiceTests_Fixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void WaitForRateLimitDelay_WhenBelowThreshhold_ShouldCallThreadingProxyWithThresholdDuration()
        {
            var input = new RateLimitInfo { RateLimitRemaining = 10 };
            
            fixture.RateLimitingService.WaitForRateLimitDelayAsync(input);

            fixture.MockThreadingProxy.Verify(x => x.WaitForSecondsAsync(RateLimitingServiceTests_Fixture.RateLimitThrottleDurationSeconds));
        }

        [Fact]
        public void WaitForRateLimitDelay_WhenAtThreshhold_ShouldCallThreadingProxyWithStandardDuration()
        {
            var input = new RateLimitInfo { RateLimitRemaining = RateLimitingServiceTests_Fixture.RateLimitThrottleThreshold };

            fixture.RateLimitingService.WaitForRateLimitDelayAsync(input);

            fixture.MockThreadingProxy.Verify(x => x.WaitForSecondsAsync(RateLimitingServiceTests_Fixture.RateLimitStandardDurationSeconds));
        }

        [Fact]
        public void WaitForRateLimitDelay_WhenAboveThreshhold_ShouldCallThreadingProxyWithStandardDuration()
        {
            var input = new RateLimitInfo { RateLimitRemaining = 29 };

            fixture.RateLimitingService.WaitForRateLimitDelayAsync(input);

            fixture.MockThreadingProxy.Verify(x => x.WaitForSecondsAsync(RateLimitingServiceTests_Fixture.RateLimitStandardDurationSeconds));
        }
    }

}
