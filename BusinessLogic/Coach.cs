using System;
using System.Collections.Generic;
using NLog;

namespace BusinessLogic
{
    public static class Coach
    {
        private readonly static Logger Logger = LogManager.GetCurrentClassLogger();

        /*public static int CountTeam()
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
                Logger.Error(ex, "Error while listing coaches - Active was: [" + active + "]");
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

        public static LegaGladio.Entities.Coach Get(Int32 id)
        {
            try
            {
                return DataAccessLayer.Coach.GetCoach(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while getting coaches - Id: [" + id + "]");
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
                Logger.Error(ex, "Error while creating coaches - Coach Data: " + (coach != null ? "Coach Name: [" + coach.Name + "], Coach Value: [" + coach.Value + "], Coach Naf Id: [" + coach.NafId + "], Coach Naf Name: [" + coach.NafNick + "], Coach is active? [" + coach.Active + "]" : "COACH IS NULL!!!"));
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
                Logger.Error(ex, "Error while updating coaches - Coach Data: " + (coach != null ? "Coach Id: [" + oldId + "], Coach Name: [" + coach.Name + "], Coach Value: [" + coach.Value + "], Coach Naf Id: [" + coach.NafId + "], Coach Naf Name: [" + coach.NafNick + "], Coach is active? [" + coach.Active + "]" : "COACH IS NULL!!!"));
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
                Logger.Error(ex, "Error while deleting coaches - Id: [" + id + "]");
                throw;
            }
        }
    }
}
