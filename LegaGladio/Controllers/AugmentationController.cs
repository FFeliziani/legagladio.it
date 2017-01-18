using System;
using System.Collections.Generic;
using System.Web.Http;
using LegaGladio.Entities;

namespace LegaGladio.Controllers
{
    public class AugmentationController : ApiController
    {
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("GET")]
        public Augmentation Get(Int32 id)
        {
            return BusinessLogic.Augmentation.GetAugmentation(id);
        }

        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("GET")]
        public IEnumerable<Augmentation> Get()
        {
            return BusinessLogic.Augmentation.ListAugmentation();
        }
    }
}
