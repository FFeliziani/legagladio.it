﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;

namespace BusinessLogic
{
    public static class Augmentation
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static LegaGladio.Entities.Augmentation GetAugmentation(Int32 id)
        {
            try
            {
                return DataAccessLayer.Augmentation.GetAugmentation(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while getting augmentation");
                throw;
            }
        }

        public static IEnumerable<LegaGladio.Entities.Augmentation> ListAugmentation()
        {
            try
            {
                return DataAccessLayer.Augmentation.ListAugmentation();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing augmentation");
                throw;
            }
        }

        public static void NewAugmentation(LegaGladio.Entities.Augmentation augmentation)
        {
            try
            {
                DataAccessLayer.Augmentation.NewAugmentation(augmentation);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while creating new augmentation");
                throw;
            }
        }

        public static void UpdateAugmentation(LegaGladio.Entities.Augmentation augmentation, Int32 oldId)
        {
            try
            {
                DataAccessLayer.Augmentation.UpdateAugmentation(augmentation, oldId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while updating augmentation");
                throw;
            }
        }

        public static void DeleteAugmentation(Int32 id)
        {
            try
            {
                DataAccessLayer.Augmentation.DeleteAugmentation(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while deleting augmentation");
                throw;
            }
        }
    }
}
