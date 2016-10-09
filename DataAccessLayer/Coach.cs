using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegaGladio;

namespace DataAccessLayer
{
    public class Coach
    {
        public static int countCoach()
        {
            LegaGladioDSTableAdapters.coachTableAdapter pta = new LegaGladioDSTableAdapters.coachTableAdapter();
            int count = (int)pta.Count();
            pta = null;
            return count;
        }

        public static List<LegaGladio.Entities.Coach> listCoach()
        {
            LegaGladioDS.coachDataTable cdt = new LegaGladioDS.coachDataTable();
            LegaGladioDSTableAdapters.coachTableAdapter cta = new LegaGladioDSTableAdapters.coachTableAdapter();
            try
            {
                cta.Fill(cdt);
            }
            catch (Exception ex)
            {
                cdt.GetErrors();
                throw ex;
            }
            List<LegaGladio.Entities.Coach> coachList = new List<LegaGladio.Entities.Coach>();
            foreach(LegaGladioDS.coachRow cr in cdt.Rows)
            {
                LegaGladio.Entities.Coach coach = new LegaGladio.Entities.Coach();
                coach.id = (int)cr.id;
                coach.NafID = cr.nafID;
                coach.Name = cr.name;
                coach.Notes = cr.note;
                coach.Active = cr.active;
                coach.Value = cr.value;
                coach.ListTeam = Team.listTeam(coach.id);
                coachList.Add(coach);
            }
            cta = null;
            cdt = null;
            return coachList;
        }

        public static List<LegaGladio.Entities.Coach> listCoach(Boolean active)
        {
            LegaGladioDS.coachDataTable cdt = new LegaGladioDS.coachDataTable();
            LegaGladioDSTableAdapters.coachTableAdapter cta = new LegaGladioDSTableAdapters.coachTableAdapter();
            cta.FillByActive(cdt, active);
            List<LegaGladio.Entities.Coach> coachList = new List<LegaGladio.Entities.Coach>();
            foreach (LegaGladioDS.coachRow cr in cdt.Rows)
            {
                LegaGladio.Entities.Coach coach = new LegaGladio.Entities.Coach();
                coach.id = (int)cr.id;
                coach.NafID = cr.nafID;
                coach.Name = cr.name;
                coach.Notes = cr.note;
                coach.Active = cr.active;
                coach.Value = cr.value;
                coach.ListTeam = Team.listTeam(coach.id);
                coachList.Add(coach);
            }
            cta = null;
            cdt = null;
            return coachList;
        }

        public static LegaGladio.Entities.Coach getCoach(int id)
        {
            LegaGladio.Entities.Coach coach = null;
            LegaGladioDS.coachDataTable ctd = null;
            LegaGladioDSTableAdapters.coachTableAdapter cta = null;
            LegaGladioDS.coachRow coachRow = null;
            try
            {
                coach = new LegaGladio.Entities.Coach();
                ctd = new LegaGladioDS.coachDataTable();
                cta = new LegaGladioDSTableAdapters.coachTableAdapter();
                cta.FillById(ctd, id);
                coachRow = (LegaGladioDS.coachRow)ctd.Rows[0];
                coach.id = (int)coachRow.id;
                coach.ListTeam = Team.listTeam(coach.id);
                coach.NafID = coachRow.nafID;
                coach.Name = coachRow.name;
                coach.Notes = coachRow.note;
                coach.Value = coachRow.value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cta = null;
            ctd = null;
            return coach;
        }

        public static String getCoachName(int teamID)
        {
            LegaGladioDSTableAdapters.coachTableAdapter cta = null;
            String coachName = null;
            try
            {
                coachName = cta.GetCoachName(teamID).ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return coachName;
        }

        public static Boolean newCoach(LegaGladio.Entities.Coach coach)
        {
            return false;
        }

        public static Boolean updateCoach(LegaGladio.Entities.Coach coach, int oldID)
        {
            return false;
        }

        public static Boolean deleteCoach(int id)
        {
            return false;
        }
    }
}
