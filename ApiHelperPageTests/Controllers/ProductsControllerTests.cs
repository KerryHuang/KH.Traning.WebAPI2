using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApiHelperPage.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using ApiHelperPage.Models;

namespace ApiHelperPage.Controllers.Tests
{
    [TestClass()]
    public class ProductsControllerTests
    {
        [TestMethod()]
        public void GetProductTest()
        {
            // arrange
            var expected = 1;

            var client = new RestClient("http://localhost:58572/api/Products/1");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Postman-Token", "b4794e15-5797-4458-3b69-790e03ca0bb0");
            request.AddHeader("Cache-Control", "no-cache");
            //IRestResponse response = client.Execute(request);

            // act
            // Execute<T> 執自動進行反序列化
            var response = client.Execute<Product>(request);
            // assert
            // response.Data. <-- 自己點點看，強型別才有辦法驗證
            Assert.AreEqual(expected, response.Data.ProductID);
        }
    }
}