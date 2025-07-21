using LessonForLesson.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using LessonForLesson.Data;
using MongoDB.Driver;

namespace LessonForLesson.Controllers
{
    public class HomeController : Controller
    {
        private readonly Settings _mongo;

        public HomeController(Settings mongo)
        {
            _mongo = mongo;
        }

        public IActionResult Index()
        {
            var data= _mongo.Data.Find(p => true).ToList();
            return View(data);
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
