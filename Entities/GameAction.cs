using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegaGladio.Entities
{
    class GameAction
    {
        int Id { get; set; }
        Game Game { get; set; }
        Action Action { get; set; }
        Team Team { get; set; }
        Player Player { get; set; }
        String Notes { get; set; }
    }
}
