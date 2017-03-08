using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using FluentNHibernate.Mapping;

namespace LegaGladio.Entities.Mappings
{
    public class PositionalMap : ClassMap<Positional>
    {
        public PositionalMap()
        {
            Id(x => x.Id);
            Map(x => x.Qty);
            Map(x => x.Ma);
            Map(x => x.Ag);
            Map(x => x.Av);
            Map(x => x.St);
            Map(x => x.Cost);
            Map(x => x.Title);

            HasManyToMany<Skill>(x => x.ListAbility).Cascade.All().Table("positional_skill").ChildKeyColumn("skillID").ParentKeyColumn("positionalID");

            Map(x => x.General);
            Map(x => x.Agility);
            Map(x => x.Strength);
            Map(x => x.Passing);
            Map(x => x.Mutation);
        }
    }
}
