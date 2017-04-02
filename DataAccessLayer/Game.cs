using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.LegaGladioDSTableAdapters;

namespace DataAccessLayer
{
    public static class Game
    {
        public static LegaGladio.Entities.Game GetGame(int id)
        {
            var gdt = new LegaGladioDS.gameDataTable();
            var gta = new gameTableAdapter();
            gta.FillById(gdt, id);
            if(gdt.Rows.Count != 1) throw new Exception("Wrong number of rows returned while getting game");
            var gr = (LegaGladioDS.gameRow)gdt.Rows[0];
            var game = new LegaGladio.Entities.Game
            {
                Id = gr.id,
                CasGuest = gr.casGuest,
                CasHome = gr.casHome,
                EarningGuest = gr.earningGuest,
                EarningHome = gr.earningHome,
                Guest = Team.GetTeam(gr.guestID, true),
                Home = Team.GetTeam(gr.homeID, true),
                Notes = gr.notes,
                SpGuest = gr.spGuest,
                SpHome = gr.spHome,
                TdGuest = gr.tdGuest,
                TdHome = gr.tdHome,
                VarFfGuest = gr.varFFGuest,
                VarFfHome = gr.varFFHome,
                GameDate = gr.IsgameDateNull() ? null : (DateTime?)gr.gameDate
            };
            return game;
        }

        public static LegaGladio.Entities.Game GetGameSimple(Int32 id)
        {
            var gdt = new LegaGladioDS.gameDataTable();
            var gta = new gameTableAdapter();
            gta.FillById(gdt, id);
            if (gdt.Rows.Count != 1) throw new Exception("Wrong number of rows returned while getting game");
            var gr = (LegaGladioDS.gameRow)gdt.Rows[0];
            var game = new LegaGladio.Entities.Game
            {
                Id = gr.id,
                CasGuest = gr.casGuest,
                CasHome = gr.casHome,
                EarningGuest = gr.earningGuest,
                EarningHome = gr.earningHome,
                Notes = gr.notes,
                SpGuest = gr.spGuest,
                SpHome = gr.spHome,
                TdGuest = gr.tdGuest,
                TdHome = gr.tdHome,
                VarFfGuest = gr.varFFGuest,
                VarFfHome = gr.varFFHome,
                GameDate = gr.IsgameDateNull() ? null : (DateTime?)gr.gameDate
            };
            return game;
        }

        public static ICollection<LegaGladio.Entities.Game> ListGame()
        {
            var gdt = new LegaGladioDS.gameDataTable();
            var gta = new gameTableAdapter();
            gta.Fill(gdt);
            var gameList = (from LegaGladioDS.gameRow gr in gdt.Rows
                select new LegaGladio.Entities.Game
                {
                    Id = gr.id,
                    Home = Team.GetTeamSimple(gr.homeID),
                    Guest = Team.GetTeamSimple(gr.guestID),
                    TdHome = gr.tdHome,
                    TdGuest = gr.tdGuest,
                    CasHome = gr.casHome,
                    CasGuest = gr.casGuest,
                    SpHome = gr.spHome,
                    SpGuest = gr.spGuest,
                    EarningHome = gr.earningHome,
                    EarningGuest = gr.earningGuest,
                    VarFfHome = gr.varFFHome,
                    VarFfGuest = gr.varFFGuest,
                    GameDate = gr.IsgameDateNull() ? null : (DateTime?)gr.gameDate
                }).ToList();
            return gameList;
        }

        public static ICollection<LegaGladio.Entities.Game> ListGame(LegaGladio.Entities.Team team)
        {
            var gdt = new LegaGladioDS.gameDataTable();
            var gta = new gameTableAdapter();
            gta.FillByTeamId(gdt, team.Id);
            var gameList = (from LegaGladioDS.gameRow gr in gdt.Rows
                select new LegaGladio.Entities.Game
                {
                    Id = gr.id,
                    Home = Team.GetTeamSimple(gr.homeID),
                    Guest = Team.GetTeamSimple(gr.guestID),
                    TdHome = gr.tdHome,
                    TdGuest = gr.tdGuest,
                    CasHome = gr.casHome,
                    CasGuest = gr.casGuest,
                    SpHome = gr.spHome,
                    SpGuest = gr.spGuest,
                    EarningHome = gr.earningHome,
                    EarningGuest = gr.earningGuest,
                    VarFfHome = gr.varFFHome,
                    VarFfGuest = gr.varFFGuest,
                    GameDate = gr.IsgameDateNull() ? null : (DateTime?)gr.gameDate
                }).ToList();
            return gameList;
        }

        public static ICollection<LegaGladio.Entities.Game> ListGame(LegaGladio.Entities.Coach coach)
        {
            var gdt = new LegaGladioDS.gameDataTable();
            var gta = new gameTableAdapter();
            gta.FillByCoachId(gdt, coach.Id);
            var gameList = (from LegaGladioDS.gameRow gr in gdt.Rows
                select new LegaGladio.Entities.Game
                {
                    Id = gr.id,
                    Home = Team.GetTeamSimple(gr.homeID),
                    Guest = Team.GetTeamSimple(gr.guestID),
                    TdHome = gr.tdHome,
                    TdGuest = gr.tdGuest,
                    CasHome = gr.casHome,
                    CasGuest = gr.casGuest,
                    SpHome = gr.spHome,
                    SpGuest = gr.spGuest,
                    EarningHome = gr.earningHome,
                    EarningGuest = gr.earningGuest,
                    VarFfHome = gr.varFFHome,
                    VarFfGuest = gr.varFFGuest,
                    GameDate = gr.IsgameDateNull() ? null : (DateTime?)gr.gameDate
                }).ToList();
            return gameList;
        }

