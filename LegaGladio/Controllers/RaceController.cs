using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LegaGladio.Controllers
{
    public class RaceController : ApiController
    {
        // GET api/race
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/race/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/race
        public void Post([FromBody]string value)
        {
        }

        // PUT api/race/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/race/5
        public void Delete(int id)
        {
        }
    }
}
