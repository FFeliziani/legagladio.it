using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LegaGladio.Controllers
{
    public class CoachController : ApiController
    {

        [ActionName("get")]
        public List<LegaGladio.Entities.Coach> Get()
        {
            return LegaGladio.BusinessLogic.Coach.list();
        }

        [ActionName("getActive")]
        public List<LegaGladio.Entities.Coach> GetActive()
        {
            return LegaGladio.BusinessLogic.Coach.list(true);
        }

        [ActionName("getInactive")]
        public List<LegaGladio.Entities.Coach> GetInactive()
        {
            return LegaGladio.BusinessLogic.Coach.list(false);
        }

        [ActionName("get")]
        // GET api/<controller>/5   
        public LegaGladio.Entities.Coach Get(int coachId)
        {
            return LegaGladio.BusinessLogic.Coach.get(coachId);
        }

        [HttpPost]
        // POST api/<controller>
        public void Post([FromBody]string value)
        {
            //LegaGladio.BusinessLogic.
        }

        [HttpPut]
        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete]
        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}