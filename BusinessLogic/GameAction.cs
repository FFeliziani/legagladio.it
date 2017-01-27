using System;
using System.Collections.Generic;
using System.Linq;
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
                Logger.Error(ex, "Error while getting a game action - Id: [" + id + "]");
                throw;
            }
        }

        public static ICollection<LegaGladio.Entities.GameAction> ListGameAction(LegaGladio.Entities.Game game)
        {
            try
            {
                return DataAccessLayer.GameAction.ListGameAction(game);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing game actions - Game Id: [" + game.Id +"]");
                throw;
            }
        }

        public static void NewGameAction(LegaGladio.Entities.GameAction ga)
        {
            try
            {
                DataAccessLayer.GameAction.NewGameAction(ga);
                var p = Player.GetPlayer(ga.Player.Id);
                var a = Action.GetAction(ga.Action.Id);

                switch (a.Id)
                {
                    case 1: //TD
                        p.Td++;
                        break;
                    case 2: //CAS
                        p.Cas++;
                        break;
                    case 3: //INT
                        p.Inter++;
                        break;
                    case 4: //CP
                        p.Pass++;
                        break;
                    case 5: //MVP
                        p.Mvp++;
                        break;
                }

                p.Spp += a.Spp;

                Player.UpdatePlayer(p, p.Id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while creating a new game action - Game Action Data: " 
                    + (ga != null ? (ga.Player != null ? "Player Id: [" + ga.Player.Id + "] " : "PLAYER IS NULL!!! ") + (ga.Action != null ? "Action Id: [" + ga.Action.Id + "] " : "ACTION IS NULL!!!"): "GAME ACTION IS NULL!!!"));
                throw;
            }
        }

        public static void NewGameActionList(ICollection<LegaGladio.Entities.GameAction> gameActions)
        {
            try
            {
                var actions = gameActions as IList<LegaGladio.Entities.GameAction> ?? gameActions.ToList();
                if (actions.Any())
                {
                    var gaL = ListGameAction(actions[0].Game);
                    // TODO: FIND AN ACTUAL WAY TO DO THIS SHIT;
                    foreach (var ga in gaL)
                    {
                        DeleteGameAction(ga.Id); //don't even.
                    }
                    foreach (var ga in actions)
                    {
                        NewGameAction(ga);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while deleting and then recreating game actions.... there must be a better way");
                throw;
            }
        }

        public static void DeleteGameAction(Int32 id)
        {
            try
            {
                var ga = GetGameAction(id);
                var p = Player.GetPlayer(ga.Player.Id);
                var a = Action.GetAction(ga.Action.Id);

                switch (a.Id)
                {
                    case 1: //TD
                        p.Td--;
                        break;
                    case 2: //CAS
                        p.Cas--;
                        break;
                    case 3: //INT
                        p.Inter--;
                        break;
                    case 4: //CP
                        p.Pass--;
                        break;
                    case 5: //MVP
                        p.Mvp--;
                        break;
                }

                p.Spp -= a.Spp;

                Player.UpdatePlayer(p, p.Id);
                DataAccessLayer.GameAction.DeleteGameAction(ga.Id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while deleting a game action - Game Action Id: [" + id + "]");
                throw;
            }
        }
    }
}
