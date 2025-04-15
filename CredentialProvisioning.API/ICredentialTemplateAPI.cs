using Leosac.CredentialProvisioning.Core.Models;
using Refit;

namespace Leosac.CredentialProvisioning.API
{
    [Headers("Authorization: Bearer")]
    public interface ICredentialTemplateAPI
    {
        [Get("/Get")]
        Task<CredentialTemplate> Get(string objId);
    }
}
