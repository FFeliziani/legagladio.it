using System;
using System.Collections.Generic;
using NLog;

namespace BusinessLogic
{
    public static class AfterGameEvent
    {
        private readonly static Logger Logger = LogManager.GetCurrentClassLogger();
        
        public static IEnumerable<LegaGladio.Entities.AfterGameEvent> GetAfterGameEvent(LegaGladio.Entities.Game game)
        {
            try
            {
                return DataAccessLayer.AfterGameEvent.GetAfterGameEvent(game);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while getting after game events");
                throw;
            }
        }

        public static void NewAfterGameEvent(LegaGladio.Entities.AfterGameEvent afterGameEvent)
        {
            try
            {
                DataAccessLayer.AfterGameEvent.NewAfterGameEvent(afterGameEvent);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while creating a new after game event");
                throw;
            }
        }

        public static void UpdateAfterGameEvent(LegaGladio.Entities.AfterGameEvent afterGameEvent, Int32 oldId)
        {
            try
            {
                DataAccessLayer.AfterGameEvent.UpdateAfterGameEvent(afterGameEvent, oldId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while updating an after game event");
                throw;
            }
        }

        public static void DeleteAfterGameEvent(Int32 id)
        {
            try
            {
                DataAccessLayer.AfterGameEvent.DeleteAfterGameEvent(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while deleting an after game event");
                throw;
            }
        }
    }
}
