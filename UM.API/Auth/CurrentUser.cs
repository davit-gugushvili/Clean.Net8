using System.Security.Claims;
using UM.Application.Interfaces;

namespace UM.API.Auth
{
    public class CurrentUser(IHttpContextAccessor httpContextAccessor)
        : ICurrentUser
    {
        public int? Id
        {
            get
            {
                var userId = httpContextAccessor.HttpContext?.User?.FindFirstValue("sub");

                return !string.IsNullOrEmpty(userId) ? Convert.ToInt32(userId) : null;
            }
        }
    }
}