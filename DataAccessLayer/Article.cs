using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.LegaGladioDSTableAdapters;
using LegaGladio.Entities;


namespace DataAccessLayer
{
    public static class Article
    {
        public static ICollection<LegaGladio.Entities.Article> ListArticle()
        {
            var ata = new articleTableAdapter();
            var adt = new LegaGladioDS.articleDataTable();
            ata.Fill(adt);
            return (from LegaGladioDS.articleRow ar in adt.Rows select GetArticleFromRow(ar)).ToList();
        }

        public static LegaGladio.Entities.Article GetArticle(Int32 id)
        {
            var ata = new articleTableAdapter();
            var adt = new LegaGladioDS.articleDataTable();
            ata.FillById(adt, id);
            if (adt.Rows.Count == 0) return null;
            if(adt.Rows.Count != 1) throw new Exception("Error whie getting article... too many returned.");
            return GetArticleFromRow((LegaGladioDS.articleRow)adt.Rows[0]);
        }

        public static ICollection<LegaGladio.Entities.Article> ListLastArticle(Int32 count)
        {
            return ListArticle().Take(count).ToList();
        }

        public static ICollection<LegaGladio.Entities.Article> ListArticleByType(ArticleType type)
        {
            var ata = new articleTableAdapter();
            var adt = new LegaGladioDS.articleDataTable();
            ata.FillByArticleType(adt, (Int32) type);
            return (from LegaGladioDS.articleRow ar in adt.Rows select GetArticleFromRow(ar)).OrderByDescending(x => x.Created).ToList();
        }

        public static ICollection<LegaGladio.Entities.Article> ListLastArticleByType(Int32 count, ArticleType type)
        {
            return ListArticleByType(type).Take(count).ToList();
        } 

        public static Int32 NewArticle(LegaGladio.Entities.Article article)
        {
            var ata = new articleTableAdapter();
            ata.InsertArticle(article.Title, article.Content, DateTime.Now, DateTime.Now, 0, Convert.ToInt16(article.ArticleType), article.Note);
            return 0;
        }

        public static void UpdateArticle(LegaGladio.Entities.Article article, Int32 oldId)
        {
            var ata = new articleTableAdapter();
            ata.UpdateArticle(article.Id, article.Title, article.Content, article.Created, article.Updated, 0, article.ArticleType, article.Note, oldId);
        }

        public static void DeleteArticle(Int32 id)
        {
            var ata = new articleTableAdapter();
            ata.DeleteArticle(id);
        }

        private static LegaGladio.Entities.Article GetArticleFromRow(LegaGladioDS.articleRow row)
        {
            return new LegaGladio.Entities.Article
            {
                Id = row.id,
                ArticleType = !row.IsarticletypeNull() ? (ArticleType)row.articletype : ArticleType.Blog,
                Content = !row.IscontentNull() ? row.content : "",
                Created = !row.IscreatedNull() ? row.created : (DateTime?)null,
                Note = !row.IsnoteNull() ? row.note : "",
                Owner = !row.IsowneridNull() ? new User() : null,
                Title = !row.IstitleNull() ? row.title : "",
                Updated = !row.IsupdatedNull() ? row.updated : (DateTime?)null
            };
        }
    }
}
