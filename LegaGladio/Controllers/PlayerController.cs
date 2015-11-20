using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http;

using LegaGladio.Entities;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    
    public class PlayerController : ApiController
    {
        //GET: api/values
        [HttpGet]
        public int Get()
        {
            return LegaGladio.BusinessLogic.Player.count();
        }

        // GET api/player/5
        [HttpGet]
        public Player Get(int id)
        {
            Player p = LegaGladio.BusinessLogic.Player.get(id);
            return p;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Player player)
        {
            LegaGladio.BusinessLogic.Player.newPlayer(player);
        }

        // PUT api/values/5
        [HttpPut]
        public void Put(int oldID, [FromBody]Player player)
        {
            LegaGladio.BusinessLogic.Player.updatePlayer(player, oldID);
        }

        // DELETE api/values/5
        [HttpDelete]
        public void Delete(int id)
        {
            LegaGladio.BusinessLogic.Player.deletePlayer(id);
        }
    }
}
