using System;
using System.Collections.Generic;
using NLog;

namespace BusinessLogic
{
    public static class GameAction
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static LegaGladio.Entities.GameAction GetGameAction(Int32 id)
        {
            try
            {
                return DataAccessLayer.GameAction.GetGameAction(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while getting a game action");
                throw;
            }
        }

        public static IEnumerable<LegaGladio.Entities.GameAction> ListGameAction(LegaGladio.Entities.Game game)
        {
            try
            {
                return DataAccessLayer.GameAction.ListGameAction(game);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing game actions");
                throw;
            }
        }

        public static void NewGameAction(LegaGladio.Entities.GameAction ga)
        {
            try
            {
                DataAccessLayer.GameAction.NewGameAction(ga);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while creating a new game action");
                throw;
            }
        }

        public static void UpdateGameAction(LegaGladio.Entities.GameAction ga, Int32 oldId)
        {
            try
            {
                DataAccessLayer.GameAction.UpdateGameAction(ga, oldId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while updating a game action");
                throw;
            }
        }

        public static void DeleteGameAction(Int32 id)
        {
            try
            {
                DataAccessLayer.GameAction.DeleteGameAction(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error whule deleting a game action");
                throw;
            }
        }
    }
}
