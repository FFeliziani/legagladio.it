using System;
using System.Collections.Generic;

namespace LegaGladio.Entities
{
    public class Coach
    {
        public int id{ get; set; }
        
        public List<Team> ListTeam{ get; set; }
        public String Name{ get; set; }
        public int Value{ get; set; }
        public String NafID{ get; set; }

        public Boolean Active { get; set; }
        public String nafNick { get; set; }

        public String Notes{ get; set; }

        //private void scrapeCoachValue();
    }
}