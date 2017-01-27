using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.LegaGladioDSTableAdapters;

namespace DataAccessLayer
{
    public static class GameAction
    {
        public static LegaGladio.Entities.GameAction GetGameAction(Int32 id)
        {
            var gata = new game_actionTableAdapter();
            var gadt = new LegaGladioDS.game_actionDataTable();
            var ga = new LegaGladio.Entities.GameAction();
            gata.FillById(gadt, id);
            if (gadt.Rows.Count != 1) throw new ArgumentException("Wrong number of GameActions returned");
            var gar = (LegaGladioDS.game_actionRow) gadt.Rows[0];
            ga.Game = Game.GetGameSimple(gar.gameID);
            ga.Action = Action.GetAction(gar.actionID);
            ga.Player = Player.GetPlayer(gar.playerID);
            ga.Id = gar.id;
            ga.Notes = gar.notes;
            return ga;
        }

        public static ICollection<LegaGladio.Entities.GameAction> ListGameAction(LegaGladio.Entities.Game game)
        {
            var gata = new game_actionTableAdapter();
            var gadt = new LegaGladioDS.game_actionDataTable();
            gata.FillByGameId(gadt, game.Id);
            //if (gadt.Rows.Count < 1) throw new ArgumentException("Wrong number of GameActions returned");
            var gaL = (from LegaGladioDS.game_actionRow gar in gadt.Rows
                select new LegaGladio.Entities.GameAction
                {
                    //Game = Game.GetGame(gar.gameID),
                    Action = Action.GetAction(gar.actionID),
                    Player = Player.GetPlayer(gar.playerID),
                    Id = gar.id,
                    Notes = gar.notes
                }).ToList();
            return gaL;
        }

        public static void NewGameAction(LegaGladio.Entities.GameAction ga)
        {
            var gata = new game_actionTableAdapter();

            gata.Insert(ga.Game.Id, ga.Action.Id, ga.Player.Id, ga.Notes);
        }

        public static void DeleteGameAction(Int32 id)
        {
            var gata = new game_actionTableAdapter();

            gata.Delete(id);
        }
    }
}
