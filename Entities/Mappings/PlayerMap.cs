using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace LegaGladio.Entities.Mappings
{
    public class PlayerMap : ClassMap<Player>
    {
        public PlayerMap()
        {
            Id(x => x.Id);
            Map(x => x.MaPlus).Column("map");
            Map(x => x.AgPlus).Column("agp");
            Map(x => x.AvPlus).Column("avp");
            Map(x => x.StPlus).Column("stp");
            Map(x => x.MaMinus).Column("mam");
            Map(x => x.AgMinus).Column("agm");
            Map(x => x.AvMinus).Column("avm");
            Map(x => x.StMinus).Column("stm");
            Map(x => x.Cost);
            Map(x => x.Name);
            Map(x => x.Spp);
            Map(x => x.Position);
            HasManyToMany<Skill>(x => x.ListAbility).Cascade.All().Table("player_skill").ChildKeyColumn("skillId").ParentKeyColumn("playerId");
            Map(x => x.Retired);
            Map(x => x.Dead);
            Map(x => x.Td);
            Map(x => x.Cas);
            Map(x => x.Pass);
            Map(x => x.Inter);
            Map(x => x.Mvp);
            Map(x => x.Niggling);
            Map(x => x.MissNextGame);
            References<Positional>(x => x.Positional).Cascade.All().Column("positionalId");
        }
    }
}
