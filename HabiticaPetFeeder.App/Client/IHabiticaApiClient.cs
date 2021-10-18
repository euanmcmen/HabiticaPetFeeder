using System.Threading.Tasks;

namespace HabiticaPetFeeder.App.Client
{
    public interface IHabiticaApiClient
    {
        Task<UserResponse> GetUserAsync();
    }
}