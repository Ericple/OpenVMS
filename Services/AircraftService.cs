using MongoDB.Bson;
using MongoDB.Driver;

namespace OpenVMS.Services;

public class AircraftService : ServiceBase
{
    public AircraftService(string connectionString,string databaseName,string collectionName)
    {
        DataClient = new(connectionString);
        Database = DataClient.GetDatabase(databaseName);
        Collection = Database.GetCollection<BsonDocument>(collectionName);
    }

    public AircraftService()
    {
        DataClient = new("mongodb://127.0.0.1:27017/");
        Database = DataClient.GetDatabase("OpenVMS");
        Collection = Database.GetCollection<BsonDocument>("Aircraft");
    }

    /**
     * Transfer aircraft from one company to another
     * void
     */
    public long Transfer(string identifier, string target)
    {
        var filter = Builders<BsonDocument>.Filter.Eq("Identifier", identifier);
        var updater = Builders<BsonDocument>.Update.Set("Company", target);
        return Collection.UpdateOne(filter, updater).ModifiedCount;
    }
}