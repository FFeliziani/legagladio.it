using System;
using System.Collections.Generic;

namespace LegaGladio.Entities
{
    public class League
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Details { get; set; }
        public String Notes { get; set; }
        public ICollection<Series> SeriesList { get; set; }
    }
}
