using Microsoft.AspNetCore.Mvc;
using OpenVMS.Services;

namespace OpenVMS.Controllers;

[ApiController]
[Route("/api/account")]
public class AccountController : ControllerBase
{
    private static readonly AccountService Service = new();
    
    [HttpGet("{identifier}/{pass}")]
    public ActionResult<bool> Auth(string identifier, string pass)
    {
        if (Service.Auth(identifier,pass))
        {
            return Ok();
        }

        return BadRequest();
    }

    [HttpPost("/idenetifier")]
    public ActionResult<bool> Create(
        string identifier, string email, string nickname, string pass, string hub)
        => Service.Create(identifier, email, nickname, pass, hub);
}