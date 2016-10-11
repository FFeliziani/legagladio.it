using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegaGladio.BusinessLogic
{
    public class Race
    {
        public static int count()
        {
            return DataAccessLayer.Race.countRace();
        }

        public static List<LegaGladio.Entities.Race> list()
        {
            return DataAccessLayer.Race.listRace();
        }

        public static LegaGladio.Entities.Race get(int id)
        {
            return DataAccessLayer.Race.getRace(id);
        }

        public static Boolean newRace(LegaGladio.Entities.Race race)
        {
            return DataAccessLayer.Race.newRace(race);
        }

        public static Boolean updateRace(LegaGladio.Entities.Race race, int oldID)
        {
            return DataAccessLayer.Race.updateRace(race, oldID);
        }

        public static Boolean deleteRace(int id)
        {
            return DataAccessLayer.Race.deleteRace(id);
        }
    }
}
