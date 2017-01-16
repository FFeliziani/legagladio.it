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
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("get")]
        public LegaGladio.Entities.Game Get(int id)
        {
            return BusinessLogic.Game.get(id);
        }

        // POST api/game
        [HttpPost]
        [AcceptVerbs("POST")]
        [ActionName("POST")]
        public void Post([FromUri]String token, [FromBody]LegaGladio.Entities.Game data)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LegaGladio.BusinessLogic.LoginManager.CheckLogged(token))
            {
                LegaGladio.BusinessLogic.Game.newGame(data);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }

        // PUT api/game/5
        [HttpPut]
        [AcceptVerbs("PUT")]
        [ActionName("put")]
        public void Put([FromUri]String token, [FromUri]int id, [FromBody]LegaGladio.Entities.Game data)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LegaGladio.BusinessLogic.LoginManager.CheckLogged(token))
            {
                LegaGladio.BusinessLogic.Game.updateGame(data, id);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }

        // DELETE api/game/5
        [HttpDelete]
        [AcceptVerbs("DELETE")]
        [ActionName("delete")]
        public void Delete([FromUri]String token, [FromUri]int id)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LegaGladio.BusinessLogic.LoginManager.CheckLogged(token))
            {
                LegaGladio.BusinessLogic.Game.removeGame(id);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }
    }
}
