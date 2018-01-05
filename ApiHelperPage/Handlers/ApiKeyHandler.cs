using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ApiHelperPage.Handlers
{
    public class ApiKeyHandler : DelegatingHandler
    {
        public string Key { get; set; }
        /// <summary>
        /// key 由建構式注入
        /// </summary>
        /// <param name="key"></param>
        public ApiKeyHandler(string key)
        {
            this.Key = key;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!ValidateKey(request))
            {
                var response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                var tsc = new TaskCompletionSource<HttpResponseMessage>();
                tsc.SetResult(response);
                return tsc.Task;
            }
            return base.SendAsync(request, cancellationToken);
        }

        /// <summary>
        /// 由請求進行 key 參數檢查
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private bool ValidateKey(HttpRequestMessage message)
        {
            // 取得 QueryString
            var query = message.RequestUri.ParseQueryString();
            string key = query["key"];
            return (key == Key);
        }

    }
}