using Jose;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace ApiHelperPage.Controllers
{
    public class TokenController : ApiController
    {
        public IHttpActionResult Post([FromBody]LoginModel loginModel)
        {
            // Hack: 應該與資料庫做比對
            if (loginModel.Name == "kkbruce" && loginModel.Password == "skilltree")
            {
                var secretKey = "BAD6809DCB5AFBAAA9DC8CABB4F4AB3D7DCA2438A721B3686B6B0D3288239D00";
                var payload = new
                {
                    iss = "BruceChen",
                    iat = DateTimeOffset.Now.ToUnixTimeSeconds(),
                    exp = DateTimeOffset.Now.AddSeconds(30).ToUnixTimeSeconds(),
                    aud = "kkbruce.tw",
                    sub = "i@kkbruce.tw",
                    name = loginModel.Name,
                    hash = "13B90F95960A105561E292C1640346BD3C178C5948545284875E5275BB8E100C"
                };

                //string token = Jose.JWT.Encode(payload, Encoding.UTF8.GetBytes(secretKey), JwsAlgorithm.HS256);


                IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
                IJsonSerializer serializer = new JsonNetSerializer();
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

                var token = encoder.Encode(payload, secretKey);

                return Ok($"token={token}");
            }
            else
            {
                return Unauthorized();
            }
        }
    }

    public class LoginModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }

}
