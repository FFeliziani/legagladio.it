using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.LegaGladioDSTableAdapters;
using LegaGladio.Entities;

namespace DataAccessLayer
{
    public static class Skill
    {
        public static int CountSkill()
        {
            var sta = new skillTableAdapter();
            var count = (int)sta.Count();
            return count;
        }

        public static IEnumerable<LegaGladio.Entities.Skill> ListSkill()
        {
            var sdt = new LegaGladioDS.skillDataTable();
            var sta = new skillTableAdapter();
            sta.Fill(sdt);
            var skillList = (from LegaGladioDS.skillRow skillRow in sdt.Rows
                             select new LegaGladio.Entities.Skill
                             {
                                 Id = skillRow.id,
                                 Name = skillRow.name,
                                 SkillType = (SkillType)skillRow.type
                             }).ToList();
            return skillList;
        }

        // FF: Return all skills for player
        public static IEnumerable<LegaGladio.Entities.Skill> ListSkill(int playerId)
        {
            var sdt = new LegaGladioDS.skillDataTable();
            var sta = new skillTableAdapter();
            sta.FillByPlayerId(sdt, playerId);
            var skillList = (from LegaGladioDS.skillRow sr in sdt.Rows select GetSkill(sr.id)).ToList();
            return skillList;
        }

        public static IEnumerable<LegaGladio.Entities.Skill> ListSkill(LegaGladio.Entities.Positional positional)
        {
            var sdt = new LegaGladioDS.skillDataTable();
            var sta = new skillTableAdapter();
            sta.FillByPositionalId(sdt, positional.Id);
            var skillList = (from LegaGladioDS.skillRow sr in sdt.Rows select GetSkill(sr.id)).ToList();
            return skillList;
        }

        public static LegaGladio.Entities.Skill GetSkill(int id)
        {
            var sdt = new LegaGladioDS.skillDataTable();
            var sta = new skillTableAdapter();

            sta.FillById(sdt, id);

            if (sdt.Rows.Count != 1)
            {
                throw new Exception("Numero non valido di skill trovate per l'id " + id);
            }

            var sr = (LegaGladioDS.skillRow)sdt.Rows[0];
            var skill = new LegaGladio.Entities.Skill { Id = sr.id, Name = sr.name, SkillType = (SkillType)sr.type };
            return skill;
        }

        public static LegaGladio.Entities.Skill GetSkill(String name)
        {
            var sta = new skillTableAdapter();
            var sdt = new LegaGladioDS.skillDataTable();

            sta.FillByName(sdt, name);

            if (sdt.Rows.Count != 1)
            {
                throw new Exception("Numero non valido di skill trovate per il nome " + name);
            }
            var sr = (LegaGladioDS.skillRow)sdt.Rows[0];
            var skill = new LegaGladio.Entities.Skill {Id = sr.id, Name = sr.name, SkillType = (SkillType) sr.type};
            return skill;
        }

        public static void AddSkillToPlayer(Int32 skillId, Int32 playerId)
        {
            var sta = new skillTableAdapter();

            sta.AddSkillToPlayer(playerId, skillId);
        }

        public static void RemoveSkillFromPlayer(Int32 skillId, Int32 playerId)
        {
            var sta = new skillTableAdapter();

            sta.RemoveSkillFromPlayer(skillId, playerId);
        }

        public static Boolean NewSkill(LegaGladio.Entities.Skill skill)
        {
            var sta = new skillTableAdapter();
            var rowNum = sta.Insert(skill.Name, (int)skill.SkillType);
            return rowNum == 1;
        }

        public static Boolean NewSkills(IEnumerable<LegaGladio.Entities.Skill> skillList)
        {
            return skillList.Aggregate(true, (current, skill) => current & NewSkill(skill));
        }

        public static void UpdateSkill(LegaGladio.Entities.Skill skill, int oldId)
        {
            var sta = new skillTableAdapter();
            var sdt = new LegaGladioDS.skillDataTable();
            var sr = (LegaGladioDS.skillRow)sdt.NewRow();
            sr.id = oldId;
            sr.name = skill.Name;
            sr.type = (int)skill.SkillType;
            sta.Update(sr);
        }

        public static Boolean DeleteSkill(int id)
        {
            var sta = new skillTableAdapter();
            var rowNum = sta.Delete(id);
            return rowNum == 1;
        }

        public static Boolean DeleteSkills(IEnumerable<LegaGladio.Entities.Skill> skillList)
        {
            return skillList.Aggregate(true, (current, skill) => current & DeleteSkill(skill.Id));
        }
    }
}
