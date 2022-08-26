using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SAP_Connector.Model
{
public class LoginCls
{     
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SERVICE_METHODNAME { get; set; }

        public async Task<string> GetTokenAsync(IConfiguration config, IHttpClientFactory clientFactory)
        {
            var url = config["ConnectionStrings:BaseURL"];
            var request = new HttpRequestMessage(HttpMethod.Post, url + "/" + "Token");

            request.Headers.Add("SERVICE_METHODNAME", "GetToken");
            request.Headers.Add("UserName", config["ConnectionStrings:UserName"]);
            request.Headers.Add("Password", config["ConnectionStrings:Password"]);

            var client = clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            result SPD = null;
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                SPD = Newtonsoft.Json.JsonConvert.DeserializeObject<result>(result);
                return SPD.Response.Access_Token;
            }
            else
            {
                var responsestream = await response.Content.ReadAsStringAsync();
                SPD = Newtonsoft.Json.JsonConvert.DeserializeObject<result>(responsestream);
                return null;
            }
        }
    }
    public class result
    {
        public response Response { get; set; }
    }
    public class response
    {
        public string Result { get; set; }
        public string Access_Token { get; set; }
    }
}

