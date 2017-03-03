using System;
using System.Collections.Generic;
using NLog;

namespace BusinessLogic
{
    public static class Injury
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static LegaGladio.Entities.Injury GetInjury(Int32 id)
        {
            try
            {
                return DataAccessLayer.Injury.GetInjury(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while gettin injury - Injury Id: [" + id + "]");
                throw;
            }
        }

        public static ICollection<LegaGladio.Entities.Injury> ListInjury()
        {
            try
            {
                return DataAccessLayer.Injury.ListInInjury();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing injuries");
                throw;
            }
        }

        public static void NewInjury(LegaGladio.Entities.Injury injury)
        {
            try
            {
                DataAccessLayer.Injury.NewInjury(injury);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while creating new injury - Injury Data: " + (injury != null ? "Injury Name: [" + injury.Name + "]" : "INJURY IS NULL!!!"));
                throw;
            }
        }

        public static void UpdateInjury(LegaGladio.Entities.Injury injury, Int32 oldId)
        {
            try
            {
                DataAccessLayer.Injury.UpdateInjury(injury, oldId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while updating injury - Injury Data: " + (injury != null ? "OldId: [" + oldId + "], Injury Name: [" + injury.Name + "]" : "INJURY IS NULL!!!"));
                throw;
            }
        }

        public static void DeleteInjury(Int32 id)
        {
            try
            {
                DataAccessLayer.Injury.DeleteInjury(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while deleting injury - Id: [" + id + "]");
                throw;
            }
        }
    }
}
