using MongoDB.Bson;
using MongoDB.Driver;

namespace NETVMS.Services;

public class CabinCrewService : ServiceBase
{
    public CabinCrewService(string connectionString, string databaseName, string collectionName)
    {
        DataClient = new(connectionString);
        Database = DataClient.GetDatabase(databaseName);
        Collection = Database.GetCollection<BsonDocument>(collectionName);
    }

    public CabinCrewService()
    {
        Database = DataClient.GetDatabase("NETVMS");
        Collection = Database.GetCollection<BsonDocument>("CabinCrew");
    }

    /**
     * Dismiss or hire the instance
     */
    public long Transfer(string identifier, string target)
    {
        var filter = Builders<BsonDocument>.Filter.Eq("Identifier", identifier);
        var updater = Builders<BsonDocument>.Update.Set("Company", target);
        return Collection.UpdateOne(filter, updater).ModifiedCount;
    }
}