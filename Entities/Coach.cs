using System;
using System.Collections.Generic;

namespace LegaGladio.Entities
{
    public class Coach
    {
        public int id{ get; set; }
        
        public List<Team> ListTeam{ get; set; }
        public String Name{ get; set; }
        public float Value{ get; set; }
        public int NafID{ get; set; }

        public String Notes{ get; set; }

        //private void scrapeCoachValue();
    }
}