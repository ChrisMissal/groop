namespace Groop.Core.Validation
{
    public interface IValidator
    {
        bool IsValid<T>(T type);
    }
}