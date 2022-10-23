using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace OpenVMS.Auth;

[ApiController]
[Route("/api/auth")]
public class AuthController : ControllerBase
{
    private static readonly AuthService Service = new ();

    [HttpPatch("{token}/{clientIdentifier}")]
    public ActionResult<bool> Validate(string token, string clientIdentifier)
    {
        if (Service.Validate(token,clientIdentifier))
        {
            return Ok();
        }

        return BadRequest();
    }

    [HttpPost("{identifier}/{clientIdentifier}")]
    public ActionResult<string> Create(string identifier, string clientIdentifier)
    {
        var token = Service.GenerateToken(18);
        var authObj = new BsonDocument
        {
            { "Token", token },
            { "Identifier", identifier },
            { "ClientIdentifier", clientIdentifier },
            { "Status", false }
        };
        Service.Create(authObj);
        return token;
    }

    [HttpDelete("{identifier}")]
    public ActionResult<long> Delete(string identifier)
    {
        if (Service.Delete(identifier) > 0)
        {
            return Ok();
        }

        return BadRequest();
    }
}