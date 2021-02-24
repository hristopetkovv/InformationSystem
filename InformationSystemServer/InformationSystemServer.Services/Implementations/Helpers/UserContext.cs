using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;

namespace InformationSystemServer.Services.Implementations.Helpers
{
    public class UserContext
    {
        public UserContext(IHttpContextAccessor context)
        {
            var user = context.HttpContext.User;

            int.TryParse(this.GetClaimValue(user, "userId"), out int userId);
            this.UserId = userId;
            this.Role = this.GetClaimValue(user, ClaimTypes.Role);
            this.UserName = this.GetClaimValue(user, ClaimTypes.Name);
        }

        public int? UserId { get; private set; }

        public string Role { get; private set; }

        public string UserName { get; private set; }

        private string GetClaimValue(ClaimsPrincipal claimsPrincipal, string claimName)
        {
            var claimValue = claimsPrincipal.Claims.FirstOrDefault(e => e.Type == claimName);

            return claimValue?.Value;
        }
    }
}
