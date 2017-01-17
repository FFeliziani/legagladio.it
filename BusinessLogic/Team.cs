using System;
using System.Collections.Generic;
using NLog;

namespace BusinessLogic
{
    public static class Team
    {
        private readonly static Logger Logger = LogManager.GetCurrentClassLogger();

        public static int Count()
        {
            try
            {
                return DataAccessLayer.Team.CountTeam();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while counting teams");
                throw;
            }
        }

        public static List<LegaGladio.Entities.Team> List()
        {
            try
            {
                return DataAccessLayer.Team.ListTeam();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing teams");
                throw;
            }
        }

        public static List<LegaGladio.Entities.Team> List(int coachId)
        {
            try
            {
                return DataAccessLayer.Team.ListTeam(coachId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing teams for coach");
                throw;
            }
        }

        public static List<LegaGladio.Entities.Team> List(Boolean active)
        {
            try
            {
                return DataAccessLayer.Team.ListTeam(active);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing active teams");
                throw;
            }
        }

        public static LegaGladio.Entities.Team Get(int id)
        {
            try
            {
                return DataAccessLayer.Team.GetTeam(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while getting teams");
                throw;
            }
        }

        public static LegaGladio.Entities.Team Get(Int32 id, Boolean active)
        {
            try
            {
                return DataAccessLayer.Team.GetTeam(id, active);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while getting teams");
                throw;
            }
        }

        public static void NewTeam(LegaGladio.Entities.Team team)
        {
            try
            {
                DataAccessLayer.Team.NewTeam(team);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while creating teams");
                throw;
            }
        }

        public static void UpdateTeam(LegaGladio.Entities.Team team, int oldId)
        {
            try
            {
                DataAccessLayer.Team.UpdateTeam(team, oldId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while updating teams");
                throw;
            }
        }

        /*public static Boolean DeleteTeam(int id)
        {
            try
            {
                return DataAccessLayer.Team.DeleteTeam(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while deleting teams");
                throw;
            }
        }*/
    }
}
