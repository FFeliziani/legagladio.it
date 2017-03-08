using System;
using System.Collections.Generic;

namespace LegaGladio.Entities
{
    public class Group
    {
        public virtual Int32 Id { get; set; }
        public virtual String Name { get; set; }
        public virtual String Notes { get; set; }

        public virtual ICollection<Round> RoundList { get; set; }
    }
}
