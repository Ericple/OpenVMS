using MongoDB.Bson;
using Newtonsoft.Json;

namespace OpenVMS.Models;
//==================================================
// This file defines Cabin Crew class
//==================================================

public class CabinCrew : ModelBase
{
    private string AirportICAO;//Indicate where this cabin crew located
    private int Skill;//Indicate skill level of this cabin crew

    public CabinCrew(object cabinCrew)
    {
        Table = "cabinCrew";
        Obj = cabinCrew;
    }
    
    /**
     * Get Database Identifier of this cabin crew
     */
    public BsonObjectId GetDataIdAttribute()
    {
        return JsonConvert.DeserializeObject<CabinCrew>(Obj.ToString()).DataBaseID;
    }

    /**
     * Get Identity of this cabin crew
     */
    public string GetIdentAttribute()
    {
        return JsonConvert.DeserializeObject<CabinCrew>(Obj.ToString()).Identifier;
    }

    /**
     * Get if this cabin crew is activated
     */
    public int GetStatusAttribute()
    {
        return JsonConvert.DeserializeObject<CabinCrew>(Obj.ToString()).Status;
    }
}