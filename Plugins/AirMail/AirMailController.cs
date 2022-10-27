using Microsoft.AspNetCore.Mvc;

namespace OpenVMS.Plugins.AirMail;

[ApiController]
[Route("airmail")]
public class AirMailController : ControllerBase
{
    private AirMailService Service = new();

    [HttpGet]
    public ActionResult<string> Get(string identifier) => Service.Get(identifier).ToString();

    [HttpPost]
    public ActionResult Send(string sender,string receiver,string subject,string content)
    {
        var airMail = new AirMail(sender, receiver.Split(","), subject, content);
        Service.Send(airMail);
        return Ok();
    }
}