using System;

namespace LegaGladio.Entities
{
    public class Standings
    {
        public virtual Team Team { get; set; }
        public virtual Int32 Wins { get; set; }
        public virtual Int32 Draws { get; set; }
        public virtual Int32 Losses { get; set; }
        public virtual Int32 CasFor { get; set; }
        public virtual Int32 CasAgainst { get; set; }
        public virtual Int32 TdFor { get; set; }
        public virtual Int32 TdAgainst { get; set; }
        public virtual Int32 Points { get; set; }
        public virtual Int32 Delta1 { get; set; }
        public virtual Int32 Delta2 { get; set; }
        public virtual Int32 GamesPlayed { get; set; }
    }
}
