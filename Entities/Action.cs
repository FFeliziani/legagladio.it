using System;

namespace LegaGladio.Entities
{
    public class Action
    {
        public virtual int Id { get; set; }
        public virtual String Description { get; set; }
        public virtual int Spp { get; set; }
        public virtual String Notes { get; set; }
    }
}
