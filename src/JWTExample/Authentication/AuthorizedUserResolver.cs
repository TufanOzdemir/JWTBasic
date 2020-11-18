using JWTExample.Interfaces;

namespace JWTExample.Authentication
{
    public class AuthorizedUserResolver : IAuthorizedUserResolver
    {
        private IDomainPrincipal _principal;

        public AuthorizedUserResolver(IDomainPrincipal principal)
        {
            _principal = principal;
        }

        public int GetUserId => _principal.Id;

        public string GetUserName => _principal.Name;

        public string GetMail => _principal.Email;
        public string GetFullname => string.Concat(_principal.Name, " ", _principal.Surname);
    }
}