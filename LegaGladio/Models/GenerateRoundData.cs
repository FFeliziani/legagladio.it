using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LegaGladio.Models
{
    public class GenerateRoundData
    {
        public Int32 GroupId { get; set; }
        public ICollection<Int32> TeamIds { get; set; }
    }
}