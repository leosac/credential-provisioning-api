using Leosac.CredentialProvisioning.Core.Models;
using Leosac.CredentialProvisioning.Server.Contracts.Models;
using Refit;

namespace Leosac.CredentialProvisioning.API
{
    public interface IProductionTokenAPI
    {
        [Post("/CreateToken")]
        Task<string> CreateToken(ProductionTokenRequest request);

        [Get("/GetNextCredentialId")]
        Task<ObjectIdResponse<Guid?>> GetNextCredentialId(string token, Guid? credId = null);

        [Get("/GetPreviousCredentialId")]
        Task<ObjectIdResponse<Guid?>> GetPreviousCredentialId(string token, Guid credId);

        [Get("/GetCredential")]
        Task<CredentialBase> GetCredential(string token, Guid credId);

        [Get("/GetCredentialData")]
        Task<IEnumerable<CredentialDataValue>> GetCredentialData(string token, Guid credId, DateTime? updatedAfter = null);

        [Put("/UpdateCredentialDataValue")]
        Task UpdateCredentialDataValue(string token, Guid credId, Guid dataId, string value);

        [Put("/UpdateCredentialDataValueByName")]
        Task UpdateCredentialDataValueByName(string token, Guid credId, string name, string value);

        [Get("/GetCredentialFragments")]
        Task<IEnumerable<CredentialFragment>> GetCredentialFragments(string token, Guid credId);

        [Put("/PrepareCredentialFragment")]
        Task PrepareCredentialFragment(string token, Guid fragmentId);

        [Put("/ChangeCredentialState")]
        Task ChangeCredentialState(string token, Guid credId, ProvisioningState state);

        [Put("/ChangeCredentialFragmentState")]
        Task ChangeCredentialFragmentState(string token, Guid fragmentId, ProvisioningState state);

        [Put("/ChangeProductionSetState")]
        Task ChangeProductionSetState(string token, ProvisioningState state);

        [Get("/GetWorker")]
        Task<GetWorkerResponse> GetWorker(string token, Guid fragmentId);

        [Get("/GetCredentialFragmentTemplate")]
        Task<CredentialFragmentTemplate> GetCredentialFragmentTemplate(string token, Guid fragmentTemplateId);

        [Get("/GetCredentialFragmentKeys")]
        Task<CredentialKey[]> GetCredentialFragmentKeys(string token, Guid fragmentId, CredentialKeyScope scope, Guid[]? keyIds = null);

        [Put("/NotifyCredentialQueued")]
        Task NotifyCredentialQueued(string token, Guid credId);
    }
}
