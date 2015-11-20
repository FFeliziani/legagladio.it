using System;
using System.Collections.Generic;

namespace LegaGladio.Entities
{
    public class Skill
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public Skills SkillType { get; set; }
    }
}