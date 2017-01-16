using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;

namespace LegaGladio.BusinessLogic
{
    public class Round
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static LegaGladio.Entities.Round getRound(Int32 id)
        {
            try
            {
                return DataAccessLayer.Round.getRound(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while getting round");
                throw ex;
            }
        }

        public static List<LegaGladio.Entities.Round> listRound(LegaGladio.Entities.Group group)
        {
            try
            {
                return DataAccessLayer.Round.listRound(group);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception while listing rounds for group");
                throw ex;
            }
        }

        public static void newRound(LegaGladio.Entities.Round round)
        {
            try
            {
                DataAccessLayer.Round.newRound(round);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while creating new Round");
                throw ex;
            }
        }

        public static void updateRound(LegaGladio.Entities.Round round, Int32 oldId)
        {
            try
            {
                DataAccessLayer.Round.updateRound(round, oldId);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while updating round");
                throw ex;
            }
        }

        public static void addRoundToGroup(Int32 roundId, Int32 groupId)
        {
            try
            {
                DataAccessLayer.Round.addRoundToGroup(roundId, groupId);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while adding round to series");
                throw ex;
            }
        }

        public static void removeRoundFromGroup(Int32 roundId, Int32 groupId)
        {
            try
            {
                DataAccessLayer.Round.removeRoundFromGroup(roundId, groupId);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while removing round from series");
                throw ex;
            }
        }

        public static void removeRound(Int32 id)
        {
            try
            {
                DataAccessLayer.Round.removeRound(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while deleting round");
                throw ex;
            }
        }
    }
}
