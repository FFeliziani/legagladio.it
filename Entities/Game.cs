using System;

namespace LegaGladio.Entities
{
    public class Game
    {
        public virtual int Id { get; set; }
        public virtual Team Home { get; set; }
        public virtual Team Guest { get; set; }
        public virtual int TdHome { get; set; }
        public virtual int TdGuest { get; set; }
        public virtual int CasHome { get; set; }
        public virtual int CasGuest { get; set; }
        public virtual int SpHome { get; set; }
        public virtual int SpGuest { get; set; }
        public virtual int EarningHome { get; set; }
        public virtual int EarningGuest { get; set; }
        public virtual int VarFfHome { get; set; }
        public virtual int VarFfGuest { get; set; }
        public virtual String Notes { get; set; }
        public virtual DateTime? GameDate { get; set; }
/*
        public List<GameAction> ListGameAction { get; set; }
*/
    }
}
