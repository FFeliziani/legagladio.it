using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace LegaGladio.BusinessLogic
{
    public class Team
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static int count()
        {
            try
            {
                return DataAccessLayer.Team.countTeam();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while counting teams");
                throw ex;
            }
        }

        public static List<LegaGladio.Entities.Team> list()
        {
            try
            {
                return DataAccessLayer.Team.listTeam();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while listing teams");
                throw ex;
            }
        }

        public static List<LegaGladio.Entities.Team> list(int coachID)
        {
            try
            {
                return DataAccessLayer.Team.listTeam(coachID);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while listing teams for coach");
                throw ex;
            }
        }

        public static List<LegaGladio.Entities.Team> list(Boolean active)
        {
            try
            {
                return DataAccessLayer.Team.listTeam(active);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while listing active teams");
                throw ex;
            }
        }

        public static LegaGladio.Entities.Team get(int id)
        {
            try
            {
                return DataAccessLayer.Team.getTeam(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while getting teams");
                throw ex;
            }
        }

        public static Boolean newTeam(LegaGladio.Entities.Team team)
        {
            try
            {
                return DataAccessLayer.Team.newTeam(team);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while creating teams");
                throw ex;
            }
        }

        public static Boolean updateTeam(LegaGladio.Entities.Team team, int oldID)
        {
            try
            {
                return DataAccessLayer.Team.updateTeam(team, oldID);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while updating teams");
                throw ex;
            }
        }

        public static Boolean deleteTeam(int id)
        {
            try
            {
                return DataAccessLayer.Team.deleteTeam(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while deleting teams");
                throw ex;
            }
        }
    }
}
