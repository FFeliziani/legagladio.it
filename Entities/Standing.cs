using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;

namespace LegaGladio.Entities
{
    public class Standing
    {
        public Team Team { get; set; }
        public Int32 Wins { get; set; }
        public Int32 Draws { get; set; }
        public Int32 Losses { get; set; }
        public Int32 CasFor { get; set; }
        public Int32 CasAgainst { get; set; }
        public Int32 TdFor { get; set; }
        public Int32 TdAgainst { get; set; }
        public Int32 Points { get; set; }
        public Int32 Delta1 { get; set; }
        public Int32 Delta2 { get; set; }
        public Int32 GamesPlayed { get; set; }
    }
}
