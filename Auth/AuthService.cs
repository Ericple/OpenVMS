using MongoDB.Bson;
using MongoDB.Driver;
using OpenVMS.Services;
/*
 * 本文件是 OpenVMS 的一部分。

 * OpenVMS 是自由软件：你可以再分发之和/或依照由自由软件基金会发布的 GNU 通用公共许可证修改之，无论是版本 3 许可证，还是（按你的决定）任何以后版都可以。

 * 发布 OpenVMS 是希望它能有用，但是并无保障;甚至连可销售和符合某个特定的目的都不保证。请参看 GNU 通用公共许可证，了解详情。

 * 你应该随程序获得一份 GNU 通用公共许可证的复本。如果没有，请看 <https://www.gnu.org/licenses/>。
 */
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