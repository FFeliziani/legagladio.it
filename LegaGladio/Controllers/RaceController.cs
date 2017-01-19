using System;
using System.Collections.Generic;
using System.Web.Http;
using BusinessLogic;
using Race = LegaGladio.Entities.Race;

namespace LegaGladio.Controllers
{
    public class RaceController : ApiController
    {
        // GET api/race
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("Get")]
        public IEnumerable<Race> Get()
        {
            return BusinessLogic.Race.List();
        }

        // GET api/race/5
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("Get")]
        public Race Get(int id)
        {
            return BusinessLogic.Race.Get(id);
        }

        // POST api/race
        [HttpPost]
        [ActionName("post")]
        [AcceptVerbs("POST")]
        public void Post([FromUri]String token, [FromBody]Race race)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LoginManager.CheckLogged(token))
            {
                BusinessLogic.Race.NewRace(race);
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
        public void Put([FromUri]String token, [FromUri]int id, [FromBody]Race race)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LoginManager.CheckLogged(token))
            {
                BusinessLogic.Race.UpdateRace(race, id);
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
            if (LoginManager.CheckLogged(token))
            {
                BusinessLogic.Race.DeleteRace(id);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }
    }
}
