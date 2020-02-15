using BCErp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BCErp.Controllers
{
    public class CustomerTestController : Controller
    {
        // GET: CustomerTest
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Load()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52501/api/");
            var response = client.GetAsync("customer");
            response.Wait();
            string content;
            List<Customer> customers = new List<Customer>();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                content = await result.Content.ReadAsStringAsync();
                customers = JsonConvert.DeserializeObject<List<Customer>>(content);
            }
            ViewBag.Customers = customers;
            return View();
        }

    }
}