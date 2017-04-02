using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.LegaGladioDSTableAdapters;

namespace DataAccessLayer
{
    public static class Series
    {
        public static List<LegaGladio.Entities.Series> ListSeries(LegaGladio.Entities.League league)
        {
            var sta = new seriesTableAdapter();
            var sdt = new LegaGladioDS.seriesDataTable();
            sta.FillByLeagueId(sdt, league.Id);

            var sL = (from LegaGladioDS.seriesRow sr in sdt.Rows
                select new LegaGladio.Entities.Series
                {
                    Id = sr.id, Name = sr.name, Notes = sr.notes
                }).ToList();

            return sL;
        }

        public static LegaGladio.Entities.Series GetSeries(Int32 id)
        {
            var sta = new seriesTableAdapter();
            var sdt = new LegaGladioDS.seriesDataTable();
            
            sta.FillById(sdt, id);

            if (sdt.Rows.Count != 1)
            {
                throw new ArgumentException("Wrong number of series returned!");
            }

            var sR = (LegaGladioDS.seriesRow)sdt.Rows[0];
            var s = new LegaGladio.Entities.Series {Id = sR.id, Name = sR.name, Notes = sR.notes};
            s.GroupList = Group.ListGroup(s);

            return s;
        }

        public static void AddSeriesToLeague(Int32 seriesId, Int32 leagueId)
        {
            var sta = new seriesTableAdapter();

            sta.AddSeriesToLeague(seriesId, leagueId);
        }

        public static void RemoveSeriesFromLeague(Int32 seriesId, Int32 leagueId)
        {
            var sta = new seriesTableAdapter();

            sta.RemoveSeriesFromLeague(seriesId, leagueId);
        }

        public static void NewSeries(LegaGladio.Entities.Series series)
        {
            var sta = new seriesTableAdapter();

            sta.InsertSeries(series.Name, series.Notes);
        }

        public static void UpdateSeries(LegaGladio.Entities.Series series, Int32 oldId)
        {
            var sta = new seriesTableAdapter();

            sta.UpdateSeries(series.Name, series.Notes, oldId);
        }

        public static void DeleteSeries(Int32 id)
        {
            var sta = new seriesTableAdapter();

            sta.DeleteSeries(id);
        }
    }
}
