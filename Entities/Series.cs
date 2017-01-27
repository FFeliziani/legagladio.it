using System;
using System.Collections.Generic;

namespace LegaGladio.Entities
{
    public class Series
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Notes { get; set; }
        public ICollection<Group> GroupList { get; set; }
    }
}
