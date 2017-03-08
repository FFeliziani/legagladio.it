using System;

namespace LegaGladio.Entities
{
    public class Skill
    {
        public virtual int Id { get; set; }

        public virtual String Name { get; set; }

        public virtual SkillType SkillType { get; set; }

/*
        public SkillCost SkillCost { get; set; }
*/
    }
}