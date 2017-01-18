using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLogic;
using Action = LegaGladio.Entities.Action;

namespace LegaGladio.Controllers
{
    public class ActionController : ApiController
    {
        //GET: api/player
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("get")]
        public IEnumerable<Action> Get()
        {
            return BusinessLogic.Action.ListAction();
        }

        // GET api/player/5
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("get")]
        public Action Get(int id)
        {
            return BusinessLogic.Action.GetAction(id);
        }

        // POST api/player
        [HttpPost]
        [ActionName("post")]
        [AcceptVerbs("POST")]   
        public void Post([FromUri]String token, [FromBody]Action data)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LoginManager.CheckLogged(token))
            {
                BusinessLogic.Action.NewAction(data);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }
    }
}
