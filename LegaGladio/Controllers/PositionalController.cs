using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LegaGladio.Controllers
{
    public class PositionalController : ApiController
    {
        // GET api/positional
        [ActionName("get")]
        public IEnumerable<LegaGladio.Entities.Positional> Get()
        {

            return LegaGladio.BusinessLogic.Positional.list();
        }

        [ActionName("get")]
        public LegaGladio.Entities.Positional Get(int id)
        {
            return LegaGladio.BusinessLogic.Positional.get(id);
        }
        
        [ActionName("getByTeam")]
        // GET api/positional/5
        public LegaGladio.Entities.Positional GetByTeam(int id)
        {
            return null;
        }
        
        // POST api/positional
        [HttpPost]
        public void Post([FromBody]LegaGladio.Entities.Positional positional)
        {
            LegaGladio.BusinessLogic.Positional.newPositional(positional);
        }

        // PUT api/positional/5
        [HttpPut]
        public void Put(int id, [FromBody]LegaGladio.Entities.Positional positional)
        {
            LegaGladio.BusinessLogic.Positional.updatePositional(positional, id);
        }

        // DELETE api/positional/5
        [HttpDelete]
        public void Delete(int id)
        {
            LegaGladio.BusinessLogic.Positional.deletePositional(id);
        }
    }
}
