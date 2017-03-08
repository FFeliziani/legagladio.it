using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace LegaGladio.Entities.Mappings
{
    public class SkillMap : ClassMap<Skill>
    {
        public SkillMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.SkillType).Column("type").CustomType<SkillType>();
        }
    }
}
