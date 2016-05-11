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

        [HttpGet]
        public List<LegaGladio.Entities.Coach> Get()
        {
            return LegaGladio.BusinessLogic.Coach.list();
        }

        [HttpGet]
        public List<LegaGladio.Entities.Coach> GetActive()
        {
            return LegaGladio.BusinessLogic.Coach.list(true);
        }

        [HttpGet]
        public List<LegaGladio.Entities.Coach> GetInactive()
        {
            return LegaGladio.BusinessLogic.Coach.list(false);
        }

        // GET api/<controller>/5   
        public LegaGladio.Entities.Coach Get(int coachId)
        {
            return LegaGladio.BusinessLogic.Coach.get(coachId);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
            //LegaGladio.BusinessLogic.
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}