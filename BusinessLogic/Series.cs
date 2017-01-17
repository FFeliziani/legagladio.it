﻿using System;
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
                Logger.Error(ex, "Error while listing players");
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
                Logger.Error(ex, "Error while getting players");
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
                Logger.Error(ex, "Error while adding series to league");
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
                Logger.Error(ex, "Error while removing series from league");
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
                Logger.Error(ex, "Error while creating players");
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
                Logger.Error(ex, "Error while updating players");
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
                Logger.Error(ex, "Error while deleting players");
                throw;
            }
        }
    }
}
