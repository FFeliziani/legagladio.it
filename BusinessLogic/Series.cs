using System;
using System.Collections.Generic;
using NLog;

namespace BusinessLogic
{
    public static class Series
    {
        private readonly static Logger Logger = LogManager.GetCurrentClassLogger();

        
        public static IEnumerable<LegaGladio.Entities.Series> List(LegaGladio.Entities.League league)
        {
            try
            {
                return DataAccessLayer.Series.ListSeries(league);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing Series for League - League Id: [" + league.Id + "]");
                throw;
            }
        }

        public static LegaGladio.Entities.Series Get(int id)
        {
            try
            {
                return DataAccessLayer.Series.GetSeries(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while getting Series by Id - Id: [" + id + "]");
                throw;
            }
        }

        public static void AddSeriesToLeague(Int32 seriesId, Int32 leagueId)
        {
            try
            {
                DataAccessLayer.Series.AddSeriesToLeague(seriesId, leagueId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while adding series to league - Series Id: [" + seriesId + "], League Id: [" + leagueId + "]");
                throw;
            }
        }

        public static void RemoveSeriesFromLeague(Int32 seriesId, Int32 leagueId)
        {
            try
            {
                DataAccessLayer.Series.RemoveSeriesFromLeague(seriesId, leagueId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while removing series from league - Series Id: [" + seriesId + "], League Id: [" + leagueId + "]");
            }
        }

        public static void NewSeries(LegaGladio.Entities.Series series)
        {
            try
            {
                DataAccessLayer.Series.NewSeries(series);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while creating series - Series Data: " + (series != null ? "Series Name: [" + series.Name + "]" : "SERIES IS NULL!!!"));
                throw;
            }
        }

        public static void UpdateSeries(LegaGladio.Entities.Series series, int oldId)
        {
            try
            {
                DataAccessLayer.Series.UpdateSeries(series, oldId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while updating Series - Series Data: oldId: [" + oldId + "], " + (series != null ? "Series Name: [" + series.Name + "]" : "SERIES IS NULL!!!"));
                throw;
            }
        }

        public static void DeleteSeries(int id)
        {
            try
            {
                DataAccessLayer.Series.DeleteSeries(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while deleting series - id: [" + id + "]");
                throw;
            }
        }
    }
}
