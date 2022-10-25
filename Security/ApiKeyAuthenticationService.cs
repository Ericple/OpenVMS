using MongoDB.Bson;
using MongoDB.Driver;
using OpenVMS.Auth;
using OpenVMS.Models.Enums;
using OpenVMS.Services;
using ZstdSharp.Unsafe;

/*
 * 本文件是 OpenVMS 的一部分。

 * OpenVMS 是自由软件：你可以再分发之和/或依照由自由软件基金会发布的 GNU 通用公共许可证修改之，无论是版本 3 许可证，还是（按你的决定）任何以后版都可以。

 * 发布 OpenVMS 是希望它能有用，但是并无保障;甚至连可销售和符合某个特定的目的都不保证。请参看 GNU 通用公共许可证，了解详情。

 * 你应该随程序获得一份 GNU 通用公共许可证的复本。如果没有，请看 <https://www.gnu.org/licenses/>。

 * 2022/10/24 Guo Tingjin dev@peercat.cn

 */
namespace OpenVMS.Security;

public class ApiKeyAuthenticationService
{
    private int _rep = 0;
    public static List<ApiKey> KeyCollection = new();

    public void Get()
    {
        System.Console.WriteLine("{0} ApiKey found",KeyCollection.Count);
        foreach (var apiKey in KeyCollection)
        {
            System.Console.WriteLine("{0}\t{1}",apiKey.Value,apiKey.Permission);
        }
    }
    public static bool Auth(string apikey,int permission)
    {
        
        foreach (var key in KeyCollection)
        {
            if (apikey == key.Value && permission >= key.Permission)
            {
                System.Console.WriteLine("No Match key");
                return true;
            }
        }

        return false;
    }

    public bool Create(string value, int permission)
    {
        KeyCollection.Insert(KeyCollection.Count,new ApiKey(value,permission));
        System.Console.WriteLine("Key Count: {0}",KeyCollection.Count);
        return true;
    }

    // public long Delete(string value)
    // {
    //     
    //     return _apiKeyCollection.DeleteOne(Builders<BsonDocument>.Filter.Eq("Value", value)).DeletedCount;
    // }
    public string Random()
    {
        string str = string.Empty;
        long num2 = DateTime.Now.Ticks + this._rep;
        this._rep++;
        Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> this._rep)));
        for (int i = 0; i < 20; i++)
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
    public string Generate(int permission)
    {
        var value = Random();
        if (Create(value, permission))
        {
            return value;
        }
        return "fail";
    }
}