using System.Security.Claims;

namespace JWTExample.Interfaces
{
    public interface IPrincipalAccessor
    {
        ClaimsPrincipal CurrentPrincipal { get; set; }
    }
}