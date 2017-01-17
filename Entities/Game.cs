using System;
using System.Collections.Generic;

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
        public int VarFfHome { get; set; }
        public int VarFfGuest { get; set; }
        public String Notes { get; set; }
/*
        public List<GameAction> ListGameAction { get; set; }
*/
    }
}
