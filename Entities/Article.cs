using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegaGladio.Entities
{
    public class Article
    {
        public Int32 Id { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public User Owner { get; set; }
        public ArticleType ArticleType { get; set; }
        public String Note { get; set; }
    }
}
