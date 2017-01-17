using System;
using System.Collections.Generic;
using NLog;

namespace BusinessLogic
{
    public static class Player
    {
        private readonly static Logger Logger = LogManager.GetCurrentClassLogger();
        
        public static int Count()
        {
            try
            {
                return DataAccessLayer.Player.CountPlayer();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while counting players");
                throw;
            }
        }

        public static IEnumerable<LegaGladio.Entities.Player> List()
        {
            try
            {
                return DataAccessLayer.Player.ListPlayer();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing players");
                throw;
            }
        }
        public static IEnumerable<LegaGladio.Entities.Player> List(int teamId)
        {
            try
            {
                return DataAccessLayer.Player.ListPlayer(teamId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing players for team");
                throw;
            }
        }

        public static IEnumerable<LegaGladio.Entities.Player> List(int teamId, Boolean active)
        {
            try
            {
                return DataAccessLayer.Player.ListPlayer(teamId, active);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing active players for team");
                throw;
            }
        }

        public static LegaGladio.Entities.Player Get(int id)
        {
            try
            {
                return DataAccessLayer.Player.GetPlayer(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while getting players");
                throw;
            }
        }

        public static void NewPlayer(LegaGladio.Entities.Player player)
        {
            try
            {
                DataAccessLayer.Player.NewPlayer(player);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while creating players");
                throw;
            }
        }

        public static void UpdatePlayer(LegaGladio.Entities.Player player, int oldId)
        {
            try
            {
                DataAccessLayer.Player.UpdatePlayer(player, oldId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while updating players");
                throw;
            }
        }

        public static void DeletePlayer(int id)
        {
            try
            {
                DataAccessLayer.Player.DeletePlayer(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while deleting players");
                throw;
            }
        }
    }
}
