using System;
using System.Collections.Generic;
using System.Web.Http;
using BusinessLogic;
using LegaGladio.Models;
using Group = LegaGladio.Entities.Group;
using Series = LegaGladio.Entities.Series;

namespace LegaGladio.Controllers
{
    public class GroupController : ApiController
    {
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("Get")]
        public Group Get(int id)
        {
            return BusinessLogic.Group.GetGroup(id);
        }

        // GET api/player/5
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getBySeries")]
        public ICollection<Group> GetBySeries(int id)
        {
            var series = new Series { Id = id };
            return BusinessLogic.Group.ListGroup(series);
        }

        [HttpPost]
        [ActionName("AddGroupToSeries")]
        [AcceptVerbs("POST")]
        public void AddGroupToSeries([FromUri]String token, [FromBody]AddItemsData addItemsData)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LoginManager.CheckLogged(token))
            {
                BusinessLogic.Group.AddGroupToSeries(Convert.ToInt32(addItemsData.Id2), Convert.ToInt32(addItemsData.Id1));
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }

        [HttpPost]
        [ActionName("RemoveGroupFromSeries")]
        [AcceptVerbs("POST")]
        public void RemoveGroupFromSeries([FromUri]String token, [FromBody]AddItemsData addItemsData)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LoginManager.CheckLogged(token))
            {
                BusinessLogic.Group.RemoveGroupFromSeries(Convert.ToInt32(addItemsData.Id2), Convert.ToInt32(addItemsData.Id1));
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }

        // POST api/player
        [HttpPost]
        [ActionName("post")]
        [AcceptVerbs("POST")]
        public void Post([FromUri]String token, [FromBody]Group data)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LoginManager.CheckLogged(token))
            {
                BusinessLogic.Group.NewGroup(data);
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
        public void Put([FromUri]String token, [FromUri]int id, [FromBody]Group data)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LoginManager.CheckLogged(token))
            {
                BusinessLogic.Group.UpdateGroup(data, id);
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
                BusinessLogic.Group.RemoveGroup(id);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }
    }
}