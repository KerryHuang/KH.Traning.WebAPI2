using ApiBoom.Controllers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiBoom.Controllers
{
    [RoutePrefix("Boom")]
    public class BoomController : ApiController
    {
        [HttpGet]
        [Route("demo0/{id:int}")]
        public int Demo0(int id)
        {
            if (id > 10)
            {
                throw new Exception("From: throw new Exception");
            }
            return id;
        }

        [HttpGet]
        [Route("demo1")]
        public HttpResponseMessage Demo1()
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            response.Content = new StringContent("From: throw new HttpResponseException");
            throw new HttpResponseException(response);
        }

        [HttpGet]
        [Route("demo2")]
        public HttpResponseMessage Demo2()
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            response.Content = new StringContent("From: HttpResponseMessage Object");
            return response;
        }

        [HttpGet]
        [Route("demo3/{id:int}")]
        public HttpResponseMessage Demo3(int id)
        {
            if (id > 10)
            {
                HttpError error = new HttpError("From: HttpError");
                error["ErrorCode"] = 9487;
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, error);
            }
            var customer = new Customer() { FirstName = "Bruce", LastName = "Chen" };
            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }

        [HttpGet]
        [Route("demo4/{id:int}")]
        public Customer Demo4(int id)
        {
            if (id > 10)
            {
                string msg = "From: HttpResponseException + Request.CreateErrorResponse";
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, msg));
            }
            var customer = new Customer() { FirstName = "Bruce", LastName = "Chen" };
            return customer;
        }
    }
}
