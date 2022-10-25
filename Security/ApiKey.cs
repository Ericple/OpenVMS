using MongoDB.Bson;
using OpenVMS.Models.Enums;

namespace OpenVMS.Security;
/*
 * 本文件是 OpenVMS 的一部分。

 * OpenVMS 是自由软件：你可以再分发之和/或依照由自由软件基金会发布的 GNU 通用公共许可证修改之，无论是版本 3 许可证，还是（按你的决定）任何以后版都可以。

 * 发布 OpenVMS 是希望它能有用，但是并无保障;甚至连可销售和符合某个特定的目的都不保证。请参看 GNU 通用公共许可证，了解详情。

 * 你应该随程序获得一份 GNU 通用公共许可证的复本。如果没有，请看 <https://www.gnu.org/licenses/>。

 * 2022/10/24 Guo Tingjin dev@peercat.cn

 */
public class ApiKey
{
    public string Value;
    public int Permission;

    public ApiKey(string value, int permission)
    {
        Value = value;
        Permission = permission;
    }
}