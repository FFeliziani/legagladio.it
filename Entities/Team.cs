using System;
using System.Collections.Generic;

namespace LegaGladio.Entities
{
    public class Team
	{
        public virtual Int32 Id { get; set; }

        public virtual ICollection<Player> ListPlayer { get; set; }
        public virtual ICollection<Player> ListJourneymen { get; set; }
        public virtual Race Race { get; set; }
        public virtual Int32 Value { get; set; }
        public virtual String Name { get; set; }

        public virtual String ImagePath { get; set; }
        public virtual Boolean Active { get; set; }
        public virtual Int32 FanFactor { get; set; }
        public virtual Int32 Reroll { get; set; }
        public virtual bool HasMedic { get; set; }
        public virtual Int32 Cheerleader { get; set; }
        public virtual Int32 AssistantCoach { get; set; }
        public virtual Coach Coach { get; set; }
        public virtual Int32 Treasury { get; set; }
    }
}