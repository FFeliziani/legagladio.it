using System;
using System.Collections.Generic;
using System.Web.Http;
using BusinessLogic;
using Coach = LegaGladio.Entities.Coach;
using Game = LegaGladio.Entities.Game;
using Round = LegaGladio.Entities.Round;
using Team = LegaGladio.Entities.Team;

namespace LegaGladio.Controllers
{
    public class GameController : ApiController
    {
        // GET api/game
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("get")]
        public IEnumerable<Game> Get()
        {
            return BusinessLogic.Game.ListGame();
        }

        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getByCoach")]
        public IEnumerable<Game> GetByCoach(int id)
        {
            return BusinessLogic.Game.ListGame(new Coach { Id = id });
        }

        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getByTeam")]
        public IEnumerable<Game> GetByTeam(int id)
        {
            return BusinessLogic.Game.ListGame(new Team { Id = id });
        }

        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getByRound")]
        public IEnumerable<Game> GetByRound(int id)
        {
            return BusinessLogic.Game.ListGame(new Round { Id = id });
        }

        // GET api/game/5
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("get")]
        public Game Get(int id)
        {
            return BusinessLogic.Game.Get(id);
        }

        // POST api/game
        [HttpPost]
        [AcceptVerbs("POST")]
        [ActionName("post")]
        public void Post([FromUri]String token, [FromBody]Game data)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LoginManager.CheckLogged(token))
            {
                BusinessLogic.Game.NewGame(data);
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
        public void Put([FromUri]String token, [FromUri]int id, [FromBody]Game data)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LoginManager.CheckLogged(token))
            {
                BusinessLogic.Game.UpdateGame(data, id);
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
            if (LoginManager.CheckLogged(token))
            {
                BusinessLogic.Game.RemoveGame(id);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }
    }
}
