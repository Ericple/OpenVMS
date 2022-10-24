using MongoDB.Bson;

namespace OpenVMS.Services;

public class ExampleService : ServiceBase
{
    public ExampleService()
    {
        DataClient = new("mongodb://127.0.0.1:27017/");
        Database = DataClient.GetDatabase("OpenVMS");
        Collection = Database.GetCollection<BsonDocument>("Account");
    }
    //Add your service code here,
    //ServiceBase class provides CRD function
    //Get(); Create(); Delete();
}