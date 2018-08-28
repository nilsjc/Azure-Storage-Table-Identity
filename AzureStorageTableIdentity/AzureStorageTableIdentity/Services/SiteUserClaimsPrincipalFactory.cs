using AzureStorageTableIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AzureStorageTableIdentity.Services
{
    class SiteUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<SiteUser>
    {
        public SiteUserClaimsPrincipalFactory(UserManager<SiteUser> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(SiteUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            return identity;
        }
    }
}
