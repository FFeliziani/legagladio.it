using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.LegaGladioDSTableAdapters;

namespace DataAccessLayer
{
    public static class League
    {
        public static ICollection<LegaGladio.Entities.League> ListLeague()
        {
            var lta = new leagueTableAdapter();
            var ldt = new LegaGladioDS.leagueDataTable();
            lta.Fill(ldt);
            var lL = (from LegaGladioDS.leagueRow lr in ldt.Rows
                select new LegaGladio.Entities.League
                {
                    Id = lr.id, Name = lr.name, Notes = lr.notes, Details = lr.details
                }).ToList();
            return lL;
        }

        public static LegaGladio.Entities.League GetLeague(Int32 id)
        {
            var lta = new leagueTableAdapter();
            var ldt = new LegaGladioDS.leagueDataTable();
            lta.FillById(ldt, id);
            if (ldt.Rows.Count != 1) throw new Exception("Wrong number of rows returned for league");
            var lr = (LegaGladioDS.leagueRow) ldt.Rows[0];
            var l = new LegaGladio.Entities.League {Id = lr.id, Name = lr.name, Notes = lr.notes, Details = lr.details};
            l.SeriesList = Series.ListSeries(l);
            return l;
        }

        public static void NewLeague(LegaGladio.Entities.League league)
        {
            var lta = new leagueTableAdapter();

            lta.Insert(league.Name, league.Details, league.Notes);
        }

        public static void UpdateLeague(LegaGladio.Entities.League league, Int32 oldId)
        {
            var lta = new leagueTableAdapter();

            lta.Update(league.Name, league.Details, league.Notes, oldId);
        }

        public static void RemoveLeague(Int32 id)
        {
            var lta = new leagueTableAdapter();

            lta.Delete(id);
        }
    }
}
