﻿using System;
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
        [ActionName("get")]
        public List<LegaGladio.Entities.Team> Get()
        {
            return LegaGladio.BusinessLogic.Team.list();
        }

        // GET api/team/5
        [ActionName("getByCoach")]
        public List<LegaGladio.Entities.Team> GetByCoach(int coachId)
        {
            return LegaGladio.BusinessLogic.Team.list(coachId);
        }

        // GET api/team/5
        [ActionName("get")]
        public LegaGladio.Entities.Team Get(int id)
        {
            return LegaGladio.BusinessLogic.Team.get(id);
        }

        // POST api/team
        [HttpPost]
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