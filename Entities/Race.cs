using System;

namespace LegaGladio.Entities
{
    public class Race
    {
        public virtual int Id { get; set; }
        public virtual String Name { get; set; }
        public virtual int Reroll { get; set; }
    }
}
