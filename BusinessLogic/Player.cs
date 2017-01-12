using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog;

namespace LegaGladio.BusinessLogic
{
    public class Player
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        
        public static int count()
        {
            try
            {
                return DataAccessLayer.Player.countPlayer();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while counting players");
                throw ex;
            }
        }

        public static List<LegaGladio.Entities.Player> list()
        {
            try
            {
                return DataAccessLayer.Player.listPlayer();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while listing players");
                throw ex;
            }
        }
        public static List<LegaGladio.Entities.Player> list(int teamID)
        {
            try
            {
                return DataAccessLayer.Player.listPlayer(teamID);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while listing players for team");
                throw ex;
            }
        }

        public static List<LegaGladio.Entities.Player> list(int teamID, Boolean active)
        {
            try
            {
                return DataAccessLayer.Player.listPlayer(teamID, active);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while listing active players for team");
                throw ex;
            }
        }

        public static LegaGladio.Entities.Player get(int id)
        {
            try
            {
                return DataAccessLayer.Player.getPlayer(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while getting players");
                throw ex;
            }
        }

        public static Boolean newPlayer(LegaGladio.Entities.Player player)
        {
            try
            {
                return DataAccessLayer.Player.newPlayer(player);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while creating players");
                throw ex;
            }
        }

        public static void updatePlayer(LegaGladio.Entities.Player player, int oldID)
        {
            try
            {
                DataAccessLayer.Player.updatePlayer(player, oldID);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while updating players");
                throw ex;
            }
        }

        public static Boolean deletePlayer(int id)
        {
            try
            {
                return DataAccessLayer.Player.deletePlayer(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while deleting players");
                throw ex;
            }
        }
    }
}
