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
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while getting games - Id: [" + id + "]");
                throw;
            }
        }
        public static ICollection<LegaGladio.Entities.Game> ListGame()
        {
            try
            {
                return DataAccessLayer.Game.ListGame();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing games");
                throw;
            }
        }
        public static ICollection<LegaGladio.Entities.Game> ListGame(LegaGladio.Entities.Team team)
        {
            try
            {
                return DataAccessLayer.Game.ListGame(team);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing games for team - Team Id: [" + team.Id + "]");
                throw;
            }
        }
        public static ICollection<LegaGladio.Entities.Game> ListGame(LegaGladio.Entities.Coach coach)
        {
            try
            {
                return DataAccessLayer.Game.ListGame(coach);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing games for coach - Coach Id: [" + coach.Id + "]");
                throw;
            }
        }

        public static ICollection<LegaGladio.Entities.Game> ListGame(LegaGladio.Entities.Round round)
        {
            try
            {
                return DataAccessLayer.Game.ListGame(round);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing games for round - Round Id: [" + round.Id + "]");
                throw;
            }
        }

        public static ICollection<LegaGladio.Entities.Game> ListGame(LegaGladio.Entities.Group group)
        {
            try
            {
                return DataAccessLayer.Game.ListGame(group);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing games for round - Round Id: [" + group.Id + "]");
                throw;
            }
        }

        public static ICollection<LegaGladio.Entities.Game> ListGame(LegaGladio.Entities.Series series)
        {
            try
            {
                return DataAccessLayer.Game.ListGame(series);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing games for round - Round Id: [" + series.Id + "]");
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
                Logger.Error(ex, "Error while creating a new Game - Game Data: " 
                    + (game != null ? (game.Home != null ? "Home Team Id: [" + game.Home.Id + "], " : "HOME TEAM IS NULL!!! ") 
                    + (game.Guest != null ? "Guest Team Id: [" + game.Guest.Id + "], " : "GUEST TEAM IS NULL!!!") : "GAME IS NULL!!!! ")
                    + "TD: [" + (game?.TdHome ?? 0) + "|" + (game?.TdGuest ?? 0) + "], "
                    + "CAS: [" + (game?.CasHome ?? 0) + "|" + (game?.CasGuest ?? 0) + "], "
                    + "SPETT: [" + (game?.SpHome ?? 0) + "|" + (game?.SpGuest ?? 0) + "], "
                    + "EARNINGS: [" + (game?.EarningHome ?? 0) + "|" + (game?.EarningGuest ?? 0) + "], "
                    + " VAR FF: [" + (game?.VarFfHome ?? 0) + "|" + (game?.VarFfGuest ?? 0) + "]"
                    );
                throw;
            }
        }

        public static void UpdateGame(LegaGladio.Entities.Game game, Int32 oldId)
        {
            try
            {
                DataAccessLayer.Game.UpdateGame(game, oldId);
                /*var h = Team.GetTeam(game.Home.Id);
                var g = Team.GetTeam(game.Guest.Id);

                h.Treasury = Team.CalculateTreasury(h.Id);
                h.FanFactor = Team.CalculateFanFactor(h.Id);
                g.Treasury = Team.CalculateTreasury(g.Id);
                g.FanFactor = Team.CalculateFanFactor(g.Id);

                Team.UpdateTeam(h, h.Id);
                Team.UpdateTeam(g, g.Id);*/
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while updating Game - Game Data: "
                    + (game != null ? "Old Id: [" + oldId +" ], " 
                    + (game.Home != null ? "Home Team Id: [" + game.Home.Id + "], " : "HOME TEAM IS NULL!!! ")
                    + (game.Guest != null ? "Guest Team Id: [" + game.Guest.Id + "], " : "GUEST TEAM IS NULL!!!") : "GAME IS NULL!!!! ")
                    + "TD: [" + (game?.TdHome ?? 0) + "|" + (game?.TdGuest ?? 0) + "], "
                    + "CAS: [" + (game?.CasHome ?? 0) + "|" + (game?.CasGuest ?? 0) + "], "
                    + "SPETT: [" + (game?.SpHome ?? 0) + "|" + (game?.SpGuest ?? 0) + "], "
                    + "EARNINGS: [" + (game?.EarningHome ?? 0) + "|" + (game?.EarningGuest ?? 0) + "], "
                    + " VAR FF: [" + (game?.VarFfHome ?? 0) + "|" + (game?.VarFfGuest ?? 0) + "]"
                    );
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
                Logger.Error(ex, "Error while deleting game - Id: [" + id + "]");
                throw;
            }
        }
    }
}
