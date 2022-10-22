using MongoDB.Driver;
using MongoDB.Bson;

namespace NETVMS.Services;

public class ServiceBase
{
    protected static MongoClient DataClient;
    protected static IMongoDatabase? Database;
    protected static IMongoCollection<BsonDocument> Collection;

    /**
     * Get All Objects
     * Returns JSON string
     */
    public object Get()
    {
        return Collection.Find(new BsonDocument()).ToList().ToJson();
    }

    /**
     * Get object with certain identifier
     */
    public object Get(string identifier)
    {
        return Collection.Find(Builders<BsonDocument>.Filter.Eq("Identifier", identifier)).ToList().ToJson();
    }
    
    /**
     * Create an new instance
     * void
     */
    public void Create(BsonDocument obj)
    {
        Collection.InsertOne(obj);
    }

    /**
     * Delete instance with certain identifier
     * long
     */
    public long Delete(string identifier)
    {
        return Collection.DeleteOne(Builders<BsonDocument>.Filter.Eq("Identifier", identifier)).DeletedCount;
    }
}