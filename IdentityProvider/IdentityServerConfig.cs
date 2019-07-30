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
                yield return new Client();
            }
        }

        public static IEnumerable<ApiResource> Resources { get {
                yield return new ApiResource()
                {

                };
            } }
        public static List<TestUser> TestUsers { get; internal set; }
    }
}
