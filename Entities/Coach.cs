using System;
using System.Collections.Generic;

namespace LegaGladio.Entities
{
    public class Coach
    {
        public virtual int Id{ get; set; }
        
        public virtual ICollection<Team> ListTeam{ get; set; }
        public virtual String Name{ get; set; }
        public virtual int Value{ get; set; }
        public virtual String NafId{ get; set; }
        public virtual String ImagePath { get; set; }

        public virtual Boolean Active { get; set; }
        public virtual String NafNick { get; set; }

        public virtual String Notes{ get; set; }

        //private void scrapeCoachValue();
    }
}