using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegaGladio.Entities
{
    class Game
    {
        int Id { get; set; }
        Team HomeID { get; set; }
        Team GuestID { get; set; }
        int TdHome { get; set; }
        int TdGuest { get; set; }
        int CasHome { get; set; }
        int CasGuest { get; set; }
        int SpHouse { get; set; }
        int SpGuest { get; set; }
        int EearningHome { get; set; }
        int EarningHuest { get; set; }
        int VarFFHouse { get; set; }
        int VarFFGuest { get; set; }
        String Notes { get; set; }
        List<GameAction> ListGameAction { get; set; }
    }
}
