using System;
using System.Collections.Generic;
using LegaGladio.Entities;
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

        public static ICollection<LegaGladio.Entities.Article> ListLastArticle(Int32 count)
        {
            try
            {
                return DataAccessLayer.Article.ListLastArticle(count);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing last blog article");
                throw;
            }
        }

        public static ICollection<LegaGladio.Entities.Article> ListArticleByType(ArticleType type)
        {
            try
            {
                return DataAccessLayer.Article.ListArticleByType(type);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing blog articles for type");
                throw;
            }
        }

        public static ICollection<LegaGladio.Entities.Article> ListArticleLastByType(Int32 count, ArticleType type)
        {
            try
            {
                return DataAccessLayer.Article.ListLastArticleByType(count, type);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing last blog articles for type");
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
