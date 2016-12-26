using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LegaGladio.Controllers
{
    public class LogoutController : ApiController
    {
        // GET api/logout
        [AcceptVerbs("GET", "POST")]
        public void logout(String token)
        {
            BusinessLogic.LoginManager.Logout(token);
        }
    }
}
