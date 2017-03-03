using System;
using System.Collections.Generic;
using System.Web.Http;
using BusinessLogic;
using LegaGladio.Entities;
using LegaGladio.Models;
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

        // GET api/player/5
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getLast")]
        public ICollection<Article> GetLast([FromUri]int id)
        {
            return BusinessLogic.Article.ListLastArticle(id);
        }

        // GET api/player/5
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getByType")]
        public ICollection<Article> GetByType([FromUri]int id)
        {
            return BusinessLogic.Article.ListArticleByType((ArticleType)id);
        }

        // GET api/player/5
        [HttpGet]
        [AcceptVerbs("GET", "POST")]
        [ActionName("getLastByType")]
        public ICollection<Article> GetLastByType([FromBody]TypeCountData data)
        {
            return BusinessLogic.Article.ListArticleLastByType(data.Count, data.Type);
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

        [HttpDelete]
        [ActionName("delete")]
        [AcceptVerbs("DELETE")]
        public void Delete([FromUri]String token, [FromBody]Int32 id)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Please send a token with your request.");
            }
            if (LoginManager.CheckLogged(token))
            {
                BusinessLogic.Article.DeleteArticle(id);
            }
            else
            {
                throw new UnauthorizedAccessException("User not logged");
            }
        }
    }
}
