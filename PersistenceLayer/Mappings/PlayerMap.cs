using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LegaGladio.Entities;

namespace PersistenceLayer
{
    class PlayerMap : ClassMap<Player>
    {
        public PlayerMap()
        {
            Id(x => x.Id);
            Map(x => x.MaPlus);
            Map(x => x.AgPlus);
            Map(x => x.AvPlus);
            Map(x => x.StPlus);
            Map(x => x.MaMinus);
            Map(x => x.AgMinus);
            Map(x => x.AvMinus);
            Map(x => x.StMinus);
            Map(x => x.Cost);
            Map(x => x.Name);
            Map(x => x.Spp);
            Map(x => x.Position);
            HasManyToMany<Skill>(x => x.ListAbility).Cascade.All();
            Map(x => x.Retired);
            Map(x => x.Dead);
            Map(x => x.Td);
            Map(x => x.Cas);
            Map(x => x.Pass);
            Map(x => x.Inter);
            Map(x => x.Mvp);
            Map(x => x.Niggling);
            Map(x => x.MissNextGame);
        }
    }
}
