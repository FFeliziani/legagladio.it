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
        [ActionName("get")]
        public IEnumerable<LegaGladio.Entities.Race> Get()
        {
            return LegaGladio.BusinessLogic.Race.list();
        }

        // GET api/race/5
        [ActionName("get")]
        public LegaGladio.Entities.Race Get(int id)
        {
            return LegaGladio.BusinessLogic.Race.get(id);
        }

        // POST api/race
        [HttpPost]
        public void Post([FromBody]LegaGladio.Entities.Race race)
        {
            LegaGladio.BusinessLogic.Race.newRace(race);
        }

        // PUT api/race/5
        [HttpPut]
        public void Put(int id, [FromBody]LegaGladio.Entities.Race race)
        {
            LegaGladio.BusinessLogic.Race.updateRace(race, id);
        }

        // DELETE api/race/5
        [HttpDelete]
        public void Delete(int id)
        {
            LegaGladio.BusinessLogic.Race.deleteRace(id);
        }
    }
}
