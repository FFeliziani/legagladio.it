using System;
using System.Collections.Generic;

namespace LegaGladio.Entities
{
    public class Team
	{
        public int Id { get; set; }

        public List<Player> ListPlayer { get; set; }
        public Race Race { get; set; }
        public int Value { get; set; }
        public String Name { get; set; }
    
        public int FunFactor { get; set; }
        public int Reroll { get; set; }
        public bool HasMedic { get; set; }
        public int Cheerleader { get; set; }
        public int AssistantCoach { get; set; }
        public String coachName { get; set; }
    }
}