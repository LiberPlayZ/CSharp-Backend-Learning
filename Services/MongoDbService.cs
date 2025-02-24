using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MyCSharpBackend.Config;

public class MongoDbService
{
    private readonly IMongoDatabase _database;

    public MongoDbService(IOptions<MongoDbConfig> mongoDbSettings)
    {
        var client = new MongoClient(mongoDbSettings.Value.ConnectionString);  // Use connection string from config
        _database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);  // Use database name from config
    }

    public IMongoCollection<T> GetCollection<T>(string collectionName)
    {
        return _database.GetCollection<T>(collectionName);
    }
}
