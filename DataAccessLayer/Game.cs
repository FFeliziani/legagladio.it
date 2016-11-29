﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class Game
    {
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
    }
}