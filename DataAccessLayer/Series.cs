using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class Series
    {
        public static List<LegaGladio.Entities.Series> listSeries(LegaGladio.Entities.League league)
        {
            LegaGladioDSTableAdapters.seriesTableAdapter sta = null;
            LegaGladioDS.seriesDataTable sdt = null;
            List<LegaGladio.Entities.Series> sL = null;

            try
            {
                sta = new LegaGladioDSTableAdapters.seriesTableAdapter();
                sdt = new LegaGladioDS.seriesDataTable();
                sL = new List<LegaGladio.Entities.Series>();
                sta.FillByLeagueId(sdt, league.Id);

                foreach (LegaGladioDS.seriesRow sr in sdt.Rows)
                {
                    LegaGladio.Entities.Series s = new LegaGladio.Entities.Series();

                    s.Id = sr.id;
                    s.Name = sr.name;
                    s.Notes = sr.notes;
                    sL.Add(s);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sta = null;
                sdt = null;
            }

            return sL;
        }

        public static LegaGladio.Entities.Series getSeries(Int32 id)
        {
            LegaGladioDSTableAdapters.seriesTableAdapter sta = null;
            LegaGladioDS.seriesDataTable sdt = null;
            LegaGladio.Entities.Series s = null;
            LegaGladioDS.seriesRow sR = null;

            try
            {
                sta = new LegaGladioDSTableAdapters.seriesTableAdapter();
                sdt = new LegaGladioDS.seriesDataTable();
                s = new LegaGladio.Entities.Series();
                sta.FillById(sdt, id);

                if (sdt.Rows.Count != 1)
                {
                    throw new ArgumentException("Wrong number of series returned!");
                }

                sR = (LegaGladioDS.seriesRow)sdt.Rows[0];

                s.Id = sR.id;
                s.Name = sR.name;
                s.Notes = sR.notes;
                s.GroupList = Group.listGroup(s);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sta = null;
                sdt = null;
            }

            return s;
        }

        public static void addSeriesToLeague(Int32 seriesId, Int32 leagueId)
        {
            LegaGladioDSTableAdapters.seriesTableAdapter sta = new LegaGladioDSTableAdapters.seriesTableAdapter();

            sta.AddSeriesToLeague(seriesId, leagueId);
        }

        public static void removeSeriesFromLeague(Int32 seriesId, Int32 leagueId)
        {
            LegaGladioDSTableAdapters.seriesTableAdapter sta = new LegaGladioDSTableAdapters.seriesTableAdapter();

            sta.RemoveSeriesFromLeague(seriesId, leagueId);
        }

        public static void newSeries(LegaGladio.Entities.Series series)
        {
            LegaGladioDSTableAdapters.seriesTableAdapter sta = new LegaGladioDSTableAdapters.seriesTableAdapter();

            sta.Insert(series.Name, series.Notes);
        }

        public static void updateSeries(LegaGladio.Entities.Series series, Int32 oldId)
        {
            LegaGladioDSTableAdapters.seriesTableAdapter sta = new LegaGladioDSTableAdapters.seriesTableAdapter();

            sta.Update(series.Name, series.Notes, oldId);
        }

        public static void deleteSeries(Int32 id)
        {
            LegaGladioDSTableAdapters.seriesTableAdapter sta = new LegaGladioDSTableAdapters.seriesTableAdapter();

            sta.Delete(id);
        }
    }
}
