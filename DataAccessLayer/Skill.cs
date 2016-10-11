﻿using System;
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
            LegaGladioDSTableAdapters.skillTableAdapter sta = new LegaGladioDSTableAdapters.skillTableAdapter();
            int count = (int)sta.Count();
            sta = null;
            return count;
        }

        public static List<LegaGladio.Entities.Skill> listSkill()
        {
            LegaGladioDS.skillDataTable sdt = new LegaGladioDS.skillDataTable();
            LegaGladioDSTableAdapters.skillTableAdapter sta = new LegaGladioDSTableAdapters.skillTableAdapter();
            List<LegaGladio.Entities.Skill> skillList = null;
            try
            {
                sta.Fill(sdt);
                skillList = new List<LegaGladio.Entities.Skill>();
                foreach (LegaGladioDS.skillRow skillRow in sdt.Rows)
                {
                    LegaGladio.Entities.Skill skill = new LegaGladio.Entities.Skill();
                    skill.Id = (int)skillRow.id;
                    skill.Name = skillRow.name;
                    skill.SkillType = (LegaGladio.Entities.SkillType)skillRow.type;
                    skillList.Add(skill);
                }
            }
            catch (Exception ex)
            {
                sdt.GetErrors();
                throw ex;
            }
            finally
            {
                sta = null;
                sdt = null;
            }
            return skillList;
        }

        // FF: Return all skills for player
        public static List<LegaGladio.Entities.Skill> listSkill(int playerId)
        {
            LegaGladioDS.player_skillDataTable psdt = new LegaGladioDS.player_skillDataTable();
            LegaGladioDSTableAdapters.player_skillTableAdapter psta = new LegaGladioDSTableAdapters.player_skillTableAdapter();
            List<LegaGladio.Entities.Skill> skillList = null;
            try
            {
                psta.FillByPlayerId(psdt, playerId);
                skillList = new List<LegaGladio.Entities.Skill>();
                foreach (LegaGladioDS.player_skillRow psr in psdt.Rows)
                {
                    skillList.Add(Skill.getSkill((int)psr.skillID));
                }
            }
            catch (Exception ex)
            {
                psdt.GetErrors();
                throw ex;
            }
            finally
            {
                psta = null;
                psdt = null;
            }
            return skillList;
        }

        public static LegaGladio.Entities.Skill getSkill(int id)
        {
            LegaGladioDS.skillDataTable sdt = new LegaGladioDS.skillDataTable();
            LegaGladioDSTableAdapters.skillTableAdapter sta = new LegaGladioDSTableAdapters.skillTableAdapter();
            LegaGladio.Entities.Skill skill = null;

            try
            {
                sta.FillById(sdt, id);

                if (sdt.Rows.Count != 1)
                {
                    throw new Exception("Numero non valido di skill trovate per l'id " + id);
                }

                skill = new LegaGladio.Entities.Skill();

                LegaGladioDS.skillRow sr = (LegaGladioDS.skillRow)sdt.Rows[0];

                skill.Id = (int)sr.id;
                skill.Name = sr.name;
                skill.SkillType = (LegaGladio.Entities.SkillType)sr.type;
            }
            catch (Exception ex)
            {
                sdt.GetErrors();
                throw ex;
            }
            finally
            {
                sdt = null;
                sta = null;
            }

            return skill;
        }

        public static LegaGladio.Entities.Skill getSkill(String name)
        {
            LegaGladioDSTableAdapters.skillTableAdapter sta = new LegaGladioDSTableAdapters.skillTableAdapter();
            LegaGladioDS.skillDataTable sdt = new LegaGladioDS.skillDataTable();
            LegaGladio.Entities.Skill skill = null;

            try
            {
                sta.FillByName(sdt, name);

                if (sdt.Rows.Count != 1)
                {
                    throw new Exception("Numero non valido di skill trovate per il nome " + name);
                }

                skill = new LegaGladio.Entities.Skill();

                LegaGladioDS.skillRow sr = (LegaGladioDS.skillRow)sdt.Rows[0];

                skill.Id = (int)sr.id;
                skill.Name = sr.name;
                skill.SkillType = (LegaGladio.Entities.SkillType)sr.type;
            }
            catch (Exception ex)
            {
                sdt.GetErrors();
                throw ex;
            }
            finally
            {
                sta = null;
                sdt = null;
            }
            return skill;
        }

        public static Boolean newSkill(LegaGladio.Entities.Skill skill)
        {
            LegaGladioDSTableAdapters.skillTableAdapter sta = new LegaGladioDSTableAdapters.skillTableAdapter();
            int rowNum = sta.Insert(skill.Name, (int)skill.SkillType);
            sta = null;
            return rowNum == 1;
        }

        public static Boolean newSkills(List<LegaGladio.Entities.Skill> skillList)
        {
            Boolean works = true;
            foreach (LegaGladio.Entities.Skill skill in skillList)
            {
                works &= Skill.newSkill(skill);
            }
            return works;
        }

        public static Boolean updateSkill(LegaGladio.Entities.Skill skill, int oldID)
        {
            return false;
        }

        public static Boolean deleteSkill(int id)
        {
            LegaGladioDSTableAdapters.skillTableAdapter sta = new LegaGladioDSTableAdapters.skillTableAdapter();
            int rowNum = sta.Delete(id);
            sta = null;
            return rowNum == 1;
        }

        public static Boolean deleteSkills(List<LegaGladio.Entities.Skill> skillList)
        {
            Boolean works = true;
            foreach (LegaGladio.Entities.Skill skill in skillList)
            {
                works &= Skill.deleteSkill(skill.Id);
            }
            return works;
        }
    }
}