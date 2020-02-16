using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CustomerWebApi.Models;

namespace CustomerWebApi.Controllers
{
    [BasicAuthorizationFilter]
    public class CustomerController : ApiController
    {
        
        static List<CustomerModel> customers = new List<CustomerModel>()
        {
            new CustomerModel() {
                Id=1,
                Code="012233",
                Name="Kyaw Kyaw"
            },
            new CustomerModel()
            {
                Id = 2,
                Code = "012237",
                Name = "Kyaw Soe"
            },
            new CustomerModel()
            {
                Id = 3,
                Code = "012239",
                Name = "Moe Moe"
            }

        };
        
        public IEnumerable<CustomerModel> Get()
        {            
            return customers;
        }

        public void Post([FromBody]CustomerModel customer)
        {
            customers.Add(customer);
        }

    }
}
