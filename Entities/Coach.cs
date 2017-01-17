using System;
using System.Collections.Generic;

namespace LegaGladio.Entities
{
    public class Coach
    {
        public int Id{ get; set; }
        
        public List<Team> ListTeam{ get; set; }
        public String Name{ get; set; }
        public int Value{ get; set; }
        public String NafId{ get; set; }

        public Boolean Active { get; set; }
        public String NafNick { get; set; }

        public String Notes{ get; set; }

        //private void scrapeCoachValue();
    }
}