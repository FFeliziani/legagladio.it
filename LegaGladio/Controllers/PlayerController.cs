using System;
using System.Collections.Generic;
using System.Web.Http;
using BusinessLogic;
using LegaGladio.Models;
using Player = LegaGladio.Entities.Player;
using Team = LegaGladio.Entities.Team;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LegaGladio.Controllers
{

    public class PlayerController : ApiController
    {
        //GET: api/player
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("Get")]
        public ICollection<Player> Get()
        {
            return BusinessLogic.Player.ListPlayer();
        }

        // GET api/player/5
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("Get")]
        public Player Get(int id)
        {
            return BusinessLogic.Player.GetPlayer(id);
        }

        // GET api/player/5
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getByTeam")]
        public ICollection<Player> GetByTeam(int id)
        {
            return BusinessLogic.Player.ListPlayer(id);
        }

        // GET api/player/5
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getByTeamActive")]
        public ICollection<Player> GetByTeamActive(int id)
        {
            return BusinessLogic.Player.ListPlayer(id, true);
        }

        // GET api/player/5
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getByTeamInactive")]
        public ICollection<Player> GetByTeamInactive(int id)
        {
            return BusinessLogic.Player.ListPlayer(id, false);
        }

        [HttpPost]
        [AcceptVerbs("POST")]
        [ActionName("AddPlayerToTeam")]
        public void AddPlayerToTeam([FromUri] String token, [FromBody] AddItemsData addItemsData)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LoginManager.CheckLogged(token))
            {
                var p = new Player() { Id = Convert.ToInt32(addItemsData.Id2) };
                var t = new Team() { Id = Convert.ToInt32(addItemsData.Id1) };
                BusinessLogic.Player.AddPlayerToTeam(p, t);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }

        [HttpPost]
        [AcceptVerbs("POST")]
        [ActionName("RemovePlayerFromTeam")]
        public void RemovePlayerFromTeam([FromUri] String token, [FromBody] AddItemsData addItemsData)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LoginManager.CheckLogged(token))
            {
                var p = new Entities.Player() { Id = Convert.ToInt32(addItemsData.Id2) };
                var t = new Entities.Team() { Id = Convert.ToInt32(addItemsData.Id1) };
                BusinessLogic.Player.RemovePlayerFromTeam(p, t);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }

        // POST api/player
        [HttpPost]
        [ActionName("post")]
        [AcceptVerbs("POST")]
        public Int32 Post([FromUri]String token, [FromBody]Player data)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LoginManager.CheckLogged(token))
            {
                return BusinessLogic.Player.NewPlayer(data);
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
