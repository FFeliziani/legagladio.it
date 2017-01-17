using System;
using System.Collections.Generic;
using NLog;

namespace BusinessLogic
{
    public static class Race
    {
        private readonly static Logger Logger = LogManager.GetCurrentClassLogger();

        public static int Count()
        {
            try
            {
                return DataAccessLayer.Race.CountRace();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while counting races");
                throw;
            }
        }

        public static List<LegaGladio.Entities.Race> List()
        {
            try
            {
                return DataAccessLayer.Race.ListRace();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing races");
                throw;
            }
        }

        public static LegaGladio.Entities.Race Get(int id)
        {
            try
            {
                return DataAccessLayer.Race.GetRace(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while getting races");
                throw;
            }
        }

        public static Boolean NewRace(LegaGladio.Entities.Race race)
        {
            try
            {
                return DataAccessLayer.Race.NewRace(race);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while creating races");
                throw;
            }
        }

        public static Boolean UpdateRace(LegaGladio.Entities.Race race, int oldId)
        {
            try
            {
                return DataAccessLayer.Race.UpdateRace(race, oldId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while updating races");
                throw;
            }
        }

        public static Boolean DeleteRace(int id)
        {
            try
            {
                return DataAccessLayer.Race.DeleteRace(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while deleting races");
                throw;
            }
        }
    }
}
