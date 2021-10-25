using System.Threading;
using System.Threading.Tasks;
using APIWrapper.Responses;

namespace APIWrapper.Client
{
    public interface IPayPalClient
    {
        Task<Response<GetAcessTokenResponse>> GetTokenAsync(CancellationToken cancellationToken = default);
    }
}