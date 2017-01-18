using System;
using System.Collections.Generic;
using System.Web.Http;
using BusinessLogic;
using Game = LegaGladio.Entities.Game;
using GameAction = LegaGladio.Entities.GameAction;

namespace LegaGladio.Controllers
{
    public class GameActionController : ApiController
    {
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("get")]
        public GameAction Get(Int32 id)
        {
            return BusinessLogic.GameAction.GetGameAction(id);
        }
        
        //GET: api/player
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getByGame")]
        public IEnumerable<GameAction> GetByGame(Int32 id)
        {
            return BusinessLogic.GameAction.ListGameAction(new Game(){Id = id});
        }

        // POST api/player
        [HttpPost]
        [ActionName("post")]
        [AcceptVerbs("POST")]
        public void Post([FromUri]String token, [FromBody]GameAction data)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LoginManager.CheckLogged(token))
            {
                BusinessLogic.GameAction.NewGameAction(data);
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
        public void Put([FromUri]String token, [FromUri]int id, [FromBody]GameAction data)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LoginManager.CheckLogged(token))
            {
                BusinessLogic.GameAction.UpdateGameAction(data, id);
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
                BusinessLogic.GameAction.DeleteGameAction(id);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }
    }
}
