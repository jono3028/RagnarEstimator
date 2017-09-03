using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RagnarEstimator.Models;

namespace RagnarEstimator.Controllers
{
    public class HomeController : Controller
    {
        private RagnarEstimatorContext _context;

        public HomeController(RagnarEstimatorContext context)
        {
            _context = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.AllRaces = _context.Races.ToList();
            return View();
        }

        [HttpGet]
        [Route("ViewRace/{id}")]
        public IActionResult RaceDetail(int id)
        {
            Race FoundRace = _context.Races
                            .Where(Race => Race.RaceId == id)
                            .Include(Race => Race.Runners)
                            .Include(Race => Race.Courses)
                            .Include(r => r.Laps)
                                .ThenInclude(l => l.Runner)
                            .Include(r => r.Laps)
                                .ThenInclude(l => l.Course)
                            .SingleOrDefault();

            FoundRace.Laps = FoundRace.Laps.OrderBy(l => l.LapSequence).ToList();
            FoundRace.Courses = FoundRace.Courses.OrderBy(c => c.CourseSequence).ToList();
            FoundRace.Runners = FoundRace.Runners.OrderBy(r => r.RunnerSequence).ToList();

            HttpContext.Session.SetInt32("WorkingRaceId", FoundRace.RaceId);
            ViewBag.Race = FoundRace;

            return View();
        }

        [HttpGet]
        [Route("CreateRace")]
        public IActionResult CreateRace()
        {

            return View();
        }

        [HttpPost]
        [Route("CreateRace")]
        public IActionResult SaveNewRace()
        {
            return RedirectToAction("CreateCourse");
        }

        [HttpGet]
        [Route("CreateRoster")]
        public IActionResult CreateRoster()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateRunner")]
        public IActionResult SaveNewRunner()
        {
            return RedirectToRoute(new{
                controller = "Home",
                action = "CreateRoster"
            });
        }

        [HttpGet]
        [Route("CreateCourse")]
        public IActionResult CreateCourse()
        {
            return View();
        }
        
        [HttpPost]
        [Route("CreateCourse")]
        public IActionResult SaveNewCourse()
        {
            return RedirectToRoute(new{
                controller = "Home",
                action = "CreateCourse"
            });
        }

        [HttpPost]
        [Route("UpdateTimes/{lapId}/{position}")]
        public IActionResult UpdateTimeEstimates(int lapId, string position)
        {
            int RaceId = (int) HttpContext.Session.GetInt32("WorkingRaceId");
            return RedirectToAction("RaceDetail", RaceId);
        }
    }
}
