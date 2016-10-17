using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LegaGladio.Controllers
{
    public class CoachController : ApiController
    {
        // GET api/<controller>
        [ActionName("get")]
        public IEnumerable<LegaGladio.Entities.Coach> Get()
        {
            return LegaGladio.BusinessLogic.Coach.list();
        }

        // GET api/<controller>/5
        [ActionName("get")]
        public LegaGladio.Entities.Coach Get(int id)
        {
            return LegaGladio.BusinessLogic.Coach.get(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]LegaGladio.Entities.Coach coach)
        {
            LegaGladio.BusinessLogic.Coach.newCoach(coach);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public void Put(int id, [FromBody]LegaGladio.Entities.Coach coach)
        {
            LegaGladio.BusinessLogic.Coach.updateCoach(coach, id);
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public void Delete(int id)
        {
            LegaGladio.BusinessLogic.Coach.deleteCoach(id);
        }
    }
}