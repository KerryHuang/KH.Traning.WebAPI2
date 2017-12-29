using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication3.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }


        public HttpResponseMessage Get()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent("SkillTree!");
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            return response;
        }

        //public HttpResponseMessage Get()
        //{
        //    var customObj = new
        //    {
        //        className = "ASP.NET Web API 2 實戰訓練營",
        //        lecturer = "BruceChen(陳傳興)"
        //    };
        //    return Request.CreateResponse(HttpStatusCode.OK, customObj);
        //}
    }
}
