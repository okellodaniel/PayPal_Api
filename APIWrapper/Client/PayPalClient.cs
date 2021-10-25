using System.Threading;
using System.Threading.Tasks;
using APIWrapper.Responses;
using APIWrapper.Utilities;
using Flurl.Http;
using Microsoft.Extensions.Configuration;

namespace APIWrapper.Client
{
    public class PayPalClient:IPayPalClient
    {
        private readonly IConfiguration _configuration;

        public PayPalClient(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public async Task<Response<GetAcessTokenResponse>> GetTokenAsync(CancellationToken cancellationToken = default)
        {
            var clientId = _configuration.GetValue<string>("Paypal:ClientId");
            var baseUrl = _configuration.GetValue<string>("Paypal:BaseUrl");
            var authUrl = _configuration.GetValue<string>("Paypal:AuthUrl");
            var clientSecret = _configuration.GetValue<string>("Paypal:ClientSecret");

            var result = await authUrl
                .AllowHttpStatus()
                .AppendPathSegment(EndPoints.GetAccessToken)
                .WithBasicAuth(clientId, clientSecret)
                .PostUrlEncodedAsync(new
                {
                    grant_type = "client_credentials"
                });

            if (result.StatusCode >= 300)
            {
                var error = await result.GetJsonAsync<ErrorResponse>();
                return new Response<GetAcessTokenResponse>()
                {
                    StatusCode = result.StatusCode,
                    Error = error
                };
            }

            var data = await result.GetJsonAsync<GetAcessTokenResponse>();

            return new Response<GetAcessTokenResponse>()
            {
                StatusCode = result.StatusCode,
                Data = data
            };
        }
    }
}