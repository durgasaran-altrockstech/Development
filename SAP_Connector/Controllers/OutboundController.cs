using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SAP_Connector.Model;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;
using SAP_POS_Integration.Model;
using System.Net;

namespace SAP_Connector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class OutboundController : ControllerBase
    {
        string MDBMainName;
        string Connstring;
        private Sap.Data.Hana.HanaConnection con = new Sap.Data.Hana.HanaConnection();
        private IConfiguration _config;
        private readonly IHttpClientFactory _ClientFactory;        
        LoginCls  login =new LoginCls();
        public OutboundController(IHttpClientFactory clientFactory, IConfiguration config)
        {
            _ClientFactory = clientFactory;
            _config = config;               
        }
        private bool SPHANACon()
        {
            try
            {
                Console.WriteLine("Hana Connection Initated");
                MDBMainName = _config["ConnectionStrings:DBName"];
                Connstring = _config["ConnectionStrings:HANA"];
                con = new Sap.Data.Hana.HanaConnection(Connstring);
                con.Open();
                Console.WriteLine("Hana Connection Successfull");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hana Connection Failed" + ex.ToString());
                return false;
            }
        }
         
        [HttpPost(nameof(PostBPMaster))]
        public async Task<string> PostBPMaster()
        {
            var token= await login.GetTokenAsync(_config, _ClientFactory);
            var url = _config["ConnectionStrings:BaseURL"];
            var request = new HttpRequestMessage(HttpMethod.Post, url + "/" + "ProcessData");
            request.Headers.Add("SERVICE_METHODNAME", "PushCustomer");
            request.Headers.Add("AUTHORIZATION", token.Trim());
            
            var content = "";            
            var Customer= getCustomer();
            var data = JsonConvert.SerializeObject(Customer);         
            if (data != null)
            {               
                content = data;
                request.Content = new StringContent(content, Encoding.UTF8, "application/json");
            }

            var client = _ClientFactory.CreateClient();
            var response = await client.SendAsync(request);
            result SPD = null;
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();             
                return "success";
            }
            else
            {
                var responsestream = await response.Content.ReadAsStringAsync();
                SPD = Newtonsoft.Json.JsonConvert.DeserializeObject<result>(responsestream);
                return null;
            }
        }

         
        [HttpGet(nameof(GLAccounts))]
        public async Task<string> GLAccounts()
        {
            SPHANACon();
            String SapSql = "";

            SapSql += Constants.vbCrLf + "select \"AcctCode\",\"AcctName\"";
            SapSql += Constants.vbCrLf + "from " + MDBMainName + ".OACT  ";
            SapSql += Constants.vbCrLf + " where \"Postable\" ='Y' and \"GroupMask\" ='5' ";

            DataTable dtemd1;

            string rest = "";
            try
            {
                Random running = new Random();

                Sap.Data.Hana.HanaDataAdapter dates = new Sap.Data.Hana.HanaDataAdapter(SapSql, con);
                dtemd1 = new DataTable();
                dtemd1.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dates.Fill(dtemd1);
                rest = CommonMethod.ConvertDataTableToJSON(dtemd1);
                return rest;
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetDataTable Failed" + ex.ToString());
                return rest;

            }
        }


       
        [HttpPost(nameof(ARInvoices))]
        public async Task<ResultSet> ARInvoices(SalesInvoice Data)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "https://galilei.tmicloud.net:50000/b1s/v1/Invoices");
            var SYSID = SPHANACon();
            string gencookie = SYSID.ToString() + ";ROUTE ID=.node4; path=/b1s";
            var mycontent = new StringContent(JsonConvert.SerializeObject(Data));
            // request.Content = new StringContent(JsonSerializer.Serialize(Data));
            request.Content = mycontent;
            request.Version = HttpVersion.Version10;
            request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            request.Headers.Add("Cookie", gencookie);
            request.Headers.ExpectContinue = false;
            var client = _ClientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.SendAsync(request);
            ResultSet SPD = null;
            if (response.IsSuccessStatusCode)
            {
                var responsestream = await response.Content.ReadAsStringAsync();
                SPD = Newtonsoft.Json.JsonConvert.DeserializeObject<ResultSet>(responsestream);
                return SPD;
            }
            else
            {
                var responsestream = await response.Content.ReadAsStringAsync();
                SPD = Newtonsoft.Json.JsonConvert.DeserializeObject<ResultSet>(responsestream);
                return SPD;
            }

        }     
     
        [HttpPost(nameof(IncomingPayments))]
        public async Task<ResultSet> IncomingPayments(IncomingPayments Data)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "https://galilei.tmicloud.net:50000/b1s/v1/IncomingPayments");
            var SYSID = SPHANACon();
            string gencookie = SYSID.ToString() + ";ROUTE ID=.node4; path=/b1s";
            var mycontent = new StringContent(JsonConvert.SerializeObject(Data));
            // request.Content = new StringContent(JsonSerializer.Serialize(Data));
            request.Content = mycontent;
            request.Version = HttpVersion.Version10;
            request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            request.Headers.Add("Cookie", gencookie);
            request.Headers.ExpectContinue = false;
            var client = _ClientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.SendAsync(request);
            ResultSet SPD = null;
            if (response.IsSuccessStatusCode)
            {
                var responsestream = await response.Content.ReadAsStringAsync();
                SPD = Newtonsoft.Json.JsonConvert.DeserializeObject<ResultSet>(responsestream);
                return SPD;
            }
            else
            {
                var responsestream = await response.Content.ReadAsStringAsync();
                SPD = Newtonsoft.Json.JsonConvert.DeserializeObject<ResultSet>(responsestream);
                return SPD;
            }

        }
     
        [HttpPost(nameof(PostMasterItem))]
        public async Task<string> PostMasterItem()
        {
            var token = await login.GetTokenAsync(_config, _ClientFactory);
            var url = _config["ConnectionStrings:BaseURL"];
            var request = new HttpRequestMessage(HttpMethod.Post, url + "/" + "ProcessData");
            request.Headers.Add("SERVICE_METHODNAME", "PushItem");
            request.Headers.Add("AUTHORIZATION", token.Trim());

            var content = "";
            var Item = getItem();
            var data = JsonConvert.SerializeObject(Item);
            if (data != null)
            {
                content = data;
                request.Content = new StringContent(content, Encoding.UTF8, "application/json");
            }

            var client = _ClientFactory.CreateClient();
            var response = await client.SendAsync(request);
            result SPD = null;
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return "success";
            }
            else
            {
                var responsestream = await response.Content.ReadAsStringAsync();
                SPD = Newtonsoft.Json.JsonConvert.DeserializeObject<result>(responsestream);
                return null;
            }
        }
        private Customercls getCustomer()
        {
            SPHANACon();
            String SapSql = "";
            SapSql += " select  Top 2 cus.\"CardName\" as \"CustomerName\",";
            SapSql += " grp.\"GroupCode\" as \"CustomerGroupCode\",";
            //SapSql += " '' as \"CustomerGroupCode\",";
            SapSql += " Case when cus.\"CreditLine\" =0 then '0' else '1' end as \"Allowcredit\", ";
            SapSql += " cus.\"CardCode\" as \"CustomerCode\", ";
            SapSql += " ifnull(addr.\"ZipCode\",'') as \"CAPincode\",ifnull(Astate.\"Name\",'') as \"CAStateName\",";
            SapSql += " ifnull(cus.\"Phone1\",'') as \"CAMobile\",ifnull(cus.\"E_Mail\",'') as \"CAEmail\",";
            SapSql += " ifnull(Disp.\"ZipCode\",'') as \"DAPincode\",ifnull(Dstate.\"Name\",'') as \"DAStateName\",";
            SapSql += " Case when cus.\"validFor\" ='Y' then '1' else '0' end as \"IsActive\",";
            SapSql += " crdays.\"ExtraDays\" as \"CrDays\",";
            SapSql += " cus.\"CreditLine\" as \"CreditLimit\",";
            SapSql += " addr.\"GSTType\" as \"DealerType\",addr.\"GSTRegnNo\" as \"GSTIN\"";
            SapSql += " from " + MDBMainName + ".\"OCRD\" cus";
            SapSql += " left join " + MDBMainName + ".\"OCRG\" grp on grp.\"GroupCode\"= cus.\"GroupCode\"";
            SapSql += " left join " + MDBMainName + ".\"CRD1\" addr on Addr.\"CardCode\" = cus.\"CardCode\" and Addr.\"LineNum\"=0 and Addr.\"AdresType\"='B'";
            SapSql += " left join " + MDBMainName + ".\"OCST\" Astate on Astate.\"Code\"= Addr.\"State\"";
            SapSql += " left join " + MDBMainName + ".\"CRD1\" Disp on Disp.\"CardCode\" = cus.\"CardCode\" and Disp.\"LineNum\"=0 and Disp.\"AdresType\"='S'";
            SapSql += " left join " + MDBMainName + ".\"OCST\" Dstate on Dstate.\"Code\"= Disp.\"State\"";
            SapSql += " left join " + MDBMainName + ".\"OCTG\" CrDays on CrDays.\"GroupNum\"= cus.\"GroupNum\"";
            SapSql += " where cus.\"U_NewCustomer\" ='Y'";

            Sap.Data.Hana.HanaDataAdapter dates = new Sap.Data.Hana.HanaDataAdapter(SapSql, con);
            DataTable dtemd1 = new DataTable();           
            dates.Fill(dtemd1);
            string serializeddt = CommonMethod.ConvertDataTableToJSON(dtemd1);       
            List<BPCustomer> clslist = JsonConvert.DeserializeObject<List<BPCustomer>>(serializeddt, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            MasterCustomer objm = new MasterCustomer();
            objm.Customer = clslist;           
            Customercls cus = new Customercls();
            cus.MasterCustomer=objm;
            return cus;
        }

        private Itemcls getItem()
        {
            SPHANACon();
            String SapSql = "";

            SapSql = " SELECT Top 2  Item.\"ItemCode\" AS ProductCode,Item.\"ItemName\"  AS ProductName, Item.\"ItemName\" as ProductFullName,grp.\"Price\"  AS SalesPrice, ";
            SapSql += " HSN.\"ChapterID\"  AS ChapterNumber, Item.\"SalUnitMsr\" as UOMDescription, ";


            SapSql += " 5 as TaxRate";
            
            SapSql += " from " + MDBMainName + ".\"OITM\" Item";
            SapSql += " left join " + MDBMainName + ".\"ITM1\" grp on grp.\"ItemCode\"= Item.\"ItemCode\" and grp.\"PriceList\"=1";
            SapSql += " left join " + MDBMainName + ".\"OCHP\" HSN on HSN.\"AbsEntry\"= Item.\"ChapterID\"";
            


            Sap.Data.Hana.HanaDataAdapter dates = new Sap.Data.Hana.HanaDataAdapter(SapSql, con);
            DataTable dtemd1 = new DataTable();
            dates.Fill(dtemd1);
            string serializeddt = CommonMethod.ConvertDataTableToJSON(dtemd1);
            List<BPItem> clslist = JsonConvert.DeserializeObject<List<BPItem>>(serializeddt, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            MasterItem objm = new MasterItem();
            objm.Item = clslist;
            Itemcls Itm = new Itemcls();
            Itm.MasterItem = objm;
            return Itm;
        }
    }
}

