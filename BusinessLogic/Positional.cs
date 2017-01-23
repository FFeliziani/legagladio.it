using System;
using System.Collections.Generic;
using NLog;

namespace BusinessLogic
{
    public static class Positional
    {
        private readonly static Logger Logger = LogManager.GetCurrentClassLogger();
        
        public static int Count()
        {
            try
            {
                return DataAccessLayer.Positional.CountPositional();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while counting positionals");
                throw;
            }
        }

        public static IEnumerable<LegaGladio.Entities.Positional> List()
        {
            try
            {
                return DataAccessLayer.Positional.ListPositional();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing positionals");
                throw;
            }
        }

        public static IEnumerable<LegaGladio.Entities.Positional> ListByRace(int raceId)
        {
            try
            {
                return DataAccessLayer.Positional.ListPositionalByRace(raceId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing positionals for race - Race Id: [" + raceId + "]");
                throw;
            }
        }

        public static LegaGladio.Entities.Positional Get(int id)
        {
            try
            {
                return DataAccessLayer.Positional.GetPositional(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while getting positional - Id: [" + id + "]");
                throw;
            }
        }

        public static void NewPositional(LegaGladio.Entities.Positional positional)
        {
            try
            {
                DataAccessLayer.Positional.NewPositional(positional);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while creating positional - Positional Data: " + (positional != null ? "Positional Title: [" + positional.Title + "]" : "POSITIONAL IS NULL!!!"));
                throw;
            }
        }

        public static void UpdatePositional(LegaGladio.Entities.Positional positional, int oldId)
        {
            try
            {
                DataAccessLayer.Positional.UpdatePositional(positional, oldId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while updating positional - Positional Data: oldId: [" + oldId + "]" + (positional != null ? "Positional Title: [" + positional.Title + "]" : "POSITIONAL IS NULL!!!"));
                throw;
            }
        }

        public static void DeletePositional(int id)
        {
            try
            {
                DataAccessLayer.Positional.DeletePositional(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while deleting positional - Id: [" + id + "]");
                throw;
            }
        }
    }
}
