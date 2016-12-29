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
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("get")]
        public IEnumerable<LegaGladio.Entities.Race> Get()
        {
            return LegaGladio.BusinessLogic.Race.list();
        }

        // GET api/race/5
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("get")]
        public LegaGladio.Entities.Race Get(int id)
        {
            return LegaGladio.BusinessLogic.Race.get(id);
        }

        // POST api/race
        [HttpPost]
        [ActionName("post")]
        [AcceptVerbs("POST")]
        public void Post([FromUri]String token, [FromBody]LegaGladio.Entities.Race race)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LegaGladio.BusinessLogic.LoginManager.CheckLogged(token))
            {
                LegaGladio.BusinessLogic.Race.newRace(race);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }

        // PUT api/race/5
        [HttpPut]
        [ActionName("put")]
        [AcceptVerbs("PUT")]
        public void Put([FromUri]String token, [FromUri]int id, [FromBody]LegaGladio.Entities.Race race)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LegaGladio.BusinessLogic.LoginManager.CheckLogged(token))
            {
                LegaGladio.BusinessLogic.Race.updateRace(race, id);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }

        // DELETE api/race/5
        [HttpDelete]
        [ActionName("delete")]
        [AcceptVerbs("DELETE")]
        public void Delete([FromUri]String token, [FromUri]int id)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LegaGladio.BusinessLogic.LoginManager.CheckLogged(token))
            {
                LegaGladio.BusinessLogic.Race.deleteRace(id);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }
    }
}
