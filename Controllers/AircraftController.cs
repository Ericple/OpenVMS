using OpenVMS.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using OpenVMS.Models.Enums;
using OpenVMS.Security;

/*
 * 本文件是 OpenVMS 的一部分。

 * OpenVMS 是自由软件：你可以再分发之和/或依照由自由软件基金会发布的 GNU 通用公共许可证修改之，无论是版本 3 许可证，还是（按你的决定）任何以后版都可以。

 * 发布 OpenVMS 是希望它能有用，但是并无保障;甚至连可销售和符合某个特定的目的都不保证。请参看 GNU 通用公共许可证，了解详情。

 * 你应该随程序获得一份 GNU 通用公共许可证的复本。如果没有，请看 <https://www.gnu.org/licenses/>。
 */
namespace OpenVMS.Controllers;

[ApiController]
[Route("/api/aircraft")]
//==================================
// This file defines aircraft apis
//==================================
public class AircraftController : ControllerBase
{
    private static readonly AircraftService Service = new();
    // private static readonly ApiKeyAuthenticationService AuthenticationService = new();
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
     if (!ApiKeyAuthenticationService.Auth(apikey,ApiKeyPermission.Mid))
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
     if (!ApiKeyAuthenticationService.Auth(apikey,ApiKeyPermission.Mid))
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
     if (!ApiKeyAuthenticationService.Auth(apikey,ApiKeyPermission.High))
     {
      return BadRequest();
     }
     Service.Delete(identifier);
     return Ok();
    }
}