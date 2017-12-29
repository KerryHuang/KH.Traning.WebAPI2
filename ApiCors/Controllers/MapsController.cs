using ApiCors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ApiCors.Controllers
{
    // TODO Step2：HTTP Client
    [Route("maps")]
    public class MapsController : ApiController
    {
        private static HttpClient client = new HttpClient();
        private static string mapUri = "https://maps.googleapis.com/maps/api/geocode/json?address=";
        private static string requestbinUrl = "https://requestb.in/1h0obdg1";

        //public async Task<IHttpActionResult> Get()
        //{
        //    string addressUri = mapUri + "台北市大安區金華街199巷5號";
        //    var response = await client.GetAsync(addressUri);
        //    response.EnsureSuccessStatusCode();
        //    // Step3：JSON to Object
        //    // var result = await response.Content.ReadAsStringAsync();
        //    var result = await response.Content.ReadAsAsync<Maps>();
        //    if (result.results.Any(x => x.address_components.Any(t => t.short_name.Equals("TW"))))
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(result);
        //}

        // TODO SendAsync
        public async Task<IHttpActionResult> Get()
        {            
            var response = await client.GetAsync(requestbinUrl);
            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IHttpActionResult> Post()
        {
            HttpClient client = new HttpClient(new HttpClientHandler { UseProxy = false });
            // POST方法
            var request = new HttpRequestMessage(HttpMethod.Post, requestbinUrl);
            // Content存放要上傳的內容
            request.Content = new StringContent("This is a test.");
            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string result  = await response.Content.ReadAsStringAsync();
            return Ok(result);
        }

    }
}
