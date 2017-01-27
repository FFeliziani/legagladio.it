using System;
using System.Collections.Generic;
using NLog;

namespace BusinessLogic
{
    public static class League
    {
        private readonly static Logger Logger = LogManager.GetCurrentClassLogger();

        public static ICollection<LegaGladio.Entities.League> ListLeague()
        {
            try
            {
                return DataAccessLayer.League.ListLeague();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing Leagues");
                throw;
            }
        }

        public static LegaGladio.Entities.League GetLeague(Int32 id)
        {
            try
            {
                return DataAccessLayer.League.GetLeague(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while getting league - Id: [" + id + "]");
                throw;
            }
        }

        public static void NewLeague(LegaGladio.Entities.League league)
        {
            try
            {
                DataAccessLayer.League.NewLeague(league);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while creating new League - League Data: " + (league != null ? " League Name: [" + league.Name + "]" : "LEAGUE IS NULL!!!"));
                throw;
            }
        }

        public static void UpdateLeague(LegaGladio.Entities.League league, Int32 oldId)
        {
            try
            {
                DataAccessLayer.League.UpdateLeague(league, oldId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while updating league - League Data: " + (league != null ? " oldId: [" + oldId + "], League Name: [" + league.Name + "]" : "LEAGUE IS NULL!!!"));
                throw;
            }
        }

        public static void RemoveLeague(Int32 id)
        {
            try
            {
                DataAccessLayer.League.RemoveLeague(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while deleting league - Id: [" + id + "]");
                throw;
            }
        }
    }
}
