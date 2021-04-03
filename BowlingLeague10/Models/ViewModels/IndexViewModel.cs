﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague10.Models.ViewModels
{
    public class IndexViewModel
    {
        public List<Bowlers> Bowlers { get; set; }

        public List<Teams> Teams { get; set; }
        public PageNumberingInfo PageNumberingInfo { get; set; }
        public string TheTeamName { get; set; }
    }
}
