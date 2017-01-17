using System;

namespace LegaGladio.Entities
{
    public class GameAction
    {
        public int Id { get; set; }
        public Game Game { get; set; }
        public Action Action { get; set; }
        public Team Team { get; set; }
        public Player Player { get; set; }
        public String Notes { get; set; }
    }
}
