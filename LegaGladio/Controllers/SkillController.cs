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
        [ActionName("get")]
        public IEnumerable<LegaGladio.Entities.Skill> Get()
        {
            return LegaGladio.BusinessLogic.Skill.list();
        }

        // GET api/<controller>/5
        [ActionName("get")]
        public LegaGladio.Entities.Skill Get(int id)
        {
            return LegaGladio.BusinessLogic.Skill.get(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]LegaGladio.Entities.Skill skill)
        {
            LegaGladio.BusinessLogic.Skill.newSkill(skill);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public void Put(int id, [FromBody]LegaGladio.Entities.Skill skill)
        {
            LegaGladio.BusinessLogic.Skill.updateSkill(skill, id);
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public void Delete(int id)
        {
            LegaGladio.BusinessLogic.Skill.deleteSkill(id);
        }
    }
}