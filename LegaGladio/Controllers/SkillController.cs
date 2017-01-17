using System;
using System.Collections.Generic;
using System.Web.Http;
using BusinessLogic;
using LegaGladio.Models;
using Skill = LegaGladio.Entities.Skill;

namespace LegaGladio.Controllers
{
    public class SkillController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("get")]
        public IEnumerable<Skill> Get()
        {
            return BusinessLogic.Skill.List();
        }

        // GET api/<controller>/5
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("get")]
        public Skill Get(int id)
        {
            return BusinessLogic.Skill.Get(id);
        }

        [HttpPost]
        [ActionName("addSkillToPlayer")]
        [AcceptVerbs("POST")]
        public void AddSkillToPlayer([FromUri]String token, [FromBody]AddItemsData addItemsData)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LoginManager.CheckLogged(token))
            {
                BusinessLogic.Skill.AddSkillToPlayer(Convert.ToInt32(addItemsData.Id2), Convert.ToInt32(addItemsData.Id1));
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }

        [HttpPost]
        [ActionName("removeSkillFromPlayer")]
        [AcceptVerbs("POST")]
        public void RemoveSkillFromPlayer([FromUri]String token, [FromBody]AddItemsData addItemsData)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LoginManager.CheckLogged(token))
            {
                BusinessLogic.Skill.RemoveSkillFromPlayer(Convert.ToInt32(addItemsData.Id2), Convert.ToInt32(addItemsData.Id1));
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }

        // POST api/<controller>
        [HttpPost]
        [ActionName("post")]
        [AcceptVerbs("POST")]
        public void Post([FromUri]String token, [FromBody]Skill skill)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LoginManager.CheckLogged(token))
            {
                BusinessLogic.Skill.NewSkill(skill);
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
        public void Put([FromUri]String token, [FromUri]int id, [FromBody]Skill skill)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LoginManager.CheckLogged(token))
            {
                BusinessLogic.Skill.UpdateSkill(skill, id);
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
                BusinessLogic.Skill.DeleteSkill(id);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }
    }
}