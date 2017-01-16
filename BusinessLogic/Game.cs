﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;

namespace LegaGladio.BusinessLogic
{
    public class Game
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static LegaGladio.Entities.Game get(int id) 
        {
            try
            {
                return DataAccessLayer.Game.getGame(id);
            }
            catch(Exception ex)
            {
                logger.Error(ex, "Error while getting games");
                throw ex;
            }
        }
        public static List<LegaGladio.Entities.Game> listGame()
        {
            try
            {
                return DataAccessLayer.Game.listGame();
            }
            catch(Exception ex)
            {
                logger.Error(ex, "Error while listing games");
                throw ex;
            }
        }
        public static List<LegaGladio.Entities.Game> listGame(LegaGladio.Entities.Team team)
        {
            try
            {
                return DataAccessLayer.Game.listGame(team);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while listing games for team");
                throw ex;
            }
        }
        public static List<LegaGladio.Entities.Game> listGame(LegaGladio.Entities.Coach coach)
        {
            try
            {
                return DataAccessLayer.Game.listGame(coach);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while listing games for coach");
                throw ex;
            }
        }

        public static List<LegaGladio.Entities.Game> listGame(LegaGladio.Entities.Round round)
        {
            try
            {
                return DataAccessLayer.Game.listGame(round);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while listing games for round");
                throw ex;
            }
        }

        public static void newGame(LegaGladio.Entities.Game game)
        {
            try
            {
                DataAccessLayer.Game.newGame(game);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while creating a new Game");
                throw ex;
            }
        }

        public static void updateGame(LegaGladio.Entities.Game game, Int32 oldId)
        {
            try
            {
                DataAccessLayer.Game.updateGame(game, oldId);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while updating Game");
                throw ex;
            }
        }

        public static void removeGame(Int32 id)
        {
            try
            {
                DataAccessLayer.Game.deleteGame(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while deleting game");
                throw ex;
            }
        }
    }
}
