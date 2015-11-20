using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LegaGladio.Controllers
{
    public class PositionalController : ApiController
    {
        // GET api/positional
        public IEnumerable<string> Get()
        {
            
            return new string[] { "value1", "value2" };
        }

        // GET api/positional/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/positional
        public void Post([FromBody]string value)
        {
            LegaGladio.BusinessLogic.Positional.add(new Entities.Positional());
        }

        // PUT api/positional/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/positional/5
        public void Delete(int id)
        {
        }
    }
}
