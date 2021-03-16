using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WeatherLogger.Data;
using WeatherLogger.Models;

namespace WeatherLogger.Controllers
{
    public class MeasureController : Controller
    {
        private ApplicationDbContext _context;

        public MeasureController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult SaveMeasure(MeasureViewModel measure)
        {
            _context.Add(measure.ToMeasure());
            _context.SaveChanges();
            //var meas = _context.Measures.Single(m => m.Id == Guid.Empty);
            return new JsonResult(measure);
        }
        [HttpGet]
        public IActionResult GetAllMeasures() => new JsonResult(_context.Measures.Where(m => m.Temperature > 20).ToList());
    }
}