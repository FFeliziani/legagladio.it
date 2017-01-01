using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http;

using LegaGladio.Entities;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LegaGladio.Controllers
{

    public class PlayerController : ApiController
    {
        //GET: api/player
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("get")]
        public List<LegaGladio.Entities.Player> Get()
        {
            return LegaGladio.BusinessLogic.Player.list();
        }

        // GET api/player/5
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("get")]
        public LegaGladio.Entities.Player Get(int id)
        {
            return LegaGladio.BusinessLogic.Player.get(id);
        }

        // GET api/player/5
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getByTeam")]
        public List<LegaGladio.Entities.Player> GetByTeam(int id)
        {
            return LegaGladio.BusinessLogic.Player.list(id);
        }

        // GET api/player/5
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getByTeamActive")]
        public List<LegaGladio.Entities.Player> GetByTeamActive(int id)
        {
            return LegaGladio.BusinessLogic.Player.list(id, true);
        }

        // GET api/player/5
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getByTeamInactive")]
        public List<LegaGladio.Entities.Player> GetByTeamInactive(int id)
        {
            return LegaGladio.BusinessLogic.Player.list(id, false);
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
            if (LegaGladio.BusinessLogic.LoginManager.CheckLogged(token))
            {
                LegaGladio.BusinessLogic.Player.newPlayer(data);
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
            if (LegaGladio.BusinessLogic.LoginManager.CheckLogged(token))
            {
                LegaGladio.BusinessLogic.Player.updatePlayer(data, id);
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
            if (LegaGladio.BusinessLogic.LoginManager.CheckLogged(token))
            {
                LegaGladio.BusinessLogic.Player.deletePlayer(id);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }
    }
}
