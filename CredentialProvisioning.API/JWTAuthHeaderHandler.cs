using System.Net.Http.Headers;

namespace Leosac.CredentialProvisioning.API
{
    public class JWTAuthHeaderHandler : DelegatingHandler
    {
        private readonly IAuthTokenStore authTokenStore;

        public JWTAuthHeaderHandler(IAuthTokenStore authTokenStore, bool useDependencyInjection = true /* Temporary fix for https://github.com/reactiveui/refit/issues/1403 */)
        {
            this.authTokenStore = authTokenStore ?? throw new ArgumentNullException(nameof(authTokenStore));

            if (useDependencyInjection)
                return;

            InnerHandler = new HttpClientHandler();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await authTokenStore.GetToken();

            //potentially refresh token here if it has expired etc.

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
