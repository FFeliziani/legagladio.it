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
                Logger.Error(ex, "Error while getting group - Id: [" + id + "]");
                throw;
            }
        }

        public static ICollection<LegaGladio.Entities.Group> ListGroup(LegaGladio.Entities.Series series)
        {
            try
            {
                return DataAccessLayer.Group.ListGroup(series);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while getting group by series - Series Id: [" + series.Id + "]");
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
                Logger.Error(ex, "Error while creating new Group - Group Data: " + (group != null ? "Group Name: [" + group.Name + "]" : "GROUP IS NULL!!!"));
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
                Logger.Error(ex, "Error while updating group - Group Data: " + (group != null ? "Group Name: [" + group.Name + "], oldId: [" + oldId + "]" : "GROUP IS NULL!!!"));
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
                Logger.Error(ex, "Error while adding group to series - Series Id: [" + seriesId + "], Group Id: [" + groupId + "]");
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
                Logger.Error(ex, "Error while removing group from series - Series Id: [" + seriesId + "], Group Id: [" + groupId + "]");
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
                Logger.Error(ex, "Error while deleting group - Id: [" + id + "]");
                throw;
            }
        }
    }
}
