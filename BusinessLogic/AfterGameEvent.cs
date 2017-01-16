using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;

namespace LegaGladio.BusinessLogic
{
    public class AfterGameEvent
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        
        public static List<LegaGladio.Entities.AfterGameEvent> getAfterGameEvent(LegaGladio.Entities.Game game)
        {
            try
            {
                return DataAccessLayer.AfterGameEvent.getAfterGameEvent(game);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while getting after game events");
                throw ex;
            }
        }

        public static void newAfterGameEvent(LegaGladio.Entities.AfterGameEvent afterGameEvent)
        {
            try
            {
                DataAccessLayer.AfterGameEvent.newAfterGameEvent(afterGameEvent);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while creating a new after game event");
                throw ex;
            }
        }

        public static void updateAfterGameEvent(LegaGladio.Entities.AfterGameEvent afterGameEvent, Int32 oldId)
        {
            try
            {
                DataAccessLayer.AfterGameEvent.updateAfterGameEvent(afterGameEvent, oldId);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while updating an after game event");
                throw ex;
            }
        }

        public static void deleteAfterGameEvent(Int32 id)
        {
            try
            {
                DataAccessLayer.AfterGameEvent.deleteAfterGameEvent(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while deleting an after game event");
                throw ex;
            }
        }
    }
}
