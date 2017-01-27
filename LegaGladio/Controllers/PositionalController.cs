using System;
using System.Collections.Generic;
using System.Web.Http;
using BusinessLogic;
using Positional = LegaGladio.Entities.Positional;

namespace LegaGladio.Controllers
{
    public class PositionalController : ApiController
    {
        // GET api/positional
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("Get")]
        public ICollection<Positional> Get()
        {
            return BusinessLogic.Positional.List();
        }

        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("Get")]
        public Positional Get(int id)
        {
            return BusinessLogic.Positional.Get(id);
        }

        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getByRace")]
        // GET api/positional/5
        public ICollection<Positional> GetByRace(int id)
        {
            return BusinessLogic.Positional.ListByRace(id);
        }
        
        // POST api/positional
        [HttpPost]
        [ActionName("post")]
        [AcceptVerbs("POST")]
        public void Post([FromUri]String token, [FromBody]Positional positional)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LoginManager.CheckLogged(token))
            {
            BusinessLogic.Positional.NewPositional(positional);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }

        // PUT api/positional/5
        [HttpPut]
        [ActionName("put")]
        [AcceptVerbs("PUT")]
        public void Put([FromUri]String token, [FromUri]int id, [FromBody]Positional positional)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LoginManager.CheckLogged(token))
            {
            BusinessLogic.Positional.UpdatePositional(positional, id);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }

        // DELETE api/positional/5
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
                BusinessLogic.Positional.DeletePositional(id);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }
    }
}
