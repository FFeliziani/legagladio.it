using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public IEnumerable<Standing> GetBySeries(Int32 id)
        {
            return BusinessLogic.Standings.GetStandings(new Series() {Id = id});
        }

        [HttpGet]
        [ActionName("GetByGroup")]
        [AcceptVerbs("GET")]
        public IEnumerable<Standing> GetByGroup(Int32 id)
        {
            return BusinessLogic.Standings.GetStandings(new Group() {Id = id});
        } 
    }
}
