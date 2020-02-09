using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BCErp.API.Models;

namespace BCErp.API.Controllers
{
    [EnableCorsAttribute("*", "*", "*")]
    public class StateRegionController : ApiController
    {
        // GET api/values
        public IEnumerable<StateRegionModel> Get()
        {
            var list = new List<StateRegionModel>();
            list.Add(new StateRegionModel() { Id = 1, Code = "01", Name = "Kachin" });
            list.Add(new StateRegionModel() { Id = 1, Code = "02", Name = "Kayah" });
            list.Add(new StateRegionModel() { Id = 1, Code = "03", Name = "Kayin" });
            return list;
        }

        [DisableCors]
        public string Get(int id)
        {
            return "value";
        }
   
        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
