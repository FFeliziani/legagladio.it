using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegaGladio.BusinessLogic
{
    public class Coach
    {
        public static int count()
        {
            return DataAccessLayer.Coach.countCoach();
        }

        public static List<LegaGladio.Entities.Coach> list()
        {
            return DataAccessLayer.Coach.listCoach();
        }

        public static List<LegaGladio.Entities.Coach> list(Boolean active)
        {
            return DataAccessLayer.Coach.listCoach(active);
        }

        public static LegaGladio.Entities.Coach get(int id)
        {
            return DataAccessLayer.Coach.getCoach(id);
        }

        public static Boolean newPlayer(LegaGladio.Entities.Coach coach)
        {
            return DataAccessLayer.Coach.newCoach(coach);
        }

        public static Boolean updatePlayer(LegaGladio.Entities.Coach coach, int oldID)
        {
            return DataAccessLayer.Coach.updateCoach(coach, oldID);
        }

        public static Boolean deletePlayer(int id)
        {
            return DataAccessLayer.Coach.deleteCoach(id);
        }
    }
}
