using Refit;

namespace Leosac.CredentialProvisioning.API
{
    public interface IServerInfoAPI
    {
        [Headers("Authorization: Bearer")]
        [Get("/GetAttributes")]
        Task<string[]> GetAttributes();

        [Get("/GetAPIVersion")]
        Task<string> GetAPIVersion();
    }
}
