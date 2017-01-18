﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;
using NLog.LayoutRenderers;

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
                Logger.Error(ex, "Error while gettin injury");
                throw;
            }
        }

        public static IEnumerable<LegaGladio.Entities.Injury> ListInjury()
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
                Logger.Error(ex, "Error while creating new injury");
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
                Logger.Error(ex, "Error while updating injury");
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
                Logger.Error(ex, "Error whule deleting injury");
                throw;
            }
        }
    }
}
