using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegaGladio.BusinessLogic
{
    public class Skill
    {
        public static int count()
        {
            return DataAccessLayer.Skill.countSkill();
        }

        public static List<LegaGladio.Entities.Skill> list()
        {
            return DataAccessLayer.Skill.listSkill();
        }

        public static LegaGladio.Entities.Skill get(int id)
        {
            return DataAccessLayer.Skill.getSkill(id);
        }

        public static Boolean newSkill(LegaGladio.Entities.Skill skill)
        {
            return DataAccessLayer.Skill.newSkill(skill);
        }

        public static Boolean updateSkill(LegaGladio.Entities.Skill skill, int oldID)
        {
            return DataAccessLayer.Skill.updateSkill(skill, oldID);
        }

        public static Boolean deleteSkill(int id)
        {
            return DataAccessLayer.Skill.deleteSkill(id);
        }
    }
}
