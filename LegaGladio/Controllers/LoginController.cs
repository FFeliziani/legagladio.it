using System.Web.Http;
using BusinessLogic;
using LegaGladio.Models;

namespace LegaGladio.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        [ActionName("login")]
        [AcceptVerbs("POST")]
        public string Login([FromBody]LoginData loginData)
        {
            return LoginManager.Login(loginData.Username, loginData.Password);
        }
    }
}
