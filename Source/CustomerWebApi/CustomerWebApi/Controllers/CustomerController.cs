using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CustomerWebApi.Models;

namespace CustomerWebApi.Controllers
{
    public class CustomerController : ApiController
    {
        public IEnumerable<CustomerModel> Get()
        {
            List<CustomerModel> customerModels = new List<CustomerModel>();
            customerModels.Add(new CustomerModel() {
                Id=1,
                Code="012233",
                Name="Kyaw Kyaw"
            });
            customerModels.Add(new CustomerModel()
            {
                Id = 1,
                Code = "012237",
                Name = "Kyaw Soe"
            });
            customerModels.Add(new CustomerModel()
            {
                Id = 1,
                Code = "012233",
                Name = "Moe Moe"
            });

            return customerModels;

        }

    }
}
