using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            GetByID();
            Get();
            //Patch();
            //Put();
            //Patch();
            //Delete();
        }

        static void Get()
        {
            var client = new RestClient("http://localhost:5019/Orders");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Postman-Token", "6c491af0-0169-3e17-87f4-76428e58866c");
            request.AddHeader("Cache-Control", "no-cache");
            IRestResponse response = client.Execute(request);
        }

        static void GetByID()
        {
            var client = new RestClient("http://localhost:5019/Orders/10248");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Postman-Token", "99af7dfa-daeb-89ce-ebd3-195fdba9bdc5");
            request.AddHeader("Cache-Control", "no-cache");
            IRestResponse response = client.Execute(request);
        }

        static void Patch()
        {
            var client = new RestClient("http://localhost:5019/Orders/10248");
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Postman-Token", "f35df602-b8bf-c4c2-f49d-9b3d6bdb8fe1");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\n    \"OrderID\": 10248,\n    \"ShipName\": \"Vins et alcools Chevalier1\"\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
        }

        static void Delete()
        {
            var client = new RestClient("http://localhost:5019/Orders/10248");
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Postman-Token", "acd11643-fb17-89d1-61e8-2da1be2ec39c");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
        }

        static void Put()
        {
            var client = new RestClient("http://localhost:5019/Orders/10248");
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Postman-Token", "e8508a0a-185c-a8d1-eb24-3c965af1ab0d");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\n    \"OrderID\": 10248,\n    \"CustomerID\": \"VINET\",\n    \"EmployeeID\": 5,\n    \"OrderDate\": \"1996-07-04T00:00:00\",\n    \"RequiredDate\": \"1996-08-01T00:00:00\",\n    \"ShippedDate\": \"1996-07-16T00:00:00\",\n    \"ShipVia\": 3,\n    \"Freight\": 32.38,\n    \"ShipName\": \"Vins et alcools Chevalier1\",\n    \"ShipAddress\": \"59 rue de l'Abbaye\",\n    \"ShipCity\": \"Reims\",\n    \"ShipRegion\": null,\n    \"ShipPostalCode\": \"51100\",\n    \"ShipCountry\": \"France\"\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
        }
    }
}
