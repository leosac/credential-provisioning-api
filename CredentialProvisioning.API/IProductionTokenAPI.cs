using Leosac.CredentialProvisioning.Core.Models;
using Leosac.CredentialProvisioning.Server.Contracts.Models;
using Refit;

namespace Leosac.CredentialProvisioning.API
{
    [Headers("Authorization: Bearer")]
    public interface IProductionTokenAPI
    {
        [Post("/CreateToken")]
        Task<string> CreateToken(ProductionTokenRequest request);

        [Post("/CreateCredential")]
        Task<ObjectIdResponse<Guid?>> CreateCredential(string token);

        [Get("/GetProductionToken")]
        Task<ProductionToken> GetProductionToken(string token, bool waitForProductionCompletion);

        [Get("/GetProductionSets")]
        Task<IEnumerable<ProductionSet>> GetProductionSets();

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

        [Post("/UpdateCredentialDataValueEx")]
        Task UpdateCredentialDataValueEx(string token, Guid credId, Guid dataId, [Body(BodySerializationMethod.Serialized)] string value);

        [Put("/UpdateCredentialDataValueByName")]
        Task UpdateCredentialDataValueByName(string token, Guid credId, string name, string value);

        [Post("/UpdateCredentialDataValueByNameEx")]
        Task UpdateCredentialDataValueByNameEx(string token, Guid credId, string name, [Body(BodySerializationMethod.Serialized)]string value);

        [Get("/GetCredentialFragments")]
        Task<IEnumerable<CredentialFragment>> GetCredentialFragments(string token, Guid credId);

        [Put("/PrepareCredentialFragment")]
        Task PrepareCredentialFragment(string token, Guid fragmentId);

        [Put("/ChangeCredentialState")]
        Task ChangeCredentialState(string token, Guid credId, ProvisioningState state);

        [Put("/ReleaseCredentialLock")]
        Task ReleaseCredentialLock(string token, Guid credId);

        [Put("/ChangeCredentialFragmentState")]
        Task ChangeCredentialFragmentState(string token, Guid fragmentId, ProvisioningState state);

        [Put("/ChangeProductionSetState")]
        Task ChangeProductionSetState(string token, ProvisioningState state);

        [Get("/GetWorker")]
        Task<GetWorkerResponse> GetWorker(string token, Guid fragmentId);

        [Get("/GetCredentialFragmentTemplate")]
        Task<CredentialFragmentTemplate> GetCredentialFragmentTemplate(string token, Guid fragmentTemplateId);

        [Get("/GetCredentialFragmentKeys")]
        Task<CredentialKey[]> GetCredentialFragmentKeys(string token, Guid? fragmentId, CredentialKeyScope scope, DateTime? updatedAfter = null, Guid[]? keyIds = null);

        [Put("/NotifyCredentialQueued")]
        Task NotifyCredentialQueued(string token, Guid credId);
    }
}
