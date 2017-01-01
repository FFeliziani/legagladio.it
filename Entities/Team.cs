using System;
using System.Collections.Generic;

namespace LegaGladio.Entities
{
    public class Team
	{
        public Int32 Id { get; set; }

        public List<Player> ListPlayer { get; set; }
        public Race Race { get; set; }
        public Int32 Value { get; set; }
        public String Name { get; set; }

        public Boolean Active { get; set; }
        public Int32 FunFactor { get; set; }
        public Int32 Reroll { get; set; }
        public bool HasMedic { get; set; }
        public Int32 Cheerleader { get; set; }
        public Int32 AssistantCoach { get; set; }
        public String coachName { get; set; }
        public Int32 coachId { get; set; }
    }
}