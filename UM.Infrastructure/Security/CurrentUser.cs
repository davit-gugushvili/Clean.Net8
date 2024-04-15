using Microsoft.AspNetCore.Http;

namespace UM.Infrastructure.Security
{
    public sealed class CurrentUser(IHttpContextAccessor httpContextAccessor)
        :ICurrentUser
    {
        public int Id => httpContextAccessor.HttpContext?.User.GetUserId() ?? throw new ApplicationException("Current User Unavailable");
    }
}