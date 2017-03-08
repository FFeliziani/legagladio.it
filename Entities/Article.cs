using System;

namespace LegaGladio.Entities
{
    public class Article
    {
        public virtual Int32 Id { get; set; }
        public virtual String Title { get; set; }
        public virtual String Content { get; set; }
        public virtual DateTime? Created { get; set; }
        public virtual DateTime? Updated { get; set; }
        public virtual User Owner { get; set; }
        public virtual ArticleType ArticleType { get; set; }
        public virtual String Note { get; set; }
    }
}
