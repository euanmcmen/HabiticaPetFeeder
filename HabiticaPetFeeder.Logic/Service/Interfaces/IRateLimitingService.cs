using HabiticaPetFeeder.Logic.Model;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.Logic.Service.Interfaces;

public interface IRateLimitingService
{
    Task WaitForRateLimitDelay(RateLimitInfo rateLimitInfo);
}
