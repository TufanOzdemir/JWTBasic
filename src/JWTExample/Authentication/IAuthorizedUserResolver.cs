namespace JWTExample.Interfaces
{
    public interface IAuthorizedUserResolver
    {
        int GetUserId { get; }
        string GetUserName { get; }
        int GetBranchId { get; }
    }
}