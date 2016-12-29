using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LegaGladio.Controllers
{
    public class PositionalController : ApiController
    {
        // GET api/positional
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("get")]
        public List<LegaGladio.Entities.Positional> Get()
        {
            return LegaGladio.BusinessLogic.Positional.list();
        }

        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("get")]
        public LegaGladio.Entities.Positional Get(int id)
        {
            return LegaGladio.BusinessLogic.Positional.get(id);
        }

        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getByTeam")]
        // GET api/positional/5
        public List<LegaGladio.Entities.Positional> GetByTeam(int id)
        {
            return LegaGladio.BusinessLogic.Positional.listByTeam(id);
        }
        
        // POST api/positional
        [HttpPost]
        [ActionName("post")]
        [AcceptVerbs("POST")]
        public void Post([FromUri]String token, [FromBody]LegaGladio.Entities.Positional positional)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LegaGladio.BusinessLogic.LoginManager.CheckLogged(token))
            {
            LegaGladio.BusinessLogic.Positional.newPositional(positional);
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
        public void Put([FromUri]String token, [FromUri]int id, [FromBody]LegaGladio.Entities.Positional positional)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LegaGladio.BusinessLogic.LoginManager.CheckLogged(token))
            {
            LegaGladio.BusinessLogic.Positional.updatePositional(positional, id);
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
            if (LegaGladio.BusinessLogic.LoginManager.CheckLogged(token))
            {
                LegaGladio.BusinessLogic.Positional.deletePositional(id);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }
    }
}
