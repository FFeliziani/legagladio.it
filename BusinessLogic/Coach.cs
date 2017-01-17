using System;
using System.Collections.Generic;
using NLog;

namespace BusinessLogic
{
    public static class Coach
    {
        private readonly static Logger Logger = LogManager.GetCurrentClassLogger();

        /*public static int Count()
        {
            try
            {
                return DataAccessLayer.Coach.CountCoach();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while counting coaches");
                throw;
            }
        }*/

        public static IEnumerable<LegaGladio.Entities.Coach> List()
        {
            try
            {
                return DataAccessLayer.Coach.ListCoach();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing coaches");
                throw;
            }
        }

        public static IEnumerable<LegaGladio.Entities.Coach> List(Boolean active)
        {
            try
            {
                return DataAccessLayer.Coach.ListCoach(active);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing coaches");
                throw;
            }
        }

        public static IEnumerable<LegaGladio.Entities.Coach> ListSimple()
        {
            try
            {
                return DataAccessLayer.Coach.GetSimple();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while simple listing coaches");
                throw;
            }
        }

        public static LegaGladio.Entities.Coach Get(int id)
        {
            try
            {
                return DataAccessLayer.Coach.GetCoach(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while getting coaches");
                throw;
            }
        }

        public static void NewCoach(LegaGladio.Entities.Coach coach)
        {
            try
            {
                DataAccessLayer.Coach.NewCoach(coach);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while creating coaches");
                throw;
            }
        }

        public static void UpdateCoach(LegaGladio.Entities.Coach coach, int oldId)
        {
            try
            {
                DataAccessLayer.Coach.UpdateCoach(coach, oldId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while updating coaches");
                throw;
            }
        }

        public static void DeleteCoach(int id)
        {
            try
            {
                DataAccessLayer.Coach.DeleteCoach(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while deleting coaches");
                throw;
            }
        }
    }
}
