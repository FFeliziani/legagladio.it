using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.LegaGladioDSTableAdapters;

namespace DataAccessLayer
{
    public static class Positional
    {
        public static int CountPositional()
        {
            var pta = new positionalTableAdapter();
            return (int)pta.Count();
        }

        public static List<LegaGladio.Entities.Positional> ListPositional()
        {
            var pta = new positionalTableAdapter();

            var pdt = pta.GetData();

            return (from LegaGladioDS.positionalRow pr in pdt.Rows select GetPositional(pr.id)).ToList();
        }

        public static List<LegaGladio.Entities.Positional> ListPositionalByRace(int raceId)
        {
            var pta = new positionalTableAdapter();
            var pdt = new LegaGladioDS.positionalDataTable();

            pta.FillByRaceId(pdt, raceId);

            return (from LegaGladioDS.positionalRow pr in pdt.Rows select GetPositional(pr.id)).ToList();
        }

        public static LegaGladio.Entities.Positional GetPositional(int id)
        {
            var pta = new positionalTableAdapter();
            var pdt = pta.GetDataById(id);

            if (pdt.Rows.Count > 1)
            {
                throw new Exception("Troppi positional trovati per l'ID " + id);
            }

            if (pdt.Rows.Count == 0)
            {
                return null;
            }

            var pr = (LegaGladioDS.positionalRow)pdt.Rows[0];

            var positional = new LegaGladio.Entities.Positional
            {
                Agility = pr.agility,
                Extraordinary = -1,
                General = pr.general,
                Mutation = pr.mutation,
                Passing = pr.passing,
                Strength = pr.strength,
                Id = pr.id,
                Ma = pr.ma,
                St = pr.st,
                Ag = pr.ag,
                Av = pr.av,
                Cost = Convert.ToInt32(pr.cost),
                Qty = pr.qty,
                Title = pr.title
            };


            positional.ListAbility = Skill.ListSkill(positional);

            return positional;
            
        }

        public static LegaGladio.Entities.Positional GetPositional(LegaGladio.Entities.Player player)
        {
            var pta = new positionalTableAdapter();
            var pdt = pta.GetDataByPlayerId(player.Id);

            if (pdt.Rows.Count > 1)
            {
                throw new Exception("Troppi positional trovati per il Player ID " + player.Id);
            }

            if (pdt.Rows.Count == 0)
            {
                return null;
            }
            var pr = (LegaGladioDS.positionalRow)pdt.Rows[0];

            var positional = new LegaGladio.Entities.Positional
            {
                General = pr.general,
                Agility = pr.agility,
                Strength = pr.strength,
                Passing = pr.passing,
                Mutation = pr.mutation,
                Extraordinary = -1,
                Id = pr.id,
                Ma = pr.ma,
                St = pr.st,
                Ag = pr.ag,
                Av = pr.av,
                Cost = Convert.ToInt32(pr.cost),
                Qty = pr.qty,
                Title = pr.title
            };


            positional.ListAbility = Skill.ListSkill(positional);

            return positional;

        }

        public static Boolean NewPositional(LegaGladio.Entities.Positional positional)
        {
            var pta = new positionalTableAdapter();

            //g, a, s, p, m, e
            var id = pta.Insert(positional.Qty, positional.Title, positional.Cost, positional.Ma, positional.St, positional.Ag, positional.Av, positional.General, positional.Agility, positional.Strength, positional.Passing, positional.Mutation);

            return id > -1;
        }

        public static Boolean UpdatePositional(LegaGladio.Entities.Positional positional, int oldId)
        {
            var pta = new positionalTableAdapter();

            var rowNum = pta.Update(positional.Qty, positional.Title, positional.Cost, positional.Ma, positional.St, positional.Ag, positional.Av, positional.General, positional.Agility, positional.Strength, positional.Passing, positional.Mutation, oldId);

            return rowNum == 1;
        }

        public static Boolean DeletePositional(int id)
        {
            var pta = new positionalTableAdapter();

            var rowNum = pta.Delete(id);

            return rowNum == 1;
        }
    }
}
