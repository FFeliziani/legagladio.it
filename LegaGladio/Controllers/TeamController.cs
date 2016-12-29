using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LegaGladio.Controllers
{
    public class TeamController : ApiController
    {
        // GET api/team
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("get")]
        public List<LegaGladio.Entities.Team> Get()
        {
            return LegaGladio.BusinessLogic.Team.list();
        }

        // GET api/team/5
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("get")]
        public LegaGladio.Entities.Team Get(int id)
        {
            return LegaGladio.BusinessLogic.Team.get(id);
        }

        // GET api/team/5
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getByCoach")]
        public List<LegaGladio.Entities.Team> GetByCoach(int id)
        {
            return LegaGladio.BusinessLogic.Team.list(id);
        }

        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getActive")]
        public List<LegaGladio.Entities.Team> GetActive()
        {
            return LegaGladio.BusinessLogic.Team.list(true);
        }
        
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getInactive")]
        public List<LegaGladio.Entities.Team> GetInactive()
        {
            return LegaGladio.BusinessLogic.Team.list(false);
        }

        // POST api/team
        [HttpPost]
        [AcceptVerbs("POST")]
        [ActionName("post")]
        public void Post([FromUri]String token, [FromBody]LegaGladio.Entities.Team data)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LegaGladio.BusinessLogic.LoginManager.CheckLogged(token))
            {
                LegaGladio.BusinessLogic.Team.newTeam(data);
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
        public void Put([FromUri]String token, [FromUri]int id, [FromBody]LegaGladio.Entities.Team data)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LegaGladio.BusinessLogic.LoginManager.CheckLogged(token))
            {
                LegaGladio.BusinessLogic.Team.updateTeam(data, id);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }

        // DELETE api/team/5
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
                LegaGladio.BusinessLogic.Team.deleteTeam(id);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }
    }
}
