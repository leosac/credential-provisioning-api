using Leosac.CredentialProvisioning.Server.Contracts.Models;
using Refit;

namespace Leosac.CredentialProvisioning.API
{
    public interface IAuthenticationAPI
    {
        [Post("/User/Authenticate")]
        Task<AuthenticationToken> Authenticate(AuthenticateWithUserPwdRequest request);
    }
}
