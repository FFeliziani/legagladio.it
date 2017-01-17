using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.LegaGladioDSTableAdapters;

namespace DataAccessLayer
{
    public static class Coach
    {
        public static int CountCoach()
        {
            var cta = new coachTableAdapter();
            var count = (int)cta.Count();
            return count;
        }

        public static IEnumerable<LegaGladio.Entities.Coach> ListCoach()
        {
            var cdt = new LegaGladioDS.coachDataTable();
            var cta = new coachTableAdapter();
            cta.Fill(cdt);
            var coachList = new List<LegaGladio.Entities.Coach>();
            foreach (var coach in from LegaGladioDS.coachRow cr in cdt.Rows select new LegaGladio.Entities.Coach
            {
                Id = cr.id,
                NafId = cr.nafID,
                Name = cr.name,
                Notes = cr.note,
                Active = cr.active == 1,
                NafNick = cr.nafNick,
                Value = cr.value
            })
            {
                coach.ListTeam = Team.ListTeam(coach.Id);
                coachList.Add(coach);
            }
            return coachList;
        }

        public static IEnumerable<LegaGladio.Entities.Coach> ListCoach(Boolean active)
        {
            var cdt = new LegaGladioDS.coachDataTable();
            var cta = new coachTableAdapter();
            cta.FillByActive(cdt, active ? 1 : 0);
            var coachList = new List<LegaGladio.Entities.Coach>();
            foreach (var coach in from LegaGladioDS.coachRow cr in cdt.Rows select new LegaGladio.Entities.Coach
            {
                Id = cr.id,
                NafId = cr.nafID,
                Name = cr.name,
                Notes = cr.note,
                Active = cr.active == 1,
                NafNick = cr.nafNick,
                Value = cr.value
            })
            {
                coach.ListTeam = Team.ListTeam(coach.Id);
                coachList.Add(coach);
            }
            return coachList;
        }

        public static LegaGladio.Entities.Coach GetCoach(int id)
        {
            var coach = new LegaGladio.Entities.Coach();
            var ctd = new LegaGladioDS.coachDataTable();
            var cta = new coachTableAdapter();
            cta.FillById(ctd, id);
            var coachRow = (LegaGladioDS.coachRow)ctd.Rows[0];
            coach.Id = coachRow.id;
            coach.ListTeam = Team.ListTeam(coach.Id);
            coach.NafId = coachRow.nafID;
            coach.NafNick = coachRow.nafNick;
            coach.Name = coachRow.name;
            coach.Notes = coachRow.note;
            coach.Active = coachRow.active == 1;
            coach.Value = coachRow.value;
            return coach;
        }

        public static IEnumerable<LegaGladio.Entities.Coach> GetSimple()
        {
            var cdt = new LegaGladioDS.coachDataTable();
            var cta = new coachTableAdapter();
            cta.FillSimple(cdt);
            var coachList = (from LegaGladioDS.coachRow cr in cdt.Rows select new LegaGladio.Entities.Coach {Id = cr.id, Name = cr.name}).ToList();
            return coachList;
        }

        public static String GetCoachName(int teamId)
        {
            var cta = new coachTableAdapter();
            var coachName = cta.GetCoachName(teamId).ToString();
            return coachName;
        }

        public static Int32 GetCoachId(int teamId)
        {
            var cta = new coachTableAdapter();
            var coachId = Convert.ToInt32(cta.GetCoachId(teamId));
            return coachId;
        }

        public static void NewCoach(LegaGladio.Entities.Coach coach)
        {
            var cta = new coachTableAdapter();
            cta.Insert(coach.Name, coach.Value, coach.NafId, coach.Notes, coach.Active ? 1 : 0, coach.NafNick);
        }

        public static void UpdateCoach(LegaGladio.Entities.Coach coach, int oldId)
        {
            var cta = new coachTableAdapter();

            cta.Update(coach.Name, coach.Value, coach.NafId, coach.Notes, coach.Active ? 1 : 0, coach.NafNick, oldId);
        }

        public static void DeleteCoach(int id)
        {
            var cta = new coachTableAdapter();
            cta.Delete(id);
        }
    }
}
