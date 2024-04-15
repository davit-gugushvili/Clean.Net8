using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace UM.Infrastructure.Security
{
    internal static class ClaimsPrincipalExtensions
    {
        private const string JwtSubjectClaim = "sub";

        public static int GetUserId(this ClaimsPrincipal? principal)
        {
            var userId = principal?.FindFirstValue(JwtSubjectClaim);

            return int.TryParse(userId, out int parsedUserId) 
                ? parsedUserId 
                : throw new ApplicationException("Current User Id Unavailable");
        }
    }
}
