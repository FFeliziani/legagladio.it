using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LegaGladio.Controllers
{
    public class CoachController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("get")]
        public IEnumerable<LegaGladio.Entities.Coach> Get()
        {
            return LegaGladio.BusinessLogic.Coach.list();
        }

        // GET api/<controller>/5
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("get")]
        public LegaGladio.Entities.Coach Get(int id)
        {
            return LegaGladio.BusinessLogic.Coach.get(id);
        }

        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getActive")]
        public List<LegaGladio.Entities.Coach> GetActive()
        {
            return LegaGladio.BusinessLogic.Coach.list(true);
        }

        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getInactive")]
        public List<LegaGladio.Entities.Coach> GetInactive()
        {
            return LegaGladio.BusinessLogic.Coach.list(false);
        }

        // POST api/<controller>
        [HttpPost]
        [ActionName("post")]
        [AcceptVerbs("POST")]
        public void Post([FromUri]String token, [FromBody]LegaGladio.Entities.Coach coach)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LegaGladio.BusinessLogic.LoginManager.CheckLogged(token))
            {

                LegaGladio.BusinessLogic.Coach.newCoach(coach);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }

        // PUT api/<controller>/5
        [HttpPut]
        [ActionName("put")]
        [AcceptVerbs("PUT")]
        public void Put([FromUri]String token, [FromUri]int id, [FromBody]LegaGladio.Entities.Coach coach)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LegaGladio.BusinessLogic.LoginManager.CheckLogged(token))
            {

                LegaGladio.BusinessLogic.Coach.updateCoach(coach, id);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }

        // DELETE api/<controller>/5
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

                LegaGladio.BusinessLogic.Coach.deleteCoach(id);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }
    }
}