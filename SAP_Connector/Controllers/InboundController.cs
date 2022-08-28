using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using ActionNameAttribute = Microsoft.AspNetCore.Mvc.ActionNameAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using ControllerBase = Microsoft.AspNetCore.Mvc.ControllerBase;
using Microsoft.Extensions.Configuration;
using SAP_Connector.Model;
using Microsoft.VisualBasic;
using System.Data;
using System.Web.Mvc;


namespace SAP_Connector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class InboundController : ControllerBase
    {
    
       

        #region "Properties"
        private readonly IHttpClientFactory _ClientFactory;
        
        private IConfiguration configuration;
        private Sap.Data.Hana.HanaConnection con = new Sap.Data.Hana.HanaConnection();

        #endregion

        public InboundController(IHttpClientFactory clientFactory, IConfiguration iconfig)
        {
            _ClientFactory = clientFactory;
            configuration = iconfig;
        }

    
    }
   
}
