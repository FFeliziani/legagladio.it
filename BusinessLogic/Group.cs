using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;

namespace LegaGladio.BusinessLogic
{
    public class Group
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static LegaGladio.Entities.Group getGroup(Int32 id)
        {
            try
            {
                return DataAccessLayer.Group.getGroup(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while getting group");
                throw ex;
            }
        }

        public static List<LegaGladio.Entities.Group> listGroup(LegaGladio.Entities.Series series)
        {
            try
            {
                return DataAccessLayer.Group.listGroup(series);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while getting group");
                throw ex;
            }
        }

        public static void newGroup(LegaGladio.Entities.Group group)
        {
            try
            {
                DataAccessLayer.Group.newGroup(group);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while creating new Group");
                throw ex;
            }
        }

        public static void updateGroup(LegaGladio.Entities.Group group, Int32 oldId)
        {
            try
            {
                DataAccessLayer.Group.updateGroup(group, oldId);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while updating group");
                throw ex;
            }
        }

        public static void addGroupToSeries(Int32 groupId, Int32 seriesId)
        {
            try
            {
                DataAccessLayer.Group.addGroupToSeries(groupId, seriesId);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while adding group to series");
                throw ex;
            }
        }

        public static void removeGroupFromSeries(Int32 groupId, Int32 seriesId)
        {
            try
            {
                DataAccessLayer.Group.removeGroupFromSeries(groupId, seriesId);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while removing group from series");
                throw ex;
            }
        }

        public static void removeGroup(Int32 id)
        {
            try
            {
                DataAccessLayer.Group.removeGroup(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while deleting group");
                throw ex;
            }
        }
    }
}
