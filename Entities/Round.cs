using System;
using System.Collections.Generic;

namespace LegaGladio.Entities
{
    public class Round
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public Int32 Number { get; set; }
        public List<Game> GameList { get; set; }
    }
}
