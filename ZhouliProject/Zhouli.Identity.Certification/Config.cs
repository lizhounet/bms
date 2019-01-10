using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zhouli.Identity.Certification
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new ApiResource[] {
                new ApiResource("Zhouli.BlogWebApi", "周黎的博客Api"),
                new ApiResource("Zhouli.FileService", "周黎的文件服务Api")
            };
        }
        public static IEnumerable<Client> GetClients()
        {
            return new Client[] { new Client {
            ClientId = "zhouli",
            // 没有交互性用户，使用 clientid/secret 实现认证。
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            // 用于认证的密码
            ClientSecrets =
            {
                new Secret("991022".Sha256())
            },
            // 客户端有权访问的范围（Scopes）
            AllowedScopes = { "Zhouli.BlogWebApi", "Zhouli.FileService" }
            } };
        }
    }
}
