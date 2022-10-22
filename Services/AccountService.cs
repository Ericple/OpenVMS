using MongoDB.Bson;
using MongoDB.Driver;

namespace NETVMS.Services;

public class AccountService : ServiceBase
{
    private static readonly PilotService PilotService = new();

    public AccountService()
    {
        DataClient = new("mongodb://127.0.0.1:27017/");
        Database = DataClient.GetDatabase("NETVMS");
        Collection = Database.GetCollection<BsonDocument>("Account");
    }
    public bool Auth(string identifier, string pass)
    {
        if (Collection.Find(Builders<BsonDocument>.Filter.Eq("Identifier", identifier) &
                            Builders<BsonDocument>.Filter.Eq("Password", pass)).CountDocuments() == 1)
        {
            return true;
        }

        return false;
    }

    public bool Create(string identifier, string email, string nickname, string pass, string hub)
    {
        var account = new BsonDocument
        {
            { "Identifier", identifier },
            { "Password", pass }
        };
        var pilot = new BsonDocument
        {
            {"Identifier", identifier },
            { "Status", 0 },
            { "Company", "GOV" },
            { "AirportICAO", hub },
            { "Level", 1 }
        };
        Collection.InsertOne(account);
        PilotService.Create(pilot);
        return true;
    }
}