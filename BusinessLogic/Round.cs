using System;
using System.Collections.Generic;
using NLog;

namespace BusinessLogic
{
    public static class Round
    {
        private readonly static Logger Logger = LogManager.GetCurrentClassLogger();

        public static LegaGladio.Entities.Round GetRound(Int32 id)
        {
            try
            {
                return DataAccessLayer.Round.GetRound(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while getting round - Id: [" + id + "]");
                throw;
            }
        }

        public static ICollection<LegaGladio.Entities.Round> ListRound(LegaGladio.Entities.Group group)
        {
            try
            {
                return DataAccessLayer.Round.ListRound(group);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Exception while listing rounds for group - Group Id: [" + group.Id + "]");
                throw;
            }
        }

        public static ICollection<LegaGladio.Entities.Round> ListRoundDetailed(LegaGladio.Entities.Group group)
        {
            try
            {
                return DataAccessLayer.Round.ListRoundDetailed(group);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Exception while listing rounds for group - Group Id: [" + group.Id + "]");
                throw;
            }
        }

        public static void NewRound(LegaGladio.Entities.Round round)
        {
            try
            {
                DataAccessLayer.Round.NewRound(round);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while creating new Round - Round Data: " + (round != null ? "Round Name: ["  + round.Name + "]" : "ROUND IS NULL!!!"));
                throw;
            }
        }

        public static void UpdateRound(LegaGladio.Entities.Round round, Int32 oldId)
        {
            try
            {
                DataAccessLayer.Round.UpdateRound(round, oldId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while updating round - Round Data: oldId: [" + oldId + "], " + (round != null ? "Round Name: [" + round.Name + "]" : "ROUND IS NULL!!!"));
                throw;
            }
        }

        public static void AddRoundToGroup(Int32 roundId, Int32 groupId)
        {
            try
            {
                DataAccessLayer.Round.AddRoundToGroup(roundId, groupId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while adding round to group - Round Id: [" + roundId + "], Group Id: [" + groupId + "]");
                throw;
            }
        }

        public static void RemoveRoundFromGroup(Int32 roundId, Int32 groupId)
        {
            try
            {
                DataAccessLayer.Round.RemoveRoundFromGroup(roundId, groupId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while removing round from group - Round Id: [" + roundId + "], Group Id: [" + groupId + "]");
                throw;
            }
        }

        public static void RemoveRound(Int32 id)
        {
            try
            {
                DataAccessLayer.Round.RemoveRound(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while deleting round - Id: [" + id + "]");
                throw;
            }
        }
    }
}
