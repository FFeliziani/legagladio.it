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
            LegaGladioDSTableAdapters.coachTableAdapter cta = new LegaGladioDSTableAdapters.coachTableAdapter();
            int count = (int)cta.Count();
            cta = null;
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
            foreach (LegaGladioDS.coachRow cr in cdt.Rows)
            {
                LegaGladio.Entities.Coach coach = new LegaGladio.Entities.Coach();
                coach.Id = cr.id;
                coach.NafID = cr.nafID;
                coach.Name = cr.name;
                coach.Notes = cr.note;
                coach.Active = cr.active;
                coach.NafNick = cr.nafNick;
                coach.Value = cr.value;
                coach.ListTeam = Team.listTeam(coach.Id);
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
            cta.FillByActive(cdt, active ? 1 : 0);
            List<LegaGladio.Entities.Coach> coachList = new List<LegaGladio.Entities.Coach>();
            foreach (LegaGladioDS.coachRow cr in cdt.Rows)
            {
                try
                {
                    LegaGladio.Entities.Coach coach = new LegaGladio.Entities.Coach();
                    coach.Id = cr.id;
                    coach.NafID = cr.nafID;
                    coach.Name = cr.name;
                    coach.Notes = cr.note;
                    coach.Active = cr.active;
                    coach.NafNick = cr.nafNick;
                    coach.Value = cr.value;
                    coach.ListTeam = Team.listTeam(coach.Id);
                    coachList.Add(coach);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
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
                coach.Id = coachRow.id;
                coach.ListTeam = Team.listTeam(coach.Id);
                coach.NafID = coachRow.nafID;
                coach.NafNick = coachRow.nafNick;
                coach.Name = coachRow.name;
                coach.Notes = coachRow.note;
                coach.Active = coachRow.active;
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

        public static List<LegaGladio.Entities.Coach> getSimple()
        {
            LegaGladioDS.coachDataTable cdt = new LegaGladioDS.coachDataTable();
            LegaGladioDSTableAdapters.coachTableAdapter cta = new LegaGladioDSTableAdapters.coachTableAdapter();
            try
            {
                cta.FillSimple(cdt);
            }
            catch (Exception ex)
            {
                cdt.GetErrors();
                throw ex;
            }
            List<LegaGladio.Entities.Coach> coachList = new List<LegaGladio.Entities.Coach>();
            foreach (LegaGladioDS.coachRow cr in cdt.Rows)
            {
                LegaGladio.Entities.Coach coach = new LegaGladio.Entities.Coach();
                coach.Id = cr.id;
                coach.Name = cr.name;
                coachList.Add(coach);
            }
            cta = null;
            cdt = null;
            return coachList;
        }

        public static String getCoachName(int teamID)
        {
            LegaGladioDSTableAdapters.coachTableAdapter cta = null;
            String coachName = null;
            try
            {
                cta = new LegaGladioDSTableAdapters.coachTableAdapter();
                coachName = cta.GetCoachName(teamID).ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return coachName;
        }

        public static Int32 getCoachId(int teamID)
        {
            LegaGladioDSTableAdapters.coachTableAdapter cta = null;
            Int32 coachId = 0;
            try
            {
                cta = new LegaGladioDSTableAdapters.coachTableAdapter();
                coachId = Convert.ToInt32(cta.GetCoachId(teamID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return coachId;
        }

        public static Boolean newCoach(LegaGladio.Entities.Coach coach)
        {
            LegaGladioDSTableAdapters.coachTableAdapter cta = new LegaGladioDSTableAdapters.coachTableAdapter();
            int result = cta.Insert(coach.Name, coach.Value, coach.NafID, coach.Notes, coach.Active ? 1 : 0, coach.NafNick);
            cta = null;
            return result > 0;
        }

        public static void updateCoach(LegaGladio.Entities.Coach coach, int oldID)
        {
            LegaGladioDSTableAdapters.coachTableAdapter cta = new LegaGladioDSTableAdapters.coachTableAdapter();

            cta.Update(coach.Name, coach.Value, coach.NafID, coach.Notes, coach.Active ? 1 : 0, coach.NafNick, oldID);
            //LegaGladioDS.coachDataTable cdt = new LegaGladioDS.coachDataTable();
            //LegaGladioDS.coachRow cr = (LegaGladioDS.coachRow)cdt.NewRow();
            //cr.id = oldID;
            //cr.name = coach.Name;
            //cr.active = coach.Active;
            //cr.nafID = coach.NafID;
            //cr.nafNick = coach.NafNick;
            //cr.note = coach.Notes;
            //cr.value = coach.Value;
            //int result = cta.Update(cr);
        }

        public static Boolean deleteCoach(int id)
        {
            LegaGladioDSTableAdapters.coachTableAdapter cta = new LegaGladioDSTableAdapters.coachTableAdapter();
            int result = cta.Delete(id);
            cta = null;
            return result > 0;
        }
    }
}
