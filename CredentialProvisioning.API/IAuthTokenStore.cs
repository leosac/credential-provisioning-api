namespace Leosac.CredentialProvisioning.API
{
    public interface IAuthTokenStore
    {
        Task<string> GetToken();

        void SetToken(string token);

        void ClearToken();
    }
}
