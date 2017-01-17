using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.LegaGladioDSTableAdapters;

namespace DataAccessLayer
{
    class GameAction
    {
        public static LegaGladio.Entities.GameAction GetGameAction(Int32 id)
        {
            var gata = new game_actionTableAdapter();
            var gadt = new LegaGladioDS.game_actionDataTable();
            var ga = new LegaGladio.Entities.GameAction();
            gata.FillById(gadt, id);
            if (gadt.Rows.Count != 1) throw new ArgumentException("Wrong number of GameActions returned");
            var gar = (LegaGladioDS.game_actionRow) gadt.Rows[0];
            ga.Game = Game.GetGame(gar.gameID);
            ga.Action = Action.GetAction(gar.actionID);
            ga.Team = Team.GetTeam(gar.teamID);
            ga.Player = Player.GetPlayer(gar.playerID);
            ga.Id = gar.id;
            ga.Notes = gar.notes;
            return ga;
        }

        public static IEnumerable<LegaGladio.Entities.GameAction> GetGameAction(LegaGladio.Entities.Game game)
        {
            var gata = new game_actionTableAdapter();
            var gadt = new LegaGladioDS.game_actionDataTable();
            gata.FillByGameId(gadt, game.Id);
            if (gadt.Rows.Count < 1) throw new ArgumentException("Wrong number of GameActions returned");
            var gaL = (from LegaGladioDS.game_actionRow gar in gadt.Rows
                select new LegaGladio.Entities.GameAction
                {
                    Game = Game.GetGame(gar.gameID),
                    Action = Action.GetAction(gar.actionID),
                    Team = Team.GetTeam(gar.teamID),
                    Player = Player.GetPlayer(gar.playerID),
                    Id = gar.id,
                    Notes = gar.notes
                }).ToList();
            return gaL;
        }

        public static void NewGameAction(LegaGladio.Entities.GameAction ga)
        {
            var gata = new game_actionTableAdapter();

            gata.Insert(ga.Game.Id, ga.Action.Id, ga.Team.Id, ga.Player.Id, ga.Notes);

            var p = Player.GetPlayer(ga.Player.Id);
            var a = Action.GetAction(ga.Action.Id);

            p.Spp += a.Spp;

            Player.UpdatePlayer(p, p.Id);
        }

        public static void UpdateGameAction(LegaGladio.Entities.GameAction ga, Int32 oldId)
        {
            var gata = new game_actionTableAdapter();

            gata.Update(ga.Game.Id, ga.Action.Id, ga.Team.Id, ga.Player.Id, ga.Notes, oldId);
        }

        public static void DeleteGameAction(Int32 id)
        {
            var gata = new game_actionTableAdapter();

            gata.Delete(id);
        }
    }
}
