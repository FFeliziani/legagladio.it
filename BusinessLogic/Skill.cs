using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace LegaGladio.BusinessLogic
{
    public class Skill
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static int count()
        {
            try
            {
                return DataAccessLayer.Skill.countSkill();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while counting skills");
                throw ex;
            }
        }

        public static List<LegaGladio.Entities.Skill> list()
        {
            try
            {
                return DataAccessLayer.Skill.listSkill();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while listing skills");
                throw ex;
            }
        }

        public static LegaGladio.Entities.Skill get(int id)
        {
            try
            {
                return DataAccessLayer.Skill.getSkill(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while getting skills");
                throw ex;
            }
        }

        public static Boolean newSkill(LegaGladio.Entities.Skill skill)
        {
            try
            {
                return DataAccessLayer.Skill.newSkill(skill);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while creating skills");
                throw ex;
            }
        }

        public static Boolean updateSkill(LegaGladio.Entities.Skill skill, int oldID)
        {
            try
            {
                return DataAccessLayer.Skill.updateSkill(skill, oldID);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while updating skills");
                throw ex;
            }
        }

        public static Boolean deleteSkill(int id)
        {
            try
            {
                return DataAccessLayer.Skill.deleteSkill(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while deleting skills");
                throw ex;
            }
        }
    }
}
