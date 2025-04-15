using Leosac.CredentialProvisioning.Core.Models;
using Leosac.CredentialProvisioning.Server.Contracts.Models;
using Refit;

namespace Leosac.CredentialProvisioning.API
{
    [Headers("Authorization: Bearer")]
    public interface ICredentialKeyAPI
    {
        [Post("/Create")]
        Task<Guid> Create(CredentialKey key);

        [Delete("/Delete")]
        Task<Guid> Delete(Guid objId);

        [Get("/Get")]
        Task<CredentialKey> Get(Guid objId);

        [Get("/GetAll")]
        Task<IEnumerable<CredentialKeyItem>> GetAllFiltered(string[]? keyTypes = null);

        [Post("/Update")]
        Task Update(CredentialKey key);
    }
}
