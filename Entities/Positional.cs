using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public float Cost { get; set; }
        public String Title { get; set; }

        public List<Skill> ListAbility { get; set; }

        public Skills General { get; set; }
        public Skills Agility { get; set; }
        public Skills Strength { get; set; }
        public Skills Passing { get; set; }
        public Skills Mutation { get; set; }
        public Skills Extraordinary { get; set; }
        
    }
}
