using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLogic;
using Article = LegaGladio.Entities.Article;

namespace LegaGladio.Controllers
{
    public class ArticleController : ApiController
    {
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("get")]
        public ICollection<Article> Get()
        {
            return BusinessLogic.Article.ListArticle();
        }

        // GET api/player/5
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("get")]
        public Article Get(int id)
        {
            return BusinessLogic.Article.GetArticle(id);
        }

        // POST api/player
        [HttpPost]
        [ActionName("post")]
        [AcceptVerbs("POST")]
        public void Post([FromUri]String token, [FromBody]Article data)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LoginManager.CheckLogged(token))
            {
                BusinessLogic.Article.NewArticle(data);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }
    }
}
