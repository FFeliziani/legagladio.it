using System;
using System.Collections.Generic;
using NLog;

namespace BusinessLogic
{
    public static class Game
    {
        private readonly static Logger Logger = LogManager.GetCurrentClassLogger();

        public static LegaGladio.Entities.Game Get(int id) 
        {
            try
            {
                return DataAccessLayer.Game.GetGame(id);
            }
            catch(Exception ex)
            {
                Logger.Error(ex, "Error while getting games");
                throw;
            }
        }
        public static IEnumerable<LegaGladio.Entities.Game> ListGame()
        {
            try
            {
                return DataAccessLayer.Game.ListGame();
            }
            catch(Exception ex)
            {
                Logger.Error(ex, "Error while listing games");
                throw;
            }
        }
        public static IEnumerable<LegaGladio.Entities.Game> ListGame(LegaGladio.Entities.Team team)
        {
            try
            {
                return DataAccessLayer.Game.ListGame(team);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing games for team");
                throw;
            }
        }
        public static IEnumerable<LegaGladio.Entities.Game> ListGame(LegaGladio.Entities.Coach coach)
        {
            try
            {
                return DataAccessLayer.Game.ListGame(coach);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing games for coach");
                throw;
            }
        }

        public static IEnumerable<LegaGladio.Entities.Game> ListGame(LegaGladio.Entities.Round round)
        {
            try
            {
                return DataAccessLayer.Game.ListGame(round);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing games for round");
                throw;
            }
        }

        public static void NewGame(LegaGladio.Entities.Game game)
        {
            try
            {
                DataAccessLayer.Game.NewGame(game);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while creating a new Game");
                throw;
            }
        }

        public static void UpdateGame(LegaGladio.Entities.Game game, Int32 oldId)
        {
            try
            {
                DataAccessLayer.Game.UpdateGame(game, oldId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while updating Game");
                throw;
            }
        }

        public static void RemoveGame(Int32 id)
        {
            try
            {
                DataAccessLayer.Game.DeleteGame(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while deleting game");
                throw;
            }
        }
    }
}
