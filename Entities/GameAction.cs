using System;

namespace LegaGladio.Entities
{
    public class GameAction
    {
        public virtual int Id { get; set; }
        public virtual Game Game { get; set; }
        public virtual Action Action { get; set; }
        public virtual Player Player { get; set; }
        public virtual String Notes { get; set; }
    }
}
