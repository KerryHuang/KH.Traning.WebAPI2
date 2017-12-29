using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication3.Filters;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class Product2sController : ApiController
    {
        /// <summary>
        /// Posts the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns></returns>
        //[ModelValidationFilter]
        public HttpResponseMessage Post(Product2 product)
        {
            if (ModelState.IsValid)
            {
                // Todo: 用 product 做些事
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                //return new HttpResponseMessage(HttpStatusCode.BadRequest);
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

    }
}
