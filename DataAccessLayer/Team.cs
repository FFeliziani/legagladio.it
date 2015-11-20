using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Team
    {
        public static int countTeam()
        {
            return 0;
        }

        public static List<LegaGladio.Entities.Team> listTeam()
        {
            return null;
        }

        public static LegaGladio.Entities.Team getTeam(int id)
        {
            return null;
        }

        public static Boolean newTeam(LegaGladio.Entities.Team team)
        {
            return false;
        }

        public static Boolean updateTeam(LegaGladio.Entities.Team team, int oldID)
        {
            return false;
        }

        public static Boolean deleteTeam(int id)
        {
            return false;
        }
    }
}
