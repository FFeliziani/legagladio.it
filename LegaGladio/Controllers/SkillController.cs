using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LegaGladio.Controllers
{
    public class SkillController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("get")]
        public IEnumerable<LegaGladio.Entities.Skill> Get()
        {
            return LegaGladio.BusinessLogic.Skill.list();
        }

        // GET api/<controller>/5
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("get")]
        public LegaGladio.Entities.Skill Get(int id)
        {
            return LegaGladio.BusinessLogic.Skill.get(id);
        }

        // POST api/<controller>
        [HttpPost]
        [ActionName("post")]
        [AcceptVerbs("POST")]
        public void Post([FromUri]String token, [FromBody]LegaGladio.Entities.Skill skill)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LegaGladio.BusinessLogic.LoginManager.CheckLogged(token))
            {
                LegaGladio.BusinessLogic.Skill.newSkill(skill);
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
        public void Put([FromUri]String token, [FromUri]int id, [FromBody]LegaGladio.Entities.Skill skill)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LegaGladio.BusinessLogic.LoginManager.CheckLogged(token))
            {
                LegaGladio.BusinessLogic.Skill.updateSkill(skill, id);
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
                LegaGladio.BusinessLogic.Skill.deleteSkill(id);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }
    }
}