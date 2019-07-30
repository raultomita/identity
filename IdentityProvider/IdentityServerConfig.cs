using System.Collections.Generic;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityProvider
{
    public class IdentityServerConfig
    {
        public static IEnumerable<Client> Clients
        {
            get
            {
                yield return new Client
                {
                    ClientId = "ConsoleClient",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes = { "mainApi.fullAccess" }
                };
            }
        }

        public static IEnumerable<ApiResource> Resources
        {
            get
            {
                yield return new ApiResource
                {
                    Name = "mainApi",
                    DisplayName = "Main API",
                    Scopes = {
                        new Scope("mainApi.fullAccess"),
                        new Scope("mainApi.readOnly")
                    }
                };
            }
        }
        public static List<TestUser> TestUsers
        {
            get
            {
                return new List<TestUser>
                {
                    new TestUser()
                    {
                        SubjectId="1",
                        Username = "user1",
                        Password = "pass"
                    },
                    new TestUser()
                    {
                        SubjectId="2",
                        Username = "user2",
                        Password = "pass"
                    }
                };
            }
        }
    }
}
