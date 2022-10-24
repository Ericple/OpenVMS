using OpenVMS.Services;
using Microsoft.AspNetCore.Mvc;

namespace OpenVMS.Controllers;

[ApiController]
[Route("/api/pilot")]
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

    /**
     * Resign or transfer a pilot
     */
    [HttpPatch("{identifier}/{target}")]
    public ActionResult<long> Transfer(string identifier, string target) => Service.Transfer(identifier,target);
}