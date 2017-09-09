using System;
using System.Collections.Generic;
using System.Globalization;
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
            HttpContext.Session.Clear();
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
        public IActionResult SaveNewRace(RaceViewModel model)
        {
            if(ModelState.IsValid)
            {
                DateTime Start = DateTime.Parse(model.newStartDate);
                Race NewRace = new Race
                {
                    RaceName = model.newRaceName,
                    RacePaceMultiplyer = model.newMultiplyer,
                    RaceStart = Start + TimeSpan.Parse(model.newStartTime),
                    RaceEnd = Start.AddDays(1) + TimeSpan.Parse(model.newEndTime),
                    Type = (model.newRaceType == "true")? true : false,
                    TeamName = model.newTeamName
                };
                _context.Add(NewRace);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("WorkingRaceId", NewRace.RaceId);
                return RedirectToAction("CreateCourse");
            }
            return RedirectToAction("CreateRace");
        }

        [HttpGet]
        [Route("CreateRoster")]
        public IActionResult CreateRoster()
        {
            int? id = HttpContext.Session.GetInt32("WorkingRaceId");
            Race EditRace = _context.Races
                        .Where(Race => Race.RaceId == id)
                        .Include(Race => Race.Runners)
                        .Single();
            ViewBag.Runners = EditRace.Runners;
            return View();
        }

        [HttpPost]
        [Route("CreateRunner")]
        public IActionResult SaveNewRunner(RunnerViewModel model)
        {
            if(ModelState.IsValid)
            {
                int? id = HttpContext.Session.GetInt32("WorkingRaceId");
                Runner NewRunner = new Runner
                {
                    NickName = model.newRunnerName,
                    RunnerPace = (int) TimeSpan.Parse("00:" + model.newRunnerPace).TotalSeconds,
                    RunnerPaceMultiplyer = model.newRunnerMultiplyer,
                    RunnerSequence = model.newRunnerSequence
                };
                Race EditRace = _context.Races.Where(Race => Race.RaceId == id).Single();
                EditRace.Runners.Add(NewRunner);
                _context.SaveChanges();
            }
            return RedirectToRoute(new{
                controller = "Home",
                action = "CreateRoster"
            });
        }

        [HttpGet]
        [Route("CreateCourse")]
        public IActionResult CreateCourse()
        {
            int? id = HttpContext.Session.GetInt32("WorkingRaceId");
            Race EditRace = _context.Races
                        .Where(Race => Race.RaceId == id)
                        .Include(Race => Race.Courses)
                        .Single();
            ViewBag.FoundRace = EditRace;
            return View();
        }
        
        [HttpPost]
        [Route("CreateCourse")]
        public IActionResult SaveNewCourse(CourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                int? id = HttpContext.Session.GetInt32("WorkingRaceId");
                Course NewCourse = new Course
                {
                    Distance = model.newCourseDistance,
                    ElevGain = model.newCourseElevation,
                    Difficulty = model.newCourseDifficulty,
                    CourseSequence = model.newCourseSequence
                };
                Race EditRace = _context.Races.Where(Race => Race.RaceId == id).Single();
                EditRace.Courses.Add(NewCourse);
                _context.SaveChanges();
            }
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

        [HttpGet]
        [Route("Confirm")]
        public IActionResult ConfirmRace()
        {
            // int? id = HttpContext.Session.GetInt32("WorkingRaceId");
            int? id = 13;
            Race EditRace = _context.Races
                        .Where(r =>r.RaceId == id)
                        .Include(r => r.Courses)
                        .Include(r => r.Runners)
                        .Include(r => r.Laps)
                        .Single();
            EditRace.Laps = EditRace.Laps.OrderBy(l => l.LapSequence).ToList();

            ViewBag.FoundRace = EditRace;

            return View();
        }

        [HttpGet]
        [Route("CreateLaps")]
        public IActionResult CreateLaps()
        {
            // int? id = HttpContext.Session.GetInt32("WorkingRaceId");
            int? id = 13;

            if (id == null)
            {
                return RedirectToRoute(new
                {
                  controller = "Home",
                  action = "Index"
                });
            }
            Race EditRace = _context.Races
                        .Where(r => r.RaceId == id)
                        .Include(r => r.Courses)
                        .Include(r => r.Runners)
                        .Include(r => r.Laps)
                        .Single();
            if (EditRace.Laps.Count() == 0)
            {            
                int TotalLaps = (EditRace.Type)? 24 : 8;
                int TotalRunners = EditRace.Runners.Count();
                int TotalCourses = EditRace.Courses.Count();

                DateTime newStart = EditRace.RaceStart;

                for (var i = 1; i <= TotalLaps; i++)
                {
                    Runner ActiveRunner = EditRace.Runners
                                .Where(r => r.RunnerSequence == ((i % TotalRunners == 0) ? TotalRunners : i % TotalRunners))
                                .Single();
                    Course ActiveCourse = EditRace.Courses
                                .Where(r => r.CourseSequence == ((i % TotalCourses == 0) ? TotalCourses : i % TotalCourses))
                                .Single();
                    Lap NewLap = new Lap
                    {
                        LapSequence = i,
                        RunnerId = ActiveRunner.RunnerId,
                        Runner = ActiveRunner,
                        CourseId = ActiveCourse.CourseId,
                        Course = ActiveCourse,
                        StartTimeEst = newStart,
                        FinishTimeEst = (newStart + (TimeSpan.FromSeconds((ActiveRunner.RunnerPace * ActiveCourse.Distance) * EditRace.RacePaceMultiplyer)))
                    };
                    newStart = NewLap.FinishTimeEst;
                    EditRace.Laps.Add(NewLap);
                    _context.SaveChanges();
                }
            }
            
            return RedirectToRoute(new
            {
              controller = "Home",
              action = "ConfirmRace"
            });
        }
    }
}
