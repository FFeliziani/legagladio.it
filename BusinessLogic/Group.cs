using System;
using System.Collections.Generic;
using NLog;

namespace BusinessLogic
{
    public static class Group
    {
        private readonly static Logger Logger = LogManager.GetCurrentClassLogger();

        public static LegaGladio.Entities.Group GetGroup(Int32 id)
        {
            try
            {
                return DataAccessLayer.Group.GetGroup(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while getting group");
                throw;
            }
        }

        public static IEnumerable<LegaGladio.Entities.Group> ListGroup(LegaGladio.Entities.Series series)
        {
            try
            {
                return DataAccessLayer.Group.ListGroup(series);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while getting group");
                throw;
            }
        }

        public static void NewGroup(LegaGladio.Entities.Group group)
        {
            try
            {
                DataAccessLayer.Group.NewGroup(group);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while creating new Group");
                throw;
            }
        }

        public static void UpdateGroup(LegaGladio.Entities.Group group, Int32 oldId)
        {
            try
            {
                DataAccessLayer.Group.UpdateGroup(group, oldId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while updating group");
                throw;
            }
        }

        public static void AddGroupToSeries(Int32 groupId, Int32 seriesId)
        {
            try
            {
                DataAccessLayer.Group.AddGroupToSeries(groupId, seriesId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while adding group to series");
                throw;
            }
        }

        public static void RemoveGroupFromSeries(Int32 groupId, Int32 seriesId)
        {
            try
            {
                DataAccessLayer.Group.RemoveGroupFromSeries(groupId, seriesId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while removing group from series");
                throw;
            }
        }

        public static void RemoveGroup(Int32 id)
        {
            try
            {
                DataAccessLayer.Group.RemoveGroup(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while deleting group");
                throw;
            }
        }
    }
}
