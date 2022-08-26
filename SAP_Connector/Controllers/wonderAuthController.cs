
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SAP_Connector.Model;

namespace SAP_Connector.Controllers
{
    [ApiController]
    [Route("")]
    public class wonderAuthController : BaseController
    {
        private IConfiguration _config;
        private readonly IHttpClientFactory _ClientFactory;
        LoginCls login = new LoginCls();
        public wonderAuthController(IHttpClientFactory clientFactory, IConfiguration config)
        {
            _ClientFactory = clientFactory;
            _config = config;          
        }

        [AllowAnonymous]
        [HttpPost(nameof(Token))]
        private async Task<string> Token()
        {
            return await login.GetTokenAsync(_config,_ClientFactory);
        }
        
    }
}