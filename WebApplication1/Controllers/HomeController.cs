using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System.Diagnostics;
using WebApplication1.Models;
using WebApplication1.Models.DB;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(DatabaseStaff.GetList());
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


        //ACTION
        public IActionResult Create()
        {
            return View();       
        }

        [HttpPost]
        public IActionResult Create(Staff s)
        {
            DatabaseStaff.AddStaff(s);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Staff p = DatabaseStaff.GetPersona(id);
            return View(p);       //prende in ingresso p
        }

        [HttpPost]
        public IActionResult Edit(Staff s)  //prende in ingresso persona di prima
        {
            DatabaseStaff.EditPersona(s);
            return RedirectToAction("Index");       
        }


        //[HttpDelete]
        public IActionResult Remove(int id)
        {
            DatabaseStaff.RemovePersona(id);
            return RedirectToAction("Index");
        }


    }
}