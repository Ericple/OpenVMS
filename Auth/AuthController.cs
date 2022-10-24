using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
/*
 * 本文件是 OpenVMS 的一部分。

 * OpenVMS 是自由软件：你可以再分发之和/或依照由自由软件基金会发布的 GNU 通用公共许可证修改之，无论是版本 3 许可证，还是（按你的决定）任何以后版都可以。

 * 发布 OpenVMS 是希望它能有用，但是并无保障;甚至连可销售和符合某个特定的目的都不保证。请参看 GNU 通用公共许可证，了解详情。

 * 你应该随程序获得一份 GNU 通用公共许可证的复本。如果没有，请看 <https://www.gnu.org/licenses/>。
 */
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