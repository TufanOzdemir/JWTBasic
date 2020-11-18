using JWTExample.Interfaces;
using System.Security.Claims;

namespace JWTExample.Authentication
{
    public class PrincipalAccessor : IPrincipalAccessor
    {
        public ClaimsPrincipal CurrentPrincipal { get; set; }
    }
}