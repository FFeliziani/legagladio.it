using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegaGladio.Entities.Dto
{
    public class Player
    {
        public Positional Positional { get; set; }

        public int Id { get; set; }

        public int MaPlus { get; set; }
        public int AgPlus { get; set; }
        public int AvPlus { get; set; }
        public int StPlus { get; set; }
        public int MaMinus { get; set; }
        public int AgMinus { get; set; }
        public int AvMinus { get; set; }
        public int StMinus { get; set; }
        public int Cost { get; set; }
        public String Name { get; set; }
        public int Spp { get; set; }
        public int Position { get; set; }

        public ICollection<Skill> ListAbility { get; set; }

        public Boolean Retired { get; set; }
        public Boolean Dead { get; set; }

        public int Td { get; set; }
        public int Cas { get; set; }
        public int Pass { get; set; }
        public int Inter { get; set; }
        public int Mvp { get; set; }

        public int Niggling { get; set; }

        public Boolean MissNextGame { get; set; }

        public Player(Entities.Player p)
        {
            Id = p.Id;
            MaPlus = p.MaPlus;
            AgPlus = p.AgPlus;
            AvPlus = p.AvPlus;
            StPlus = p.StPlus;
            MaMinus = p.MaMinus;
            AgMinus = p.AgMinus;
            AvMinus = p.AvMinus;
            StMinus = p.StMinus;
            Cost = p.Cost;
            Name = p.Name;
            Spp = p.Spp;
            Position = p.Position;
            Positional = new Positional(p.Positional);
            ListAbility = p.ListAbility.Select(x => new Skill(x)).ToList();
            Retired = p.Retired;
            Dead = p.Dead;
            Td = p.Td;
            Cas = p.Cas;
            Pass = p.Pass;
            Inter = p.Inter;
            Mvp = p.Mvp;
            Niggling = p.Niggling;
            MissNextGame = p.MissNextGame;
        }

    }
}
