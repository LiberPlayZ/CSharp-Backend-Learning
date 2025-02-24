using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class MongoDbService
{
    private readonly IMongoDatabase _database;

    public MongoDbService(IConfiguration config)
    {
        var connectionString = config["MongoDB:ConnectionString"];
        var databaseName = config["MongoDB:DatabaseName"];

        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }

    public IMongoCollection<T> GetCollection<T>(string collectionName)
    {
        return _database.GetCollection<T>(collectionName);
    }
}
