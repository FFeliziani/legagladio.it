using System;
using System.Collections.Generic;

namespace LegaGladio.Entities
{
    public class Team
	{
        public Int32 Id { get; set; }

        public ICollection<Player> ListPlayer { get; set; }
        public ICollection<Player> ListJourneymen { get; set; } 
        public Race Race { get; set; }
        public Int32 Value { get; set; }
        public String Name { get; set; }

        public Boolean Active { get; set; }
        public Int32 FanFactor { get; set; }
        public Int32 Reroll { get; set; }
        public bool HasMedic { get; set; }
        public Int32 Cheerleader { get; set; }
        public Int32 AssistantCoach { get; set; }
        public String CoachName { get; set; }
        public Int32 CoachId { get; set; }
        public Int32 Treasury { get; set; }
    }
}