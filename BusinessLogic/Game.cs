using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;
namespace LegaGladio.BusinessLogic
{
    public class Game
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static LegaGladio.Entities.Game get(int id) 
        {
            try
            {
                return DataAccessLayer.Game.getGame(id);
            }
            catch(Exception ex)
            {
                logger.Error(ex, "Error while getting games");
                throw ex;
            }
        }
        public static List<LegaGladio.Entities.Game> listGame()
        {
            try
            {
                return DataAccessLayer.Game.listGame();
            }
            catch(Exception ex)
            {
                logger.Error(ex, "Error while listing games");
                throw ex;
            }
        }
        public static List<LegaGladio.Entities.Game> listGame(LegaGladio.Entities.Team team)
        {
            try
            {
                return DataAccessLayer.Game.listGame(team);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while listing games for team");
                throw ex;
            }
        }
        public static List<LegaGladio.Entities.Game> listGame(LegaGladio.Entities.Coach coach)
        {
            try
            {
                return DataAccessLayer.Game.listGame(coach);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while listing games for coach");
                throw ex;
            }
        }
    }
}
