using MongoDB.Bson;
using MongoDB.Driver;
using OpenVMS.Plugins.Example;

namespace OpenVMS.Plugins.AirMail;

public class AirMailService : ServiceBase
{
    public AirMailService()
    {
        DataClient = new ("mongodb://127.0.0.1:27017/");
        Database = DataClient.GetDatabase("OpenVMS");
        Collection = Database.GetCollection<BsonDocument>("AirMail");
    }
    public void Send(AirMail airMail)
    {
        foreach (var receiver in airMail.Receiver)
        {
            var airmail = new BsonDocument
            {
                { "Identifier", airMail.Sender },
                { "Receiver", receiver },
                {"Date",DateTime.UtcNow},
                {"Subject",airMail.Subject},
                {"Content",airMail.Content}
            };
            Collection.InsertOne(airmail);
        }
    }

    public object Get(string identifier)
    {
        return Collection.Find(Builders<BsonDocument>.Filter.Eq("Identifier", identifier) |
                        Builders<BsonDocument>.Filter.Eq("Receiver", identifier) | 
                        Builders<BsonDocument>.Filter.Eq("Receiver","all")).ToList().ToJson();
    }
}