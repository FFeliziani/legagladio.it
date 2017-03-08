using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace LegaGladio.Entities.Mappings
{
    public class RaceMap : ClassMap<Race>
    {
        public RaceMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Reroll);
        }
    }
}
