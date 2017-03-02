using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;

namespace BusinessLogic
{
    public static class Article
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static ICollection<LegaGladio.Entities.Article> ListArticle()
        {
            try
            {
                return DataAccessLayer.Article.ListArticle();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing blog articles");
                throw;
            }
        }

        public static LegaGladio.Entities.Article GetArticle(Int32 id)
        {
            try
            {
                return DataAccessLayer.Article.GetArticle(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while getting blog article");
                throw;
            }
        }

        public static Int32 NewArticle(LegaGladio.Entities.Article article)
        {
            try
            {
                return DataAccessLayer.Article.NewArticle(article);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while creating new article");
                throw;
            }
        }

        public static void UpdateArticle(LegaGladio.Entities.Article article, Int32 oldId)
        {
            try
            {
                DataAccessLayer.Article.UpdateArticle(article, oldId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Exception while updating article");
                throw;
            }
        }

        public static void DeleteArticle(Int32 id)
        {
            try
            {
                DataAccessLayer.Article.DeleteArticle(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Exception while deleting article");
                throw;
            }
        }
    }
}
