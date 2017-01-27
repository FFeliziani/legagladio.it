using System;
using System.Collections.Generic;
using System.Web.Http;
using BusinessLogic;
using Team = LegaGladio.Entities.Team;

namespace LegaGladio.Controllers
{
    public class TeamController : ApiController
    {
        // GET api/team
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("get")]
        public ICollection<Team> Get()
        {
            return BusinessLogic.Team.ListTeam();
        }

        // GET api/team/5
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("Get")]
        public Team Get(int id)
        {
            return BusinessLogic.Team.GetTeam(id, true);
        }

        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getInactivePlayers")]
        public Team GetInactivePlayers(int id)
        {
            return BusinessLogic.Team.GetTeam(id, false);
        }

        // GET api/team/5
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getByCoach")]
        public ICollection<Team> GetByCoach(int id)
        {
            return BusinessLogic.Team.ListTeam(id);
        }

        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getActive")]
        public ICollection<Team> GetActive()
        {
            return BusinessLogic.Team.ListTeam(true);
        }
        
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getInactive")]
        public ICollection<Team> GetInactive()
        {
            return BusinessLogic.Team.ListTeam(false);
        }

        // POST api/team
        [HttpPost]
        [AcceptVerbs("POST")]
        [ActionName("post")]
        public void Post([FromUri]String token, [FromBody]Team data)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LoginManager.CheckLogged(token))
            {
                BusinessLogic.Team.NewTeam(data);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }

        // PUT api/team/5
        [HttpPut]
        [AcceptVerbs("PUT")]
        [ActionName("put")]
        public void Put([FromUri]String token, [FromUri]int id, [FromBody]Team data)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LoginManager.CheckLogged(token))
            {
                BusinessLogic.Team.UpdateTeam(data, id);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }

        // DELETE api/team/5
        /*[HttpDelete]
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
                BusinessLogic.Team.DeleteTeam(id);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }*/
    }
}
