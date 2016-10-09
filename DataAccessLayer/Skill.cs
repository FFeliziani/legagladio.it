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
            LegaGladioDSTableAdapters.skillTableAdapter sta = new LegaGladioDSTableAdapters.skillTableAdapter();

            return (int)sta.Count();
        }

        public static List<LegaGladio.Entities.Skill> listSkill()
        {
            LegaGladioDSTableAdapters.skillTableAdapter sta = new LegaGladioDSTableAdapters.skillTableAdapter();
            List<LegaGladio.Entities.Skill> listaSkill = new List<LegaGladio.Entities.Skill>();

            LegaGladioDS.skillDataTable sdt = sta.GetData();

            foreach(LegaGladioDS.skillRow skillRow in sdt.Rows)
            {
                LegaGladio.Entities.Skill skill = Skill.getSkill(skillRow.name);
                listaSkill.Add(skill);
            }

            return listaSkill;
        }

        // FF: Return all skills for player
        public static List<LegaGladio.Entities.Skill> listSkill(int playerId)
        {
            LegaGladioDSTableAdapters.player_skillTableAdapter psta = new LegaGladioDSTableAdapters.player_skillTableAdapter();
            List<LegaGladio.Entities.Skill> listaSkill = new List<LegaGladio.Entities.Skill>();

            LegaGladioDS.player_skillDataTable psdt = psta.GetDataByPlayerId(playerId);

            foreach (LegaGladioDS.player_skillRow psr in psdt.Rows)
            {
                listaSkill.Add(Skill.getSkill((int)psr.skillID));
            }
            
            return listaSkill;
        }

        public static LegaGladio.Entities.Skill getSkill(int id)
        {
            LegaGladioDSTableAdapters.skillTableAdapter sta = null;
            LegaGladioDS.skillDataTable sdt = null;
            LegaGladio.Entities.Skill skill = null;

            try
            {
                sdt = sta.GetDataById(id);
                sta = new LegaGladioDSTableAdapters.skillTableAdapter();

                if (sdt.Rows.Count > 1)
                {
                    throw new Exception("Troppe skill trovate per l'id " + id);
                }

                skill = new LegaGladio.Entities.Skill();

                LegaGladioDS.skillRow sr = (LegaGladioDS.skillRow)sdt.Rows[0];

                skill.Id = (int)sr.id;
                skill.Name = sr.name;
                skill.SkillType = (LegaGladio.Entities.SkillType)sr.type;
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return skill;
        }

        public static LegaGladio.Entities.Skill getSkill(String name)
        {
            LegaGladioDSTableAdapters.skillTableAdapter sta = new LegaGladioDSTableAdapters.skillTableAdapter();

            LegaGladioDS.skillDataTable sdt = sta.GetDataByName(name);

            if (sdt.Rows.Count > 1)
            {
                throw new Exception("Troppe skill trovate per il nome " + name);
            }

            LegaGladio.Entities.Skill skill = new LegaGladio.Entities.Skill();

            LegaGladioDS.skillRow sr = (LegaGladioDS.skillRow)sdt.Rows[0];

            skill.Id = (int)sr.id;
            skill.Name = sr.name;
            skill.SkillType = (LegaGladio.Entities.SkillType)sr.type;
            
            return skill;
        }

        public static Boolean newSkill(LegaGladio.Entities.Skill skill)
        {
            LegaGladioDSTableAdapters.skillTableAdapter sta = new LegaGladioDSTableAdapters.skillTableAdapter();

            int rowNum = sta.Insert(skill.Name, (int)skill.SkillType);

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
