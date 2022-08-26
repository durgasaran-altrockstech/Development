using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SAP_Connector.Controllers;

namespace Zoho_SAP_Integration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : BaseController
    {
        private Sap.Data.Hana.HanaConnection con = new Sap.Data.Hana.HanaConnection();            
        private IConfiguration _config;      
        public AuthenticateController(IConfiguration config)
        {
            _config = config;
        }      
     
        private string GenerateJSONWebToken(LoginModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }      
      
        private async Task<LoginModel> AuthenticateUser(LoginModel login)
        {
            LoginModel user = null;
            if (login.UserName == "Mipl" && login.Password == "2022")
            {
                user = new LoginModel { UserName = "Mipl", Password = "2022" };
            }
            return user;
        }

        [AllowAnonymous]
        [HttpPost(nameof(GenerateToken))]
        public async Task<IActionResult> GenerateToken([FromBody] LoginModel data)
        {
            IActionResult response = Unauthorized();
            var user = await AuthenticateUser(data);
            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { Token = tokenString, Message = "Success" });
            }
            return response;
        }      

    } 
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
   
}
