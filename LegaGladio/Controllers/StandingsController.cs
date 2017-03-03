using System;
using System.Collections.Generic;
using System.Web.Http;
using LegaGladio.Entities;

namespace LegaGladio.Controllers
{
    public class StandingsController : ApiController
    {
        // GET api/standings
        [HttpGet]
        [ActionName("GetBySeries")]
        [AcceptVerbs("GET")]
        public IEnumerable<Standings> GetBySeries(Int32 id)
        {
            return BusinessLogic.Standings.GetStandings(new Series {Id = id});
        }

        [HttpGet]
        [ActionName("GetByGroup")]
        [AcceptVerbs("GET")]
        public IEnumerable<Standings> GetByGroup(Int32 id)
        {
            return BusinessLogic.Standings.GetStandings(new Group {Id = id});
        } 
    }
}
