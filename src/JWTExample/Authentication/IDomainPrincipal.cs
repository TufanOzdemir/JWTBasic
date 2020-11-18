using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace JWTExample.Interfaces
{
    public interface IDomainPrincipal : IPrincipal
    {
        int Id { get; }
        string Name { get; }
        string FirstName { get; }
        int BranchId { get; }
        string Email { get; }
        Guid AccessToken { get; }
        IEnumerable<Claim> Claims { get; }
        bool IsInScheme(string schemes);
        Task<bool> Validate();
    }
}