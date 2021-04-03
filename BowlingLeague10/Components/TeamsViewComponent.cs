using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BowlingLeague10.Models;
using Microsoft.AspNetCore.Mvc;

namespace BowlingLeague10.Components
{
    public class TeamsViewComponent : ViewComponent
    {
        private BowlingLeagueContext context;
        public TeamsViewComponent(BowlingLeagueContext ctx)
        {
            context = ctx;
        }
        public IViewComponentResult Invoke ()
        {
            // Setting up the data for the view component 
            return View(context.Teams.Distinct().OrderBy(x => x));

        }
    }
}
