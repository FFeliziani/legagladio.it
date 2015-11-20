using System;
using System.Collections;
using System.Collections.Generic;

namespace LegaGladio.Entities
{
    public class Player
    {
        public int Id { get; set; }

        public int Ma { get; set;}
        public int Ag { get; set; }
        public int Av { get; set; }
        public int St { get; set; }
        public float Cost { get; set; }
        public String Name { get; set; }
        public int Spp { get; set; }

        public List<Skill> ListAbility { get; set; }

        public int Td { get; set; }
        public int Cas { get; set; }
        public int Pass { get; set; }
        public int Cat { get; set; }

        public int Niggling { get; set; }

        public Boolean MissNextGame { get; set; }
    }
}