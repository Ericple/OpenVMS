using MongoDB.Bson;
using MongoDB.Driver;
using NETVMS.Models.Enums;

namespace NETVMS.Services;

public class ApiKeyAuthenticationService
{
    private MongoClient ApiKeyClient = new();
    private IMongoDatabase ApiKeyBase;
    private IMongoCollection<BsonDocument> ApiKeyCollection;

    public ApiKeyAuthenticationService(string database, string collectionName)
    {
        ApiKeyBase = ApiKeyClient.GetDatabase(database);
        ApiKeyCollection = ApiKeyBase.GetCollection<BsonDocument>(collectionName);
    }
    
    public ApiKeyAuthenticationService()
    {
        ApiKeyBase = ApiKeyClient.GetDatabase("NETVMS");
        ApiKeyCollection = ApiKeyBase.GetCollection<BsonDocument>("ApiKey");
    }

    public bool Auth(string apikey,ApiKeyPermission permission)
    {
        if (ApiKeyCollection.Find(Builders<BsonDocument>.Filter.Eq("Value", apikey) & Builders<BsonDocument>.Filter.Gte("Permission",permission)).CountDocuments() == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Create(string value, int permission)
    {
        var apiKey = new BsonDocument
        {
            { "Value", value },
            { "Permission", permission },
            { "CreatedAt", DateTime.Now }
        };
        ApiKeyCollection.InsertOne(apiKey);
        return true;
    }

    public long Delete(string value)
    {
        return ApiKeyCollection.DeleteOne(Builders<BsonDocument>.Filter.Eq("Value", value)).DeletedCount;
    }
}