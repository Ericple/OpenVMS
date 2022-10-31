using MongoDB.Bson;
using OpenVMS.Service;

namespace OpenVMS.Service.AirMarket;

public class AirMarketService : ServiceBase
{
    public AirMarketService()
    {
        DataClient = new("mongodb://127.0.0.1:27017/");
        Database = DataClient.GetDatabase("OpenVMS");
        Collection = Database.GetCollection<BsonDocument>("Aircraft");
    }
}