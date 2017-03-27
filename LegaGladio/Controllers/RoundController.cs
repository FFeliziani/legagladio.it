using System;
using System.Collections.Generic;
using System.Web.Http;
using BusinessLogic;
using Group = LegaGladio.Entities.Group;
using Round = LegaGladio.Entities.Round;
using LegaGladio.Models;

namespace LegaGladio.Controllers
{
    public class RoundController : ApiController
    {
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("get")]
        public Round Get(int id)
        {
            return BusinessLogic.Round.GetRound(id);
        }

        // GET api/player/5
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getByGroup")]
        public ICollection<Round> GetByGroup(int id)
        {
            var group = new Group { Id = id };
            return BusinessLogic.Round.ListRound(group);
        }
        
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getDetailedByGroup")]
        public ICollection<Round> GetDetailedByGroup(int id)
        {
            var group = new Group { Id = id };
            return BusinessLogic.Round.ListRoundDetailed(group);
        }

        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("generateRounds")]
        public void GenerateRounds([FromUri]String token, [FromBody]GenerateRoundData data)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LoginManager.CheckLogged(token))
            {
                BusinessLogic.Round.GenerateRounds(data.GroupId, data.TeamIds);
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
        public void Post([FromUri]String token, [FromBody]Round data)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LoginManager.CheckLogged(token))
            {
                BusinessLogic.Round.NewRound(data);
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
        public void Put([FromUri]String token, [FromUri]int id, [FromBody]Round data)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LoginManager.CheckLogged(token))
            {
                BusinessLogic.Round.UpdateRound(data, id);
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
                BusinessLogic.Round.RemoveRound(id);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }
    }
}
