using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LegaGladio.Controllers
{
    public class GameController : ApiController
    {
        // GET api/game
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("get")]
        public IEnumerable<LegaGladio.Entities.Game> Get()
        {
            return BusinessLogic.Game.listGame();
        }

        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getByCoach")]
        public IEnumerable<LegaGladio.Entities.Game> GetByCoach(int id)
        {
            return BusinessLogic.Game.listGame(new LegaGladio.Entities.Coach() { Id = id });
        }

        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getByTeam")]
        public IEnumerable<LegaGladio.Entities.Game> getByTeam(int id)
        {
            return BusinessLogic.Game.listGame(new LegaGladio.Entities.Team() { Id = id });
        }

        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getByRound")]
        public IEnumerable<LegaGladio.Entities.Game> getByRound(int id)
        {
            return BusinessLogic.Game.listGame(new LegaGladio.Entities.Round() { Id = id });
        }

        // GET api/game/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/game
        public void Post([FromBody]string value)
        {
        }

        // PUT api/game/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/game/5
        public void Delete(int id)
        {
        }
    }
}
