using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [Route("ViewRace/{Id}")]
        public IActionResult RaceDetail(int Id)
        {
            ViewBag.Race = _context.Races.Where(Race => Race.RaceId == Id).Include(Race => Race.Runners).SingleOrDefault();
            return View();
        }
    }
}
