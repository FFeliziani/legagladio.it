using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegaGladio.Entities
{
    class AfterGameEvent
    {
        int Id { get; set; }
        Player Player { get; set; }
        Skill Skill { get; set; }
        Injury Injury { get; set; }
    }
}
