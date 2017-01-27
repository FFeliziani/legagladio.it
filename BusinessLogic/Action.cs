using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using NLog;

namespace BusinessLogic
{
    public static class Action
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static LegaGladio.Entities.Action GetAction(Int32 id)
        {
            try
            {
                return DataAccessLayer.Action.GetAction(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while getting action - Action Id: [" + id +"]");
                throw;
            }
        }

        public static ICollection<LegaGladio.Entities.Action> ListAction()
        {
            try
            {
                return DataAccessLayer.Action.ListAction();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing action");
                throw;
            }
        }

        public static void NewAction(LegaGladio.Entities.Action a)
        {
            try
            {
                DataAccessLayer.Action.NewAction(a);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while creating a new action - Action Data: Description: [" + a.Description + "], SPP: [" + a.Spp + "]");
                throw;
            }
        }
    }
}
