using MongoDB.Bson;
using Newtonsoft.Json;

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