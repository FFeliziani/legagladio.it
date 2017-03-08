using System;
using System.Collections.Generic;

namespace LegaGladio.Entities
{
    public class Positional
    {
        public virtual int Id { get; set; }

        public virtual int Qty { get; set; }
        public virtual int Ma { get; set; }
        public virtual int Ag { get; set; }
        public virtual int Av { get; set; }
        public virtual int St { get; set; }
        public virtual int Cost { get; set; }
        public virtual String Title { get; set; }

        public virtual ICollection<Skill> ListAbility { get; set; }

        public virtual int General { get; set; }
        public virtual int Agility { get; set; }
        public virtual int Strength { get; set; }
        public virtual int Passing { get; set; }
        public virtual int Mutation { get; set; }
        public virtual int Extraordinary { get; set; }
    }
}
