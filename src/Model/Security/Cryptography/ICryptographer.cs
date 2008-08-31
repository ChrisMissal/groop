namespace CRIneta.Model.Security.Cryptography
{
    public interface ICryptographer
    {
        string CreateSalt();
        string Hash(string input, string salt);
    }
}