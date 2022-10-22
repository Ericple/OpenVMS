using NETVMS.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using NETVMS.Models.Enums;

namespace NETVMS.Controllers;

[ApiController]
[Route("aircraft")]
//==================================
// This file defines aircraft apis
//==================================
public class AircraftController : ControllerBase
{
    private static readonly AircraftService Service = new();
    private static readonly ApiKeyAuthenticationService AuthenticationService = new();
    /**
     * Get all aircraft in database
     */
    [HttpGet]
    public ActionResult<object> Get() => Service.Get();
    
    /**
     * Get aircraft with certain registration
     */
    [HttpGet("{identifier}")]
    public ActionResult<object> Get(string identifier) => Service.Get(identifier);
    
    /**
     * Create an new aircraft into database
     */
    [HttpPost("{identifier}/{location}/{company}/{icao}/{name}/{apikey}")]
    public ActionResult<string> Create(string identifier, string location, string company, string icao, string name, string apikey)
    {
     if (!AuthenticationService.Auth(apikey,ApiKeyPermission.Mid))
     {
      return BadRequest();
     }
     var aircraft = new BsonDocument
        {
            { "Identifier", identifier},
            {"Active",false},
            {"Status",1},
            {"Company",company},
            {"AirportICAO",location},
            {"HubICAO",location},
            {"Icao",icao},
            {"Name",name},
            {"FlightTime",0},
            {"MTOW",0},
            {"ZFW",0}
        };
        Service.Create(aircraft);
        return Ok();
    }

    /**
     * Transfer an aircraft to another
     */
    [HttpPatch("{identifier}/{target}/{apikey}")]
    public ActionResult<long> Transfer(string identifier, string target, string apikey)
    {
     if (!AuthenticationService.Auth(apikey,ApiKeyPermission.Mid))
     {
      return BadRequest();
     }
     Service.Transfer(identifier, target);
     return Ok();
    }

    /**
     * Delete an aircraft
     */
    [HttpDelete("{identifier}/{apikey}")]
    public ActionResult<long> Delete(string identifier, string apikey)
    {
     if (!AuthenticationService.Auth(apikey,ApiKeyPermission.High))
     {
      return BadRequest();
     }
     Service.Delete(identifier);
     return Ok();
    }
}