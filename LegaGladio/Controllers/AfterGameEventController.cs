using System;
using System.Collections.Generic;
using System.Web.Http;
using BusinessLogic;
using AfterGameEvent = LegaGladio.Entities.AfterGameEvent;
using Game = LegaGladio.Entities.Game;

namespace LegaGladio.Controllers
{
    public class AfterGameEventController : ApiController
    {
        // GET api/aftergameevent
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("get")]
        public ICollection<AfterGameEvent> Get(Int32 id)
        {
            var game = new Game {Id=id};
            return BusinessLogic.AfterGameEvent.GetAfterGameEvent(game);
        }

        // POST api/aftergameevent
        [HttpPost]
        [ActionName("POST")]
        [AcceptVerbs("POST")]
        public void Post([FromUri]String token, [FromBody]AfterGameEvent data)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request");
            }
            if (LoginManager.CheckLogged(token))
            {
                BusinessLogic.AfterGameEvent.NewAfterGameEvent(data);
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
        public void Put([FromUri]String token, [FromUri]Int32 id, [FromBody]AfterGameEvent data)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request");
            }
            if (LoginManager.CheckLogged(token))
            {
                BusinessLogic.AfterGameEvent.UpdateAfterGameEvent(data, id);
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
            if (LoginManager.CheckLogged(token))
            {
                BusinessLogic.AfterGameEvent.DeleteAfterGameEvent(id);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }
    }
}
