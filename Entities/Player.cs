using System;
using System.Collections.Generic;

namespace LegaGladio.Entities
{
    public class Player
    {
        public virtual Positional Positional { get; set; }

        public virtual int Id { get; set; }

        public virtual int MaPlus { get; set;}
        public virtual int AgPlus { get; set; }
        public virtual int AvPlus { get; set; }
        public virtual int StPlus { get; set; }
        public virtual int MaMinus { get; set; }
        public virtual int AgMinus { get; set; }
        public virtual int AvMinus { get; set; }
        public virtual int StMinus { get; set; }
        public virtual int Cost { get; set; }
        public virtual String Name { get; set; }
        public virtual int Spp { get; set; }
        public virtual int Position { get; set; }

        public virtual ICollection<Skill> ListAbility { get; set; }

        public virtual Boolean Retired { get; set; }
        public virtual Boolean Dead { get; set; }

        public virtual int Td { get; set; }
        public virtual int Cas { get; set; }
        public virtual int Pass { get; set; }
        public virtual int Inter { get; set; }
        public virtual int Mvp { get; set; }

        public virtual int Niggling { get; set; }

        public virtual Boolean MissNextGame { get; set; }
    }
}