using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Skill
    {
        public static int countSkill()
        {
            return 0;
        }

        public static List<LegaGladio.Entities.Skill> listSkill()
        {
            return null;
        }

        // FF: Return all skills for player
        public static List<LegaGladio.Entities.Skill> listSkill(int id)
        {
            return null;
        }

        public static LegaGladio.Entities.Skill getSkill(int id)
        {
            return null;
        }

        public static Boolean newSkill(LegaGladio.Entities.Skill skill)
        {
            return false;
        }

        public static Boolean updateSkill(LegaGladio.Entities.Skill skill, int oldID)
        {
            return false;
        }

        public static Boolean deleteSkill(int id)
        {
            return false;
        }
    }
}
