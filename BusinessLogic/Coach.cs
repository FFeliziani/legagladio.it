using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace LegaGladio.BusinessLogic
{
    public class Coach
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static int count()
        {
            try
            {
                return DataAccessLayer.Coach.countCoach();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while counting coaches");
                throw ex;
            }
        }

        public static List<LegaGladio.Entities.Coach> list()
        {
            try
            {
                return DataAccessLayer.Coach.listCoach();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while listing coaches");
                throw ex;
            }
        }

        public static List<LegaGladio.Entities.Coach> list(Boolean active)
        {
            try
            {
                return DataAccessLayer.Coach.listCoach(active);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while listing coaches");
                throw ex;
            }
        }

        public static LegaGladio.Entities.Coach get(int id)
        {
            try
            {
                return DataAccessLayer.Coach.getCoach(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while getting coaches");
                throw ex;
            }
        }

        public static Boolean newCoach(LegaGladio.Entities.Coach coach)
        {
            try
            {
                return DataAccessLayer.Coach.newCoach(coach);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while creating coaches");
                throw ex;
            }
        }

        public static Boolean updateCoach(LegaGladio.Entities.Coach coach, int oldID)
        {
            try
            {
                return DataAccessLayer.Coach.updateCoach(coach, oldID);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while updating coaches");
                throw ex;
            }
        }

        public static Boolean deleteCoach(int id)
        {
            try
            {
                return DataAccessLayer.Coach.deleteCoach(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while deleting coaches");
                throw ex;
            }
        }
    }
}
