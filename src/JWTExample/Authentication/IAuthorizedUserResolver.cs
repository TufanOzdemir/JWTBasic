namespace JWTExample.Interfaces
{
    public interface IAuthorizedUserResolver
    {
        int GetUserId { get; }
        string GetUserName { get; }
        string GetMail { get; }
        string GetFullname { get; }
    }
}