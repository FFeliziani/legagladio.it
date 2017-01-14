using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Positional
    {
        public static int countPositional()
        {
            LegaGladioDSTableAdapters.positionalTableAdapter pta = new LegaGladioDSTableAdapters.positionalTableAdapter();
            return (int)pta.Count();
        }

        public static List<LegaGladio.Entities.Positional> listPositional()
        {
            LegaGladioDSTableAdapters.positionalTableAdapter pta = new LegaGladioDSTableAdapters.positionalTableAdapter();

            List<LegaGladio.Entities.Positional> positionalList = new List<LegaGladio.Entities.Positional>();

            LegaGladioDS.positionalDataTable pdt = pta.GetData();

            foreach (LegaGladioDS.positionalRow pr in pdt.Rows)
            {
                LegaGladio.Entities.Positional positional = Positional.getPositional((int)pr.id);

                positionalList.Add(positional);
            }

            return positionalList;
        }

        public static List<LegaGladio.Entities.Positional> listPositionalByRace(int raceId)
        {
            LegaGladioDSTableAdapters.positionalTableAdapter pta = null;
            LegaGladioDS.positionalDataTable pdt = null;

            pta = new LegaGladioDSTableAdapters.positionalTableAdapter();
            pdt = new LegaGladioDS.positionalDataTable();

            List<LegaGladio.Entities.Positional> positionalList = new List<LegaGladio.Entities.Positional>();

            try
            {
                pta.FillByRaceId(pdt, raceId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            foreach (LegaGladioDS.positionalRow pr in pdt.Rows)
            {
                LegaGladio.Entities.Positional positional = Positional.getPositional((int)pr.id);

                positionalList.Add(positional);
            }

            return positionalList;
        }

        public static LegaGladio.Entities.Positional getPositional(int id)
        {
            LegaGladioDSTableAdapters.positionalTableAdapter pta = null;
            LegaGladioDS.positionalDataTable pdt = null;
            LegaGladioDS.positionalRow pr = null;
            LegaGladio.Entities.Positional positional = null;

            try
            {
                pta = new LegaGladioDSTableAdapters.positionalTableAdapter();
                pdt = pta.GetDataById(id);

                if (pdt.Rows.Count > 1)
                {
                    throw new Exception("Troppi positional trovati per l'ID " + id);
                }

                if (pdt.Rows.Count == 0)
                {
                    return null;
                }

                pr = (LegaGladioDS.positionalRow)pdt.Rows[0];

                positional = new LegaGladio.Entities.Positional();

                positional.Agility = pr.agility;
                positional.Extraordinary = -1;
                positional.General = pr.general;
                positional.Mutation = pr.mutation;
                positional.Passing = pr.passing;
                positional.Strength = pr.strength;

                positional.Id = pr.id;
                positional.Ma = pr.ma;
                positional.St = pr.st;
                positional.Ag = pr.ag;
                positional.Av = pr.av;
                positional.Cost = Convert.ToInt32(pr.cost);
                positional.Qty = pr.qty;
                positional.Title = pr.title;
                positional.ListAbility = Skill.listSkill(positional);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return positional;
            
        }

        public static LegaGladio.Entities.Positional getPositional(LegaGladio.Entities.Player player)
        {
            LegaGladioDSTableAdapters.positionalTableAdapter pta = null;
            LegaGladioDS.positionalDataTable pdt = null;
            LegaGladioDS.positionalRow pr = null;
            LegaGladio.Entities.Positional positional = null;

            try
            {
                pta = new LegaGladioDSTableAdapters.positionalTableAdapter();
                pdt = pta.GetDataByPlayerId(player.Id);

                if (pdt.Rows.Count > 1)
                {
                    throw new Exception("Troppi positional trovati per il Player ID " + player.Id);
                }

                if (pdt.Rows.Count == 0)
                {
                    return null;
                }
                pr = (LegaGladioDS.positionalRow)pdt.Rows[0];

                positional = new LegaGladio.Entities.Positional();

                positional.General = pr.general;
                positional.Agility = pr.agility;
                positional.Strength = pr.strength;
                positional.Passing = pr.passing;
                positional.Mutation = pr.mutation;
                positional.Extraordinary = -1;

                positional.Id = pr.id;
                positional.Ma = pr.ma;
                positional.St = pr.st;
                positional.Ag = pr.ag;
                positional.Av = pr.av;
                positional.Cost = Convert.ToInt32(pr.cost);
                positional.Qty = pr.qty;
                positional.Title = pr.title;
                positional.ListAbility = Skill.listSkill(positional);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return positional;

        }

        public static Boolean newPositional(LegaGladio.Entities.Positional positional)
        {
            LegaGladioDSTableAdapters.positionalTableAdapter pta = new LegaGladioDSTableAdapters.positionalTableAdapter();
            LegaGladioDSTableAdapters.positional_skillTableAdapter psta = new LegaGladioDSTableAdapters.positional_skillTableAdapter();

            //g, a, s, p, m, e
            int id = (int)pta.Insert(positional.Qty, positional.Title, positional.Cost, positional.Ma, positional.St, positional.Ag, positional.Av, positional.General, positional.Agility, positional.Strength, positional.Passing, positional.Mutation);

            return id > -1;
        }

        public static Boolean updatePositional(LegaGladio.Entities.Positional positional, int oldID)
        {
            LegaGladioDSTableAdapters.positionalTableAdapter pta = new LegaGladioDSTableAdapters.positionalTableAdapter();

            int rowNum = pta.Update(positional.Qty, positional.Title, positional.Cost, positional.Ma, positional.St, positional.Ag, positional.Av, positional.General, positional.Agility, positional.Strength, positional.Passing, positional.Mutation, oldID);

            return rowNum == 1;
        }

        public static Boolean deletePositional(int id)
        {
            LegaGladioDSTableAdapters.positionalTableAdapter pta = new LegaGladioDSTableAdapters.positionalTableAdapter();

            int rowNum = pta.Delete(id);

            return rowNum == 1;
        }
    }
}