        public static ICollection<LegaGladio.Entities.Game> ListGame(LegaGladio.Entities.Round round)
        {
            var gta = new gameTableAdapter();
            var gdt = new LegaGladioDS.gameDataTable();

            gta.FillByRoundId(gdt, round.Id);

            var gL = (from LegaGladioDS.gameRow gr in gdt.Rows
                select new LegaGladio.Entities.Game
                {
                    Id = gr.id,
                    Home = Team.GetTeamSimple(gr.homeID),
                    Guest = Team.GetTeamSimple(gr.guestID),
                    TdHome = gr.tdHome,
                    TdGuest = gr.tdGuest,
                    CasHome = gr.casHome,
                    CasGuest = gr.casGuest,
                    SpHome = gr.spHome,
                    SpGuest = gr.spGuest,
                    EarningHome = gr.earningHome,
                    EarningGuest = gr.earningGuest,
                    VarFfHome = gr.varFFHome,
                    VarFfGuest = gr.varFFGuest,
                    GameDate = gr.IsgameDateNull() ? null : (DateTime?)gr.gameDate
                }).ToList();

            return gL;
        }

        public static ICollection<LegaGladio.Entities.Game> ListGame(LegaGladio.Entities.Group group)
        {
            var gta = new gameTableAdapter();
            var gdt = new LegaGladioDS.gameDataTable();

            gta.FillByGroupId(gdt, group.Id);

            var gL = (from LegaGladioDS.gameRow gr in gdt.Rows
                      select new LegaGladio.Entities.Game
                      {
                          Id = gr.id,
                          Home = Team.GetTeamSimple(gr.homeID),
                          Guest = Team.GetTeamSimple(gr.guestID),
                          TdHome = gr.tdHome,
                          TdGuest = gr.tdGuest,
                          CasHome = gr.casHome,
                          CasGuest = gr.casGuest,
                          SpHome = gr.spHome,
                          SpGuest = gr.spGuest,
                          EarningHome = gr.earningHome,
                          EarningGuest = gr.earningGuest,
                          VarFfHome = gr.varFFHome,
                          VarFfGuest = gr.varFFGuest,
                          GameDate = gr.IsgameDateNull() ? null : (DateTime?)gr.gameDate
                      }).ToList();

            return gL;
        }

        public static ICollection<LegaGladio.Entities.Game> ListGame(LegaGladio.Entities.Series series)
        {
            var gta = new gameTableAdapter();
            var gdt = new LegaGladioDS.gameDataTable();

            gta.FillBySeriesId(gdt, series.Id);

            var gL = (from LegaGladioDS.gameRow gr in gdt.Rows
                      select new LegaGladio.Entities.Game
                      {
                          Id = gr.id,
                          Home = Team.GetTeamSimple(gr.homeID),
                          Guest = Team.GetTeamSimple(gr.guestID),
                          TdHome = gr.tdHome,
                          TdGuest = gr.tdGuest,
                          CasHome = gr.casHome,
                          CasGuest = gr.casGuest,
                          SpHome = gr.spHome,
                          SpGuest = gr.spGuest,
                          EarningHome = gr.earningHome,
                          EarningGuest = gr.earningGuest,
                          VarFfHome = gr.varFFHome,
                          VarFfGuest = gr.varFFGuest,
                          GameDate = gr.IsgameDateNull() ? null : (DateTime?)gr.gameDate
                      }).ToList();

            return gL;
        }

        public static void AddGametoRound(Int32 gameId, Int32 roundId)
        {
            var gta = new gameTableAdapter();

            gta.AddGameToRound(gameId, roundId);
        }

        public static void RemoveGameFromRound(Int32 gameId, Int32 roundId)
        {
            var gta = new gameTableAdapter();

            gta.RemoveGameFromRound(gameId, roundId);
        }

        public static Int32 NewGame(LegaGladio.Entities.Game game)
        {
            var gta = new gameTableAdapter();

            var ret = gta.InsertGame(game.Home.Id, game.Guest.Id, game.TdHome, game.TdGuest, game.CasHome, game.CasGuest, game.SpHome, game.SpGuest, game.EarningHome, game.EarningGuest, game.VarFfHome, game.VarFfGuest, game.GameDate, game.Notes);

            return Convert.ToInt32(ret);
        }

        public static void UpdateGame(LegaGladio.Entities.Game game, Int32 oldId)
        {
            var gta = new gameTableAdapter();

            var oldGame = GetGame(oldId);

            game.Home = oldGame.Home;
            game.Guest = oldGame.Guest;

            gta.UpdateGame(game.Home.Id, game.Guest.Id, game.TdHome, game.TdGuest, game.CasHome, game.CasGuest, game.SpHome, game.SpGuest, game.EarningHome, game.EarningGuest, game.VarFfHome, game.VarFfGuest, game.GameDate, game.Notes,  oldId);
        }

        public static void DeleteGame(Int32 id)
        {
            var gta = new gameTableAdapter();

            gta.DeleteGame(id);
        }
    }
}
