using MongoDB.Bson;
using MongoDB.Driver;
using OpenVMS.Services;

namespace OpenVMS.Auth;

public class AuthService : ServiceBase
{
    private int _rep;
    public AuthService(string connectionString, string databaseName, string collectionName)
    {
        DataClient = new(connectionString);
        Database = DataClient.GetDatabase(databaseName);
        Collection = Database.GetCollection<BsonDocument>(collectionName);
    }

    public AuthService()
    {
        DataClient = new("mongodb://127.0.0.1:27017/");
        Database = DataClient.GetDatabase("OpenVMS");
        Collection = Database.GetCollection<BsonDocument>("Auth");
    }

    public bool Validate(string token, string clientIdentifier)
    {
        if (Collection.Find(Builders<BsonDocument>.Filter.Eq("Token", token) &
                            Builders<BsonDocument>.Filter.Eq("ClientIdentifier", clientIdentifier)).CountDocuments() ==
            1)
        {
            Collection.UpdateOne(Builders<BsonDocument>.Filter.Eq("Token", token),
                Builders<BsonDocument>.Update.Set("Status", true));
            return true;
        }

        return false;
    }
    
    public string GenerateToken(int codeCount)
    {
        string str = string.Empty;
        long num2 = DateTime.Now.Ticks + this._rep;
        this._rep++;
        Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> this._rep)));
        for (int i = 0; i < codeCount; i++)
        {
            char ch;
            int num = random.Next();
            if ((num % 2) == 0)
            {
                ch = (char)(0x30 + ((ushort)(num % 10)));
            }
            else
            {
                ch = (char)(0x41 + ((ushort)(num % 0x1a)));
            }
            str = str + ch.ToString();
        }
        return str;
    }
}