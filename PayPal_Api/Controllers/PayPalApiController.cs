using System.Threading.Tasks;
using APIWrapper.Client;
using APIWrapper.Responses;
using Microsoft.AspNetCore.Mvc;

namespace PayPal_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayPalApiController : Controller
    {
        private readonly IPayPalClient _payPalClient;

        public PayPalApiController(IPayPalClient payPalClient)
        {
            _payPalClient = payPalClient;
        }
        
        // GET
        [HttpGet]
        public async Task<ActionResult<Response<GetAcessTokenResponse>>> GetAccessTokenAsync()
        {
            var response = await _payPalClient.GetTokenAsync();
            return StatusCode(response.StatusCode, response);
        }
    }
}