using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LegaGladio.Controllers
{
    public class LoginController : ApiController
    {
        [AcceptVerbs("GET", "POST")]
        public string login(String username, String password)
        {
            return LegaGladio.BusinessLogic.LoginManager.Login(username, password);
        }
    }
}
