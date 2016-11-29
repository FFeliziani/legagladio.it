﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegaGladio.Entities
{
    public class AfterGameEvent
    {
        public int Id { get; set; }
        public Player Player { get; set; }
        public Skill Skill { get; set; }
        public Injury Injury { get; set; }
    }
}