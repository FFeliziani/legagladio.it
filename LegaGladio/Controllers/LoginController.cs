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
        [HttpPost]
        [ActionName("login")]
        [AcceptVerbs("POST")]
        public string login([FromBody]Models.LoginData loginData)
        {
            return LegaGladio.BusinessLogic.LoginManager.Login(loginData.username, loginData.password);
        }
    }
}
