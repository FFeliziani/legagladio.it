using System;
using System.Collections.Generic;

namespace LegaGladio.Entities
{
    public class Group
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Notes { get; set; }

        public IEnumerable<Round> RoundList { get; set; }
    }
}
