using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Model.ApiOperations;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.Logic.Service.ApiService.Fetch.Abstraction;

public interface IFetchApiService
{
    Task<RateLimitedApiResponse<UserContentPair>> GetHabiticaUserAsync(AuthenticatedApiRequest apiRequest);
}
