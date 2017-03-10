using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace LegaGladio.Entities.Mappings
{
    public class CoachMap : ClassMap<Coach>
    {
        public CoachMap()
        {
            Id(x => x.Id);

            HasMany<Team>(x => x.ListTeam).Cascade.All().Table("coach_team").KeyColumn("teamId");

            Map(x => x.Name);
            Map(x => x.Value);
            Map(x => x.NafId);
            Map(x => x.ImagePath);
            Map(x => x.Active);
            Map(x => x.NafNick);
            Map(x => x.Notes);
        }
    }
}
