using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegaGladio.Entities.Dto
{
    public class Skill
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public SkillType SkillType { get; set; }

        public Skill(Entities.Skill s)
        {
            Id = s.Id;
            Name = s.Name;
            SkillType = s.SkillType;
        }
    }
}
