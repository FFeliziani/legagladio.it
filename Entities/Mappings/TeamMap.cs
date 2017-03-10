using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace LegaGladio.Entities.Mappings
{
    public class TeamMap : ClassMap<Team>
    {
        TeamMap()
        {
            Id(x => x.Id);
            HasMany<Player>(x => x.ListPlayer).Cascade.All().Table("team_player");
            HasManyToMany<Race>(x => x.Race).Table("team_race").ParentKeyColumn("teamId").ChildKeyColumn("raceId");
            Map(x => x.Value);
            Map(x => x.Name);

            Map(x => x.ImagePath);
            Map(x => x.Active);
            Map(x => x.FanFactor);
            Map(x => x.Reroll);
            Map(x => x.HasMedic);
            Map(x => x.Cheerleader);
            Map(x => x.AssistantCoach);
            //Map(x => x.CoachName);
            //Map(x => x.CoachId);
            Map(x => x.Treasury);
            HasManyToMany<Coach>(x => x.Coach).Table("coach_team").ParentKeyColumn("teamId").ChildKeyColumn("coachId");
        }
    }
}
