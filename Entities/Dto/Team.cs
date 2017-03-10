using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegaGladio.Entities.Dto
{
    public class Team
    {
        public Int32 Id { get; set; }

        public ICollection<Player> ListPlayer { get; set; }
        public ICollection<Player> ListJourneymen { get; set; }
        public Race Race { get; set; }
        public Int32 Value { get; set; }
        public String Name { get; set; }

        public String ImagePath { get; set; }
        public Boolean Active { get; set; }
        public Int32 FanFactor { get; set; }
        public Int32 Reroll { get; set; }
        public bool HasMedic { get; set; }
        public Int32 Cheerleader { get; set; }
        public Int32 AssistantCoach { get; set; }
        public String CoachName { get; set; }
        public Int32 CoachId { get; set; }
        public Int32 Treasury { get; set; }

        public Team(Entities.Team t)
        {
            Id = t.Id;
            ListPlayer = t.ListPlayer.Select(x => new Player(x)).ToList();
            ListJourneymen = t.ListJourneymen.Select(x => new Player(x)).ToList();
            Race = t.Race;
            Value = t.Value;
            Name = t.Name;
            ImagePath = t.ImagePath;
            Active = t.Active;
            FanFactor = t.FanFactor;
            Reroll = t.Reroll;
            HasMedic = t.HasMedic;
            Cheerleader = t.Cheerleader;
            AssistantCoach = t.AssistantCoach;
            CoachName = t.CoachName;
            CoachId = t.CoachId;
            Treasury = t.Treasury;
        }
    }
}
