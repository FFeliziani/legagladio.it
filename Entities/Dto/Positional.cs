using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using NHibernate.Util;

namespace LegaGladio.Entities.Dto
{
    public class Positional
    {
        public int Id { get; set; }

        public int Qty { get; set; }
        public int Ma { get; set; }
        public int Ag { get; set; }
        public int Av { get; set; }
        public int St { get; set; }
        public int Cost { get; set; }
        public String Title { get; set; }

        public ICollection<Skill> ListAbility { get; set; }

        public int General { get; set; }
        public int Agility { get; set; }
        public int Strength { get; set; }
        public int Passing { get; set; }
        public int Mutation { get; set; }
        public int Extraordinary { get; set; }

        public Positional(Entities.Positional p)
        {
            Id = p.Id;
            Qty = p.Qty;
            Ma = p.Ma;
            Ag = p.Ag;
            Av = p.Av;
            St = p.St;
            Cost = p.Cost;
            Title = p.Title;
            General = p.General;
            Agility = p.Agility;
            Strength = p.Strength;
            Passing = p.Passing;
            Mutation = p.Mutation;
            Extraordinary = -1;

            ListAbility = p.ListAbility.Select(x => new Entities.Dto.Skill(x)).ToList();
        }
    }
}
