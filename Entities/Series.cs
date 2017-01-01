using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegaGladio.Entities
{
    public class Series
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Notes { get; set; }
        public List<Round> RoundList { get; set; }
    }
}
