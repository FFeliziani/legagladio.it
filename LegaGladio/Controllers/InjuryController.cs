using System;
using System.Collections.Generic;
using System.Web.Http;
using LegaGladio.Entities;

namespace LegaGladio.Controllers
{
    public class InjuryController : ApiController
    {
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("GET")]
        public Injury Get(Int32 id)
        {
            return BusinessLogic.Injury.GetInjury(id);
        }

        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("GET")]
        public ICollection<Injury> Get()
        {
            return BusinessLogic.Injury.ListInjury();
        }
    }
}
