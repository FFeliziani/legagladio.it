using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegaGladio.BusinessLogic
{
    public class Team
    {
        public static int count()
        {
            return DataAccessLayer.Team.countTeam();
        }

        public static List<LegaGladio.Entities.Team> list()
        {
            return DataAccessLayer.Team.listTeam();
        }

        public static List<LegaGladio.Entities.Team> list(int coachID)
        {
            return DataAccessLayer.Team.listTeam(coachID);
        }

        public static LegaGladio.Entities.Team get(int id)
        {
            return DataAccessLayer.Team.getTeam(id);
        }

        public static Boolean newTeam(LegaGladio.Entities.Team team)
        {
            return DataAccessLayer.Team.newTeam(team);
        }

        public static Boolean updateTeam(LegaGladio.Entities.Team team, int oldID)
        {
            return DataAccessLayer.Team.updateTeam(team, oldID);
        }

        public static Boolean deleteTeam(int id)
        {
            return DataAccessLayer.Team.deleteTeam(id);
        }
    }
}
