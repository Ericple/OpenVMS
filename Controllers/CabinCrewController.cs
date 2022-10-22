using OpenVMS.Services;
using Microsoft.AspNetCore.Mvc;
using OpenVMS.Models.Enums;

namespace OpenVMS.Controllers;
[ApiController]
[Route("cabincrew")]
//===================================
//This file defines cabin crew apis
//===================================
public class CabinCrewController : ControllerBase
{
    private static readonly CabinCrewService Service = new();
    private static readonly ApiKeyAuthenticationService AuthenticationService = new();

    /**
     * Get all cabin crew in database
     */
    [HttpGet]
    public ActionResult<object> Get() => Service.Get();

    /**
     * Get cabin crew with certain name
     */
    [HttpGet("{identifier}")]
    public ActionResult<object> Get(string identifier) => Service.Get(identifier);

    /**
     * Dismiss or hire a instance
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
}