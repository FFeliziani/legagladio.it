using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegaGladio.BusinessLogic
{
    public class Game
    {
        public static LegaGladio.Entities.Game get(int id) 
        {
            return DataAccessLayer.Game.getGame(id);
        }
        public static List<LegaGladio.Entities.Game> listGame()
        {
            return DataAccessLayer.Game.listGame();
        }
        public static List<LegaGladio.Entities.Game> listGame(LegaGladio.Entities.Team team)
        {
            return DataAccessLayer.Game.listGame(team);
        }
        public static List<LegaGladio.Entities.Game> listGame(LegaGladio.Entities.Coach coach)
        {
            return DataAccessLayer.Game.listGame(coach);
        }
    }
}
