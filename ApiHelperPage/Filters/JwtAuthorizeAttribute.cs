using Jose;
using JWT;
using JWT.Serializers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace ApiHelperPage.Filters
{
    public class JwtAuthorizeAttribute : AuthorizeAttribute
    {
        static string secretKey = "BAD6809DCB5AFBAAA9DC8CABB4F4AB3D7DCA2438A721B3686B6B0D3288239D00";
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null ||
                actionContext.Request.Headers.Authorization.Scheme != "Bearer")
            {
                var response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "驗證有誤！");
                actionContext.Response = response;
                return base.IsAuthorized(actionContext);
            }
            var token = actionContext.Request.Headers.Authorization.Parameter;
            //var payload = JWT.Decode(token, secretKey);
            string payload = string.Empty;
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                payload = decoder.Decode(token, secretKey, verify: true);
                //Console.WriteLine(json);
            }
            catch (TokenExpiredException)
            {
                //Console.WriteLine("Token has expired");
            }
            catch (SignatureVerificationException)
            {
                //Console.WriteLine("Token has invalid signature");
            }
            var payloadObject = JsonConvert.DeserializeObject<PayloadModel>(payload);
            var expireUnixTime = payloadObject.exp;
            var nowUnixTime = DateTimeOffset.Now.ToUnixTimeSeconds();
            return nowUnixTime < expireUnixTime;
        }

    }

    public class PayloadModel
    {
        public string iss { get; set; }
        public long iat { get; set; }
        public long exp { get; set; }
        public string aud { get; set; }
        public string sub { get; set; }
        public string name { get; set; }
        public string hash { get; set; }
    }

}