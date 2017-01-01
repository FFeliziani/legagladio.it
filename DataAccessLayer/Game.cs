using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class Game
    {
        public static LegaGladio.Entities.Game getGame(int id)
        {
            LegaGladio.Entities.Game game = null;
            LegaGladioDS.gameDataTable gtd = null;
            LegaGladioDSTableAdapters.gameTableAdapter gta = null;
            LegaGladioDS.gameRow gameRow = null;
            try
            {
                game = new LegaGladio.Entities.Game();
                gtd = new LegaGladioDS.gameDataTable();
                gta = new LegaGladioDSTableAdapters.gameTableAdapter();
                gta.FillById(gtd, id);
                gameRow = (LegaGladioDS.gameRow)gtd.Rows[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }
            gta = null;
            gtd = null;
            return game;
        }

        public static List<LegaGladio.Entities.Game> listGame()
        {
            LegaGladioDS.gameDataTable gdt = new LegaGladioDS.gameDataTable();
            LegaGladioDSTableAdapters.gameTableAdapter gta = new LegaGladioDSTableAdapters.gameTableAdapter();
            try
            {
                gta.Fill(gdt);
            }
            catch (Exception ex)
            {
                gdt.GetErrors();
                throw ex;
            }
            List<LegaGladio.Entities.Game> gameList = new List<LegaGladio.Entities.Game>();
            foreach (LegaGladioDS.gameRow gr in gdt.Rows)
            {
                LegaGladio.Entities.Game game = new LegaGladio.Entities.Game();
                game.Id = gr.id;
                game.Home = Team.getTeam(gr.homeID);
                game.Guest = Team.getTeam(gr.guestID);
                game.TdHome = gr.tdHome;
                game.TdGuest = gr.tdGuest;
                game.CasHome = gr.casHome;
                game.CasGuest = gr.casGuest;
                game.SpHome = gr.spHome;
                game.SpGuest = gr.spGuest;
                game.EarningHome = gr.earningHome;
                game.EarningGuest = gr.earningGuest;
                game.VarFFHome = gr.varFFHome;
                game.VarFFGuest = gr.varFFGuest;
                gameList.Add(game);
            }
            gta = null;
            gdt = null;
            return gameList;
        }

        public static List<LegaGladio.Entities.Game> listGame(LegaGladio.Entities.Team team)
        {
            LegaGladioDS.gameDataTable gdt = new LegaGladioDS.gameDataTable();
            LegaGladioDSTableAdapters.gameTableAdapter gta = new LegaGladioDSTableAdapters.gameTableAdapter();
            try
            {
                gta.FillByTeamId(gdt, team.Id);
            }
            catch (Exception ex)
            {
                gdt.GetErrors();
                throw ex;
            }
            List<LegaGladio.Entities.Game> gameList = new List<LegaGladio.Entities.Game>();
            foreach (LegaGladioDS.gameRow gr in gdt.Rows)
            {
                LegaGladio.Entities.Game game = new LegaGladio.Entities.Game();
                game.Id = gr.id;
                game.Home = Team.getTeam(gr.homeID);
                game.Guest = Team.getTeam(gr.guestID);
                game.TdHome = gr.tdHome;
                game.TdGuest = gr.tdGuest;
                game.CasHome = gr.casHome;
                game.CasGuest = gr.casGuest;
                game.SpHome = gr.spHome;
                game.SpGuest = gr.spGuest;
                game.EarningHome = gr.earningHome;
                game.EarningGuest = gr.earningGuest;
                game.VarFFHome = gr.varFFHome;
                game.VarFFGuest = gr.varFFGuest;
                gameList.Add(game);
            }
            gta = null;
            gdt = null;
            return gameList;
        }

        public static List<LegaGladio.Entities.Game> listGame(LegaGladio.Entities.Coach coach)
        {
            LegaGladioDS.gameDataTable gdt = new LegaGladioDS.gameDataTable();
            LegaGladioDSTableAdapters.gameTableAdapter gta = new LegaGladioDSTableAdapters.gameTableAdapter();
            try
            {
                gta.FillByCoachId(gdt, coach.Id);
            }
            catch (Exception ex)
            {
                gdt.GetErrors();
                throw ex;
            }
            List<LegaGladio.Entities.Game> gameList = new List<LegaGladio.Entities.Game>();
            foreach (LegaGladioDS.gameRow gr in gdt.Rows)
            {
                LegaGladio.Entities.Game game = new LegaGladio.Entities.Game();
                game.Id = gr.id;
                game.Home = Team.getTeam(gr.homeID);
                game.Guest = Team.getTeam(gr.guestID);
                game.TdHome = gr.tdHome;
                game.TdGuest = gr.tdGuest;
                game.CasHome = gr.casHome;
                game.CasGuest = gr.casGuest;
                game.SpHome = gr.spHome;
                game.SpGuest = gr.spGuest;
                game.EarningHome = gr.earningHome;
                game.EarningGuest = gr.earningGuest;
                game.VarFFHome = gr.varFFHome;
                game.VarFFGuest = gr.varFFGuest;
                gameList.Add(game);
            }
            gta = null;
            gdt = null;
            return gameList;
        }

        public static List<LegaGladio.Entities.Game> listGame(LegaGladio.Entities.Round round)
        {
            LegaGladioDSTableAdapters.gameTableAdapter gta = null;
            LegaGladioDS.gameDataTable gdt = null;
            List<LegaGladio.Entities.Game> gL = null;

            try
            {
                gta = new LegaGladioDSTableAdapters.gameTableAdapter();
                gdt = new LegaGladioDS.gameDataTable();
                gL = new List<LegaGladio.Entities.Game>();

                gta.FillByRoundId(gdt, round.Id);

                foreach (LegaGladioDS.gameRow gr in gdt.Rows)
                {
                    LegaGladio.Entities.Game game = new LegaGladio.Entities.Game();
                    game.Id = gr.id;
                    game.Home = Team.getTeam(gr.homeID);
                    game.Guest = Team.getTeam(gr.guestID);
                    game.TdHome = gr.tdHome;
                    game.TdGuest = gr.tdGuest;
                    game.CasHome = gr.casHome;
                    game.CasGuest = gr.casGuest;
                    game.SpHome = gr.spHome;
                    game.SpGuest = gr.spGuest;
                    game.EarningHome = gr.earningHome;
                    game.EarningGuest = gr.earningGuest;
                    game.VarFFHome = gr.varFFHome;
                    game.VarFFGuest = gr.varFFGuest;
                    gL.Add(game);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                gta = null;
                gdt = null;
            }

            return gL;
        }

        public static void addGametoRound(Int32 gameId, Int32 roundId)
        {
            LegaGladioDSTableAdapters.gameTableAdapter gta = new LegaGladioDSTableAdapters.gameTableAdapter();

            gta.AddGameToRound(roundId, gameId);
        }

        public static void removeGameFromRound(Int32 gameId, Int32 roundId)
        {
            LegaGladioDSTableAdapters.gameTableAdapter gta = new LegaGladioDSTableAdapters.gameTableAdapter();

            gta.RemoveGameFromRound(gameId, roundId);
        }

        public static void newGame(LegaGladio.Entities.Game game)
        {
            LegaGladioDSTableAdapters.gameTableAdapter gta = new LegaGladioDSTableAdapters.gameTableAdapter();

            gta.Insert(game.Home.Id, game.Guest.Id, game.TdHome, game.TdGuest, game.CasHome, game.CasGuest, game.SpHome, game.SpGuest, game.EarningHome, game.EarningGuest, game.VarFFHome, game.VarFFGuest, game.Notes);
        }

        public static void updateGame(LegaGladio.Entities.Game game, Int32 oldId)
        {
            LegaGladioDSTableAdapters.gameTableAdapter gta = new LegaGladioDSTableAdapters.gameTableAdapter();

            gta.Update(game.Home.Id, game.Guest.Id, game.TdHome, game.TdGuest, game.CasHome, game.CasGuest, game.SpHome, game.SpGuest, game.EarningHome, game.EarningGuest, game.VarFFHome, game.VarFFGuest, game.Notes, oldId);
        }

        public static void deleteGame(Int32 id)
        {
            LegaGladioDSTableAdapters.gameTableAdapter gta = new LegaGladioDSTableAdapters.gameTableAdapter();

            gta.Delete(id);
        }
    }
}
