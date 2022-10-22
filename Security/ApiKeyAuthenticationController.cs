using Microsoft.AspNetCore.Mvc;
using OpenVMS.Models.Enums;
using OpenVMS.Services;

namespace OpenVMS.Controllers;
//=====================================
//
//=====================================
[ApiController]
[Route("apikey")]
public class ApiKeyAuthenticationController : ControllerBase
{
    private static readonly ApiKeyAuthenticationService Service = new();
    [HttpPost("{value}/{permission}/{apikey}")]
    public ActionResult<bool> Create(string value, int permission, string apikey)
    {
        if (Service.Auth(apikey,ApiKeyPermission.Top))
        {
            Service.Create(value, permission);
            return Ok();
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpDelete("{value}/{apikey}")]
    public ActionResult<long> Delete(string value, string apikey)
    {
        if (!Service.Auth(apikey,ApiKeyPermission.Top))
        {
            return BadRequest();
        }
        Service.Delete(value);
        return Ok();
    }
}