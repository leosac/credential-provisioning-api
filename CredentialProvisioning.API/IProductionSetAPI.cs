using Leosac.CredentialProvisioning.Core.Models;
using Refit;

namespace Leosac.CredentialProvisioning.API
{
    [Headers("Authorization: Bearer")]
    public interface IProductionSetAPI
    {
        [Get("/Get")]
        Task<ProductionSet> Get(Guid objId);

        [Get("/GetAllFiltered")]
        Task<IEnumerable<ProductionSet>> GetAll(ProvisioningState? filterState = ProvisioningState.Default);
    }
}
