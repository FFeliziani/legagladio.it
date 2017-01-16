using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LegaGladio.Controllers
{
    public class AfterGameEventController : ApiController
    {
        // GET api/aftergameevent
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("GET")]
        public List<LegaGladio.Entities.AfterGameEvent> Get(Int32 id)
        {
            LegaGladio.Entities.Game game = new LegaGladio.Entities.Game(){Id=id};
            return BusinessLogic.AfterGameEvent.getAfterGameEvent(game);
        }

        // POST api/aftergameevent
        [HttpPost]D:\legagladio\legagladio.it\Entities\Skill.cs
        [ActionName("POST")]
        [AcceptVerbs("POST")]
        public void Post([FromUri]String token, [FromBody]LegaGladio.Entities.AfterGameEvent data)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request");
            }
            if (LegaGladio.BusinessLogic.LoginManager.CheckLogged(token))
            {
                LegaGladio.BusinessLogic.AfterGameEvent.newAfterGameEvent(data);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }

        // PUT api/aftergameevent/5
        [HttpPut]
        [ActionName("PUT")]
        [AcceptVerbs("PUT")]
        public void Put([FromUri]String token, [FromUri]Int32 id, [FromBody]LegaGladio.Entities.AfterGameEvent data)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request");
            }
            if (LegaGladio.BusinessLogic.LoginManager.CheckLogged(token))
            {
                LegaGladio.BusinessLogic.AfterGameEvent.updateAfterGameEvent(data, id);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }

        // DELETE api/aftergameevent/5
        [HttpDelete]
        [ActionName("DELETE")]
        [AcceptVerbs("DELETE")]
        public void Delete([FromUri]String token, [FromUri]Int32 id)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request");
            }
            if (LegaGladio.BusinessLogic.LoginManager.CheckLogged(token))
            {
                LegaGladio.BusinessLogic.AfterGameEvent.deleteAfterGameEvent(id);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }
    }
}
