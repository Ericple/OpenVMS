using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
// using OpenVMS.Plugins.ViewEngine;

namespace OpenVMS.Plugins.Example;

[ApiController]
[Route("example")]
public class ExampleController : Controller
{
    private ExampleService Service = new();
    private Path Path = new Path();
    // private View viewEngine;

    [HttpGet]
    [ActionName("Index")]
    public IActionResult Index()
    {
        return View("Index");
    }
}