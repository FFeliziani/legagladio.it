using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegaGladio.BusinessLogic
{
    public class Player
    {
        public static int count()
        {
            return DataAccessLayer.Player.countPlayer();
        }

        public static List<LegaGladio.Entities.Player> list()
        {
            return DataAccessLayer.Player.listPlayer();
        }

        public static LegaGladio.Entities.Player get(int id)
        {
            return DataAccessLayer.Player.getPlayer(id);
        }

        public static Boolean newPlayer(LegaGladio.Entities.Player player)
        {
            return DataAccessLayer.Player.newPlayer(player);
        }

        public static Boolean updatePlayer(LegaGladio.Entities.Player player, int oldID)
        {
            return DataAccessLayer.Player.updatePlayer(player, oldID);
        }

        public static Boolean deletePlayer(int id)
        {
            return DataAccessLayer.Player.deletePlayer(id);
        }
    }
}
