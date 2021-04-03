using BowlingLeague10.Models;
using BowlingLeague10.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext context { get; set; } 

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext ctx)
        {
            _logger = logger;
            context = ctx; 
        }

        public IActionResult Index(long? teamnameid, string teamname, int pageNum = 0)
        {
            int pageSize = 5;
            ViewBag.SelectedTeam = RouteData?.Values["teamname"];

            return View(new IndexViewModel
            {

                Bowlers = (context.Bowlers
                    .Where(m => m.TeamId == teamnameid || teamnameid == null)
                    .OrderBy(m => m.Team)
                    .Skip((pageNum-1) * pageSize)
                    .Take(pageSize)
                    .ToList()),

                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize, 
                    CurrentPage = pageNum, 

                    // If no team has been selected, then get the full count. 
                    // Otherwise, only count the number from the team that has been selected. 
                    TotalNumItems = (teamnameid == null ? context.Teams.Count(): 
                                        context.Teams.Where(x => x.TeamId == teamnameid).Count())
                }, 
                TheTeamName = teamname
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
