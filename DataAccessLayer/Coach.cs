using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.LegaGladioDSTableAdapters;
using Utilities;

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

        public static ICollection<LegaGladio.Entities.Coach> ListCoach()
        {
            var cdt = new LegaGladioDS.coachDataTable();
            var cta = new coachTableAdapter();
            cta.Fill(cdt);
            var coachList = new List<LegaGladio.Entities.Coach>();
            foreach (var coach in from LegaGladioDS.coachRow cr in cdt.Rows select GetCoachFromRow(cr))
            {
                coach.ListTeam = Team.ListTeam(coach.Id);
                coachList.Add(coach);
            }
            return coachList;
        }

        public static ICollection<LegaGladio.Entities.Coach> ListCoach(Boolean active)
        {
            var cdt = new LegaGladioDS.coachDataTable();
            var cta = new coachTableAdapter();
            cta.FillByActive(cdt, active ? 1 : 0);
            var coachList = new List<LegaGladio.Entities.Coach>();
            foreach (var coach in from LegaGladioDS.coachRow cr in cdt.Rows select GetCoachFromRow(cr))
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
            GetCoachFromRow(coachRow);
            coach.ListTeam = Team.ListTeam(coach.Id);
            return coach;
        }

        public static ICollection<LegaGladio.Entities.Coach> GetSimple()
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
            cta.InsertCoach(coach.Name, coach.Value, coach.NafId, coach.Notes, coach.NafNick, coach.ImagePath, (Byte)(coach.Active ? 1 : 0));
        }

        public static void UpdateCoach(LegaGladio.Entities.Coach coach, int oldId)
        {
            var cta = new coachTableAdapter();
            cta.UpdateCoach(coach.Name, coach.Value, coach.NafId, coach.Notes, coach.NafNick, coach.ImagePath, (Byte)(coach.Active ? 1 : 0), oldId);
        }

        public static void DeleteCoach(int id)
        {
            var cta = new coachTableAdapter();
            
            cta.DeleteCoach(id);
        }

        private static LegaGladio.Entities.Coach GetCoachFromRow(LegaGladioDS.coachRow coachRow)
        {
            return new LegaGladio.Entities.Coach
            {
                Id = coachRow.id,
                NafId = !coachRow.IsnafIDNull() ? coachRow.nafID : "",
                NafNick = !coachRow.IsnafNickNull() ? coachRow.nafNick : "",
                Name = !coachRow.IsnameNull() ? coachRow.name : "",
                Notes = !coachRow.IsnoteNull() ? coachRow.note : "",
                Active = !coachRow.IsactiveNull() && coachRow.active == 1,
                Value = !coachRow.IsvalueNull() ? coachRow.value : 0,
                ImagePath = !coachRow.IsimagePathNull() ? coachRow.imagePath : Constants.DefaultCoachImage
            };
        }
    }
}
