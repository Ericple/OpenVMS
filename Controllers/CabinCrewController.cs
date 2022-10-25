using OpenVMS.Services;
using Microsoft.AspNetCore.Mvc;
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
[Route("/api/cabincrew")]
//===================================
//This file defines cabin crew apis
//===================================
public class CabinCrewController : ControllerBase
{
    private static readonly CabinCrewService Service = new();

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
     if (!ApiKeyAuthenticationService.Auth(apikey,ApiKeyPermission.Mid))
     {
      return BadRequest();
     }
     Service.Transfer(identifier, target);
     return Ok();
    }
}