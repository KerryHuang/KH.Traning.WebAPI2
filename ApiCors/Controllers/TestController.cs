using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApiCors.Controllers
{
    // TODO 下一步，在 Controller 加入 [EnableCors] 屬性：
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TestController : ApiController
    {
        // TODO 修改 CURD 程式碼：
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("Get from test.")                
            };
        }
        
        public HttpResponseMessage Post()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("Post from test.")
            };
        }

        public HttpResponseMessage Put()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("Put from test.")
            };
        }

        // TODO 某些 API 方法，如果你希望不受 CORS 的影響，那麼可以透過 [DisableCors] 屬性來設置：
        [DisableCors]
        public HttpResponseMessage Delete()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("Delete from test.")
            };
        }

    }
}

// API Result 4種
// void / IHttpActionResult / HttpResponseMessage / Object
