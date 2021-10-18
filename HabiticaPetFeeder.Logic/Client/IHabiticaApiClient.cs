using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Model.UserResponse;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.Logic.Client
{
    public interface IHabiticaApiClient
    {
        Task<UserResponse> GetUserAsync();
    }
}