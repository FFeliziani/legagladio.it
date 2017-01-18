using System;
using System.Collections.Generic;

namespace LegaGladio.Entities
{
    public class Player
    {
        public Positional Positional { get; set; }

        public int Id { get; set; }

        public int MaPlus { get; set;}
        public int AgPlus { get; set; }
        public int AvPlus { get; set; }
        public int StPlus { get; set; }
        public int MaMinus { get; set; }
        public int AgMinus { get; set; }
        public int AvMinus { get; set; }
        public int StMinus { get; set; }
        public float Cost { get; set; }
        public String Name { get; set; }
        public int Spp { get; set; }
        public int Position { get; set; }

        public IEnumerable<Skill> ListAbility { get; set; }

        public Boolean Retired { get; set; }
        public Boolean Dead { get; set; }

        public int Td { get; set; }
        public int Cas { get; set; }
        public int Pass { get; set; }
        public int Inter { get; set; }
        public int Mvp { get; set; }

        public int Niggling { get; set; }

        public Boolean MissNextGame { get; set; }
    }
}