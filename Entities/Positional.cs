using System;
using System.Collections.Generic;

namespace LegaGladio.Entities
{
    public class Positional
    {
        public int Id { get; set; }

        public int Qty { get; set; }
        public int Ma { get; set; }
        public int Ag { get; set; }
        public int Av { get; set; }
        public int St { get; set; }
        public int Cost { get; set; }
        public String Title { get; set; }

        public IEnumerable<Skill> ListAbility { get; set; }

        public int General { get; set; }
        public int Agility { get; set; }
        public int Strength { get; set; }
        public int Passing { get; set; }
        public int Mutation { get; set; }
        public int Extraordinary { get; set; }
        
    }
}
