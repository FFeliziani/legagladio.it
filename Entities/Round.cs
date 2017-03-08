using System;
using System.Collections.Generic;

namespace LegaGladio.Entities
{
    public class Round
    {
        public virtual Int32 Id { get; set; }
        public virtual String Name { get; set; }
        public virtual Int32 Number { get; set; }
        public virtual ICollection<Game> GameList { get; set; }
    }
}
