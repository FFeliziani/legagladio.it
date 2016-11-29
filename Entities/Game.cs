using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegaGladio.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public Team Home { get; set; }
        public Team Guest { get; set; }
        public int TdHome { get; set; }
        public int TdGuest { get; set; }
        public int CasHome { get; set; }
        public int CasGuest { get; set; }
        public int SpHome { get; set; }
        public int SpGuest { get; set; }
        public int EarningHome { get; set; }
        public int EarningGuest { get; set; }
        public int VarFFHome { get; set; }
        public int VarFFGuest { get; set; }
        public String Notes { get; set; }
        public List<GameAction> ListGameAction { get; set; }
    }
}
