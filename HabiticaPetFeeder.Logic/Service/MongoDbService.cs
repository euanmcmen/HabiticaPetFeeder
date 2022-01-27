using HabiticaPetFeeder.Logic.Service.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.Logic.Service;

public class MongoDbService : IMongoDbService
{
    private const string DatabaseName = "Habitica";
    private const string CollectionName = "Dummies";
    private const string FriendlyNameFieldName = "friendlyName";
    private const string ContentFieldName = "content";

    private readonly IMongoClient mongoClient;

    public MongoDbService(IMongoClient mongoClient)
    {
        this.mongoClient = mongoClient;
    }

    public async Task<T> GetDummyRecordByFriendlyNameAsync<T>(string friendlyNameFilter) where T : class
    {
        var mongoFindFilter = Builders<BsonDocument>.Filter.Eq(FriendlyNameFieldName, friendlyNameFilter);
        var mongoProjectFilter = Builders<BsonDocument>.Projection.Include(ContentFieldName);

        var result = await mongoClient
            .GetDatabase(DatabaseName)
            .GetCollection<BsonDocument>(CollectionName)
            .Find(mongoFindFilter)
            .Project(mongoProjectFilter)
            .SingleAsync();

        return JsonConvert.DeserializeObject<T>(result[ContentFieldName].ToJson());
    }

}
