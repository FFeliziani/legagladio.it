using System;
using System.Web.Http;
using BusinessLogic;

namespace LegaGladio.Controllers
{
    public class LogoutController : ApiController
    {
        // GET api/logout
        [AcceptVerbs("GET", "POST")]
        public void Logout(String token)
        {
            LoginManager.Logout(token);
        }
    }
}
