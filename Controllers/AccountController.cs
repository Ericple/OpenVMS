using Microsoft.AspNetCore.Mvc;
using NETVMS.Services;

namespace NETVMS.Controllers;

[ApiController]
[Route("account")]
public class AccountController : ControllerBase
{
    private static readonly AccountService Service = new();
    
    [HttpGet("{identifier},{pass}")]
    public ActionResult<bool> Auth(string identifier, string pass)
    {
        if (Service.Auth(identifier,pass))
        {
            return Ok();
        }

        return BadRequest();
    }
}