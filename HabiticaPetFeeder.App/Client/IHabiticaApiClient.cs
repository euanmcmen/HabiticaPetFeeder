using System.Threading.Tasks;

namespace HabiticaPetFeeder.App
{
    public interface IHabiticaApiClient
    {
        Task<UserResponse> GetUserAsync();
    }
}