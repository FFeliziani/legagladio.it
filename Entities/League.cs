using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegaGladio.Entities
{
    public class League
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Details { get; set; }
        public String Noted { get; set; }
        public List<Series> SeriesList { get; set; }
    }
}
