using MongoDB.Bson;
using Newtonsoft.Json;
/*
 * 本文件是 OpenVMS 的一部分。

 * OpenVMS 是自由软件：你可以再分发之和/或依照由自由软件基金会发布的 GNU 通用公共许可证修改之，无论是版本 3 许可证，还是（按你的决定）任何以后版都可以。

 * 发布 OpenVMS 是希望它能有用，但是并无保障;甚至连可销售和符合某个特定的目的都不保证。请参看 GNU 通用公共许可证，了解详情。

 * 你应该随程序获得一份 GNU 通用公共许可证的复本。如果没有，请看 <https://www.gnu.org/licenses/>。
 */
namespace OpenVMS.Models;
//==================================================
/**
 * This file defines Aircraft class
 */
//==================================================
public class Aircraft : ModelBase
{
    private string AirportICAO;//Indicate where this aircraft located
    private string HubICAO;//Indicate where the aircraft can be maintained at the lowest price
    private string Icao;//Kind of this aircraft
    private string Name;//Name of this aircraft
    private float FlightTime;//Total flight time of this aircraft
    private float MTOW;//Maximum take off weight
    private float ZFW;//Zero fuel weight
    
    public Aircraft(object aircraft)
    {
        Table = "aircraft";
        Obj = aircraft;
    }

    /**
     * Get Database Identifier of this aircraft
     */
    public BsonObjectId GetDataIdAttribute()
    {
        return JsonConvert.DeserializeObject<Aircraft>(Obj.ToString()).DataBaseID;
    }
    
    /**
     * Get registration number of this aircraft
     */
    public string GetIdentAttribute()
    {
        return JsonConvert.DeserializeObject<Aircraft>(Obj.ToString()).Identifier;
    }
    
    /**
     * Get if this aircraft is activated
     * Return Y - Activated / N - Not Activated
     */
    public int GetStatusAttribute()
    {
        return JsonConvert.DeserializeObject<Aircraft>(Obj.ToString()).Status;//Aircraft Active Attribute should be Y/N
    }
}