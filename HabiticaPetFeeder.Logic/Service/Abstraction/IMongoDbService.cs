using System.Threading.Tasks;

namespace HabiticaPetFeeder.Logic.Service.Interfaces;

public interface IMongoDbService
{
    Task<T> GetDummyRecordByFriendlyNameAsync<T>(string friendlyNameFilter) where T : class;
}
