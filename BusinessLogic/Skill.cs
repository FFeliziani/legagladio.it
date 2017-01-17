using System;
using System.Collections.Generic;
using NLog;

namespace BusinessLogic
{
    public static class Skill
    {
        private readonly static Logger Logger = LogManager.GetCurrentClassLogger();

        public static int Count()
        {
            try
            {
                return DataAccessLayer.Skill.CountSkill();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while counting skills");
                throw;
            }
        }

        public static List<LegaGladio.Entities.Skill> List()
        {
            try
            {
                return DataAccessLayer.Skill.ListSkill();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while listing skills");
                throw;
            }
        }

        public static LegaGladio.Entities.Skill Get(int id)
        {
            try
            {
                return DataAccessLayer.Skill.GetSkill(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while getting skills");
                throw;
            }
        }

        public static void AddSkillToPlayer(Int32 skillId, Int32 playerId)
        {
            try
            {
                DataAccessLayer.Skill.AddSkillToPlayer(skillId, playerId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while adding skill to player");
                throw;
            }
        }

        public static void RemoveSkillFromPlayer(Int32 skillId, Int32 playerId)
        {
            try
            {
                DataAccessLayer.Skill.RemoveSkillFromPlayer(skillId, playerId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while removing skill from player");
                throw;
            }
        }

        public static void NewSkill(LegaGladio.Entities.Skill skill)
        {
            try
            {
                DataAccessLayer.Skill.NewSkill(skill);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while creating skills");
                throw;
            }
        }

        public static void UpdateSkill(LegaGladio.Entities.Skill skill, int oldId)
        {
            try
            {
                DataAccessLayer.Skill.UpdateSkill(skill, oldId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while updating skills");
                throw;
            }
        }

        public static void DeleteSkill(int id)
        {
            try
            {
                DataAccessLayer.Skill.DeleteSkill(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while deleting skills");
                throw;
            }
        }
    }
}
