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

        [HttpGet]
        public IActionResult Index(int pageSize = 15, int pageNumber = 1)
        {
            pageSize = Math.Clamp(pageSize, 1, 200);
            pageNumber = Math.Max(1, pageNumber);

            var data = _mongo.Data.Find(d => true).Skip((pageNumber - 1) * pageSize).Limit(pageSize).ToList();

            var totalCount = _mongo.Data.CountDocuments(d => true);
            ViewBag.TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            ViewBag.CurrentPage = pageNumber;
            ViewBag.PageSize = pageSize;

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
