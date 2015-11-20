using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LegaGladio.Controllers
{
    public class TeamController : ApiController
    {
        // GET api/team
        [HttpGet]
        public IEnumerable<LegaGladio.Entities.Team> Get()
        {
            return null;
        }

        // GET api/team/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/team
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/team/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/team/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
