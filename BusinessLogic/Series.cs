using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;

namespace LegaGladio.BusinessLogic
{
    public class Series
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        
        public static List<LegaGladio.Entities.Series> list(LegaGladio.Entities.League league)
        {
            try
            {
                return DataAccessLayer.Series.listSeries(league);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while listing players");
                throw ex;
            }
        }

        public static LegaGladio.Entities.Series get(int id)
        {
            try
            {
                return DataAccessLayer.Series.getSeries(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while getting players");
                throw ex;
            }
        }

        public static void addSeriesToLeague(Int32 seriesId, Int32 leagueId)
        {
            try
            {
                DataAccessLayer.Series.addSeriesToLeague(seriesId, leagueId);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while adding series to league");
                throw ex;
            }
        }

        public static void removeSeriesFromLeague(Int32 seriesId, Int32 leagueId)
        {
            try
            {
                DataAccessLayer.Series.removeSeriesFromLeague(seriesId, leagueId);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while removing series from league");
            }
        }

        public static void newSeries(LegaGladio.Entities.Series series)
        {
            try
            {
                DataAccessLayer.Series.newSeries(series);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while creating players");
                throw ex;
            }
        }

        public static void updateSeries(LegaGladio.Entities.Series series, int oldID)
        {
            try
            {
                DataAccessLayer.Series.updateSeries(series, oldID);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while updating players");
                throw ex;
            }
        }

        public static void deleteSeries(int id)
        {
            try
            {
                DataAccessLayer.Series.deleteSeries(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while deleting players");
                throw ex;
            }
        }
    }
}
