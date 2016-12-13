using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace LegaGladio.BusinessLogic
{
    public class Race
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static int count()
        {
            try
            {
                return DataAccessLayer.Race.countRace();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while counting races");
                throw ex;
            }
        }

        public static List<LegaGladio.Entities.Race> list()
        {
            try
            {
                return DataAccessLayer.Race.listRace();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while listing races");
                throw ex;
            }
        }

        public static LegaGladio.Entities.Race get(int id)
        {
            try
            {
                return DataAccessLayer.Race.getRace(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while getting races");
                throw ex;
            }
        }

        public static Boolean newRace(LegaGladio.Entities.Race race)
        {
            try
            {
                return DataAccessLayer.Race.newRace(race);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while creating races");
                throw ex;
            }
        }

        public static Boolean updateRace(LegaGladio.Entities.Race race, int oldID)
        {
            try
            {
                return DataAccessLayer.Race.updateRace(race, oldID);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while updating races");
                throw ex;
            }
        }

        public static Boolean deleteRace(int id)
        {
            try
            {
                return DataAccessLayer.Race.deleteRace(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while deleting races");
                throw ex;
            }
        }
    }
}
