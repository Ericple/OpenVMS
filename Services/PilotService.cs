using MongoDB.Bson;
using MongoDB.Driver;

namespace NETVMS.Services;

public class PilotService : ServiceBase
{
    public PilotService(
        string connectionString,
        string databaseName,
        string collectionName)
    {
        DataClient = new(connectionString);
        Database = DataClient.GetDatabase(databaseName);
        Collection = Database.GetCollection<BsonDocument>(collectionName);
    }

    public PilotService()
    {
        DataClient = new("mongodb://127.0.0.1:27017/");
        Database = DataClient.GetDatabase("NETVMS");
        Collection = Database.GetCollection<BsonDocument>("Pilot");
    }

    public long Transfer(string identifier, string target)
    {
        var filter = Builders<BsonDocument>.Filter.Eq("Identifier", identifier);
        var updater = Builders<BsonDocument>.Update.Set("Company", target);
        return Collection.UpdateOne(filter, updater).ModifiedCount;
    }
}