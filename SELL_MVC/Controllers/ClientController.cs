using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SELL_MVC.Models;
using SELL_MVC.Controllers;
using System.Text;
using Newtonsoft.Json.Linq;

namespace SELL_MVC.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index(string name)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            Authenticate user = new Authenticate { Email = "admin", Pwd = "admin" };
            //HttpContext.Session.SetString("JWToken",name);
            using (HttpClient client = new HttpClient(clientHandler))
            {
                //var token = HttpContext.Session.GetString("JWToken");
                
                var token = GetToken("https://localhost:44310/api/Token", user);
                client.BaseAddress = new Uri("https://localhost:44325/");
                //MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = new HttpResponseMessage();
                response = client.GetAsync("api/CarsInfoes").Result;


                string stringData = response.Content.ReadAsStringAsync().Result;

                var data = JsonConvert.DeserializeObject<IEnumerable<CarsInfo>>(stringData);


                return View(data);
            }
        }
        public IActionResult Index1(string name)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            Authenticate user = new Authenticate { Email = "admin", Pwd = "admin" };
            //HttpContext.Session.SetString("JWToken",name);
            using (HttpClient client = new HttpClient(clientHandler))
            {
                //var token = HttpContext.Session.GetString("JWToken");

                var token = GetToken("https://localhost:44310/api/Token", user);
                client.BaseAddress = new Uri("https://localhost:44331/api/");
                //MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = new HttpResponseMessage();
                response = client.GetAsync("Customers").Result;


                string stringData = response.Content.ReadAsStringAsync().Result;

                var data = JsonConvert.DeserializeObject<IEnumerable<Customer>>(stringData);


                return View(data);
            }
        }
        static string GetToken(string url, Authenticate user)
        {
            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (HttpClient client = new HttpClient(clientHandler))
            {
                var response = client.PostAsync(url, data).Result;
                string name = response.Content.ReadAsStringAsync().Result;
                dynamic details = JObject.Parse(name);
                return details.token;
            }
        }
    }
}
