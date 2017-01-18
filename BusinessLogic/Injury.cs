using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
