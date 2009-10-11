namespace Groop.Core.Domain
{
    public interface IContactMessage
    {
        string Email { get; }
        string Name { get; }
        string Subject { get; }
        string Message { get; }
    }
}