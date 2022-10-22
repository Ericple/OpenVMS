using NETVMS.Services;
using Microsoft.AspNetCore.Mvc;

namespace NETVMS.Controllers;

[ApiController]
[Route("pilot")]
public class PilotController : ControllerBase
{
    private static readonly PilotService Service = new();

    /**
     * Get all pilots in database
     */
    [HttpGet]
    public ActionResult<object> Get() => Service.Get();

    /**
     * Get pilot with specific identifier
     */
    [HttpGet("{identifier}")]
    public ActionResult<object> Get(string identifier) => Service.Get(identifier);
}