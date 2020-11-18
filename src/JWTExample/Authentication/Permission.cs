namespace JWTExample.Authentication
{
    public class Permission
    {
        public string PermissionCode { get; private set; }

        public Permission(string permissionCode)
        {
            PermissionCode = permissionCode;
        }
    }
}