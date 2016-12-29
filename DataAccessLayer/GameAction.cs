using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    class GameAction
    {
        public static LegaGladio.Entities.GameAction getGameAction(Int32 id)
        {
            LegaGladioDSTableAdapters.game_actionTableAdapter gata = null;
            LegaGladioDS.game_actionDataTable gadt = null;
            LegaGladio.Entities.GameAction ga = null;
            LegaGladioDS.game_actionRow gar = null;

            try
            {
                gata = new LegaGladioDSTableAdapters.game_actionTableAdapter();
                gadt = new LegaGladioDS.game_actionDataTable();
                ga = new LegaGladio.Entities.GameAction();
                gata.FillById(gadt, id);
                if (gadt.Rows.Count != 1)
                {
                    throw new ArgumentException("Wrong number of GameActions returned");
                }
                gar = (LegaGladioDS.game_actionRow)gadt.Rows[0];
                ga.Game = Game.getGame(gar.gameID);
                ga.Action = Action.getAction(gar.actionID);
                ga.Team = Team.getTeam(gar.teamID);
                ga.Player = Player.getPlayer(gar.playerID);
                ga.Id = gar.id;
                ga.Notes = gar.notes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                gata = null;
                gadt = null;
            }
            return ga;
        }

        public static List<LegaGladio.Entities.GameAction> getGameAction(LegaGladio.Entities.Game game)
        {
            LegaGladioDSTableAdapters.game_actionTableAdapter gata = null;
            LegaGladioDS.game_actionDataTable gadt = null;
            List<LegaGladio.Entities.GameAction> gaL = null;

            try
            {
                gata = new LegaGladioDSTableAdapters.game_actionTableAdapter();
                gadt = new LegaGladioDS.game_actionDataTable();
                gaL = new List<LegaGladio.Entities.GameAction>();
                gata.FillByGameId(gadt, game.Id);
                if (gadt.Rows.Count < 1)
                {
                    throw new ArgumentException("Wrong number of GameActions returned");
                }
                foreach (LegaGladioDS.game_actionRow gar in gadt.Rows)
                {
                    LegaGladio.Entities.GameAction ga = new LegaGladio.Entities.GameAction();
                    ga.Game = Game.getGame(gar.gameID);
                    ga.Action = Action.getAction(gar.actionID);
                    ga.Team = Team.getTeam(gar.teamID);
                    ga.Player = Player.getPlayer(gar.playerID);
                    ga.Id = gar.id;
                    ga.Notes = gar.notes;
                    gaL.Add(ga);
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                gata = null;
                gadt = null;
            }
            return gaL;
        }

        public static void newGameAction(LegaGladio.Entities.GameAction ga)
        {
            LegaGladioDSTableAdapters.game_actionTableAdapter gata = new LegaGladioDSTableAdapters.game_actionTableAdapter();

            gata.Insert(ga.Game.Id, ga.Action.Id, ga.Team.Id, ga.Player.Id, ga.Notes);
        }

        public static void updateGameAction(LegaGladio.Entities.GameAction ga, Int32 oldId)
        {
            LegaGladioDSTableAdapters.game_actionTableAdapter gata = new LegaGladioDSTableAdapters.game_actionTableAdapter();

            gata.Update(ga.Game.Id, ga.Action.Id, ga.Team.Id, ga.Player.Id, ga.Notes, oldId);
        }

        public static void deleteGameAction(Int32 id)
        {
            LegaGladioDSTableAdapters.game_actionTableAdapter gata = new LegaGladioDSTableAdapters.game_actionTableAdapter();

            gata.Delete(id);
        }
    }
}
