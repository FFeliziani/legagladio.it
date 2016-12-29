using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace LegaGladio.BusinessLogic
{
    public class Positional
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        
        public static int count()
        {
            try
            {
                return DataAccessLayer.Positional.countPositional();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while counting positionals");
                throw ex;
            }
        }

        public static List<LegaGladio.Entities.Positional> list()
        {
            try
            {
                return DataAccessLayer.Positional.listPositional();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while listing positionals");
                throw ex;
            }
        }

        public static List<LegaGladio.Entities.Positional> listByTeam(int teamId)
        {
            try
            {
                return DataAccessLayer.Positional.listPositionalByTeam(teamId);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while listing positionals for team " + teamId);
                throw ex;
            }
        }

        public static LegaGladio.Entities.Positional get(int id)
        {
            try
            {
                return DataAccessLayer.Positional.getPositional(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while getting positionals");
                throw ex;
            }
        }

        public static Boolean newPositional(LegaGladio.Entities.Positional positional)
        {
            try
            {
                return DataAccessLayer.Positional.newPositional(positional);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while creating positionals");
                throw ex;
            }
        }

        public static Boolean updatePositional(LegaGladio.Entities.Positional positional, int oldID)
        {
            try
            {
                return DataAccessLayer.Positional.updatePositional(positional, oldID);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while updating positionals");
                throw ex;
            }
        }

        public static Boolean deletePositional(int id)
        {
            try
            {
                return DataAccessLayer.Positional.deletePositional(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while deleting positionals");
                throw ex;
            }
        }
    }
}
