using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LegaGladio.Controllers
{
    public class TeamController : ApiController
    {
        // GET api/team
        [HttpGet]
        [AcceptVerbs("GET")]
        [ActionName("get")]
        public List<LegaGladio.Entities.Team> Get()
        {
            return LegaGladio.BusinessLogic.Team.list();
        }
        
        // GET api/team/5
        [HttpGet]
        [AcceptVerbs("GET")]
        [ActionName("get")]
        public LegaGladio.Entities.Team Get(int id)
        {
            return LegaGladio.BusinessLogic.Team.get(id);
        }

        // GET api/team/5
        [HttpGet]
        [AcceptVerbs("GET")]
        [ActionName("getByCoach")]
        public List<LegaGladio.Entities.Team> GetByCoach(int id)
        {
            return LegaGladio.BusinessLogic.Team.list(id);
        }
        
        [ActionName("getActive")]
        public List<LegaGladio.Entities.Team> GetActive()
        {
            return LegaGladio.BusinessLogic.Team.list(true);
        }

        [ActionName("getInactive")]
        public List<LegaGladio.Entities.Team> GetInactive()
        {
            return LegaGladio.BusinessLogic.Team.list(false);
        }

        // POST api/team
        [HttpPost]
        [AcceptVerbs("POST")]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/team/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/team/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
