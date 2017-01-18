using System;
using System.Collections.Generic;
using System.Web.Http;
using BusinessLogic;
using Coach = LegaGladio.Entities.Coach;

namespace LegaGladio.Controllers
{
    public class CoachController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("get")]
        public IEnumerable<Coach> Get()
        {
            return BusinessLogic.Coach.List();
        }

        // GET api/<controller>/5
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("get")]
        public Coach Get(int id)
        {
            return BusinessLogic.Coach.Get(id);
        }

        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getSimple")]
        public IEnumerable<Coach> GetSimple()
        {
            return BusinessLogic.Coach.ListSimple();
        }

        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getActive")]
        public IEnumerable<Coach> GetActive()
        {
            return BusinessLogic.Coach.List(true);
        }

        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getInactive")]
        public IEnumerable<Coach> GetInactive()
        {
            return BusinessLogic.Coach.List(false);
        }

        // POST api/<controller>
        [HttpPost]
        [ActionName("post")]
        [AcceptVerbs("POST")]
        public void Post([FromUri]String token, [FromBody]Coach coach)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LoginManager.CheckLogged(token))
            {
                BusinessLogic.Coach.NewCoach(coach);
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
        
        public void Put([FromUri]String token, [FromUri]int id, [FromBody]Coach coach)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LoginManager.CheckLogged(token))
            {
                BusinessLogic.Coach.UpdateCoach(coach, id);
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
            if (LoginManager.CheckLogged(token))
            {

                BusinessLogic.Coach.DeleteCoach(id);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }
    }
}