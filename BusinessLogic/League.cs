using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;

namespace LegaGladio.BusinessLogic
{
    public class League
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static List<LegaGladio.Entities.League> listLeague()
        {
            try
            {
                return DataAccessLayer.League.listLeague();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while listing Leagues");
                throw ex;
            }
        }

        public static LegaGladio.Entities.League getLeague(Int32 id)
        {
            try
            {
                return DataAccessLayer.League.getLeague(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while getting league");
                throw ex;
            }
        }

        public static void newLeague(LegaGladio.Entities.League league)
        {
            try
            {
                DataAccessLayer.League.newLeague(league);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while creating new League");
                throw ex;
            }
        }

        public static void updateLeague(LegaGladio.Entities.League league, Int32 oldId)
        {
            try
            {
                DataAccessLayer.League.updateLeague(league, oldId);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while updating league");
                throw ex;
            }
        }

        public static void removeLeague(Int32 id)
        {
            try
            {
                DataAccessLayer.League.removeLeague(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while deleting league");
                throw ex;
            }
        }
    }
}
