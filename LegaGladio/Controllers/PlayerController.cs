using System;
using System.Collections.Generic;
using System.Web.Http;
using BusinessLogic;
using Player = LegaGladio.Entities.Player;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LegaGladio.Controllers
{

    public class PlayerController : ApiController
    {
        //GET: api/player
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("GetPlayer")]
        public IEnumerable<Player> Get()
        {
            return BusinessLogic.Player.ListPlayer();
        }

        // GET api/player/5
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("GetPlayer")]
        public Player Get(int id)
        {
            return BusinessLogic.Player.GetPlayer(id);
        }

        // GET api/player/5
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getByTeam")]
        public IEnumerable<Player> GetByTeam(int id)
        {
            return BusinessLogic.Player.ListPlayer(id);
        }

        // GET api/player/5
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getByTeamActive")]
        public IEnumerable<Player> GetByTeamActive(int id)
        {
            return BusinessLogic.Player.ListPlayer(id, true);
        }

        // GET api/player/5
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getByTeamInactive")]
        public IEnumerable<Player> GetByTeamInactive(int id)
        {
            return BusinessLogic.Player.ListPlayer(id, false);
        }

        // POST api/player
        [HttpPost]
        [ActionName("post")]
        [AcceptVerbs("POST")]
        public void Post([FromUri]String token, [FromBody]Player data)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LoginManager.CheckLogged(token))
            {
                BusinessLogic.Player.NewPlayer(data);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }

        // PUT api/player/5
        [HttpPut]
        [ActionName("put")]
        [AcceptVerbs("PUT")]
        public void Put([FromUri]String token, [FromUri]int id, [FromBody]Player data)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LoginManager.CheckLogged(token))
            {
                BusinessLogic.Player.UpdatePlayer(data, id);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }

        // DELETE api/player/5
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
                BusinessLogic.Player.DeletePlayer(id);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }
    }
}
