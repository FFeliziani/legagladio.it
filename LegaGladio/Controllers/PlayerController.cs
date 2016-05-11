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
        public List<LegaGladio.Entities.Player> Get()
        {
            return LegaGladio.BusinessLogic.Player.list();
        }

        // GET api/player/5
        [HttpGet]
        public LegaGladio.Entities.Player Get(int id)
        {
            return LegaGladio.BusinessLogic.Player.get(id);
        }

        // GET api/player/5
        [HttpGet]
        public List<LegaGladio.Entities.Player> GetByTeam(int teamId)
        {
            return LegaGladio.BusinessLogic.Player.list(teamId);
        }

        // POST api/player
        [HttpPost]
        public void Post([FromBody]Player player)
        {
            LegaGladio.BusinessLogic.Player.newPlayer(player);
        }

        // PUT api/player/5
        [HttpPut]
        public void Put(int oldID, [FromBody]Player player)
        {
            LegaGladio.BusinessLogic.Player.updatePlayer(player, oldID);
        }

        // DELETE api/player/5
        [HttpDelete]
        public void Delete(int id)
        {
            LegaGladio.BusinessLogic.Player.deletePlayer(id);
        }
    }
}
