using CodeFirstApproach.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CodeFirstApproach.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDBContext studentDB;

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //creating a constructor of HomeController
        public HomeController(StudentDBContext studentDB)
        {
            this.studentDB = studentDB;
        }

        public IActionResult Index()
        {
            var std = studentDB.Students.ToList();  
            return View(std);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student std)
        {
            if (ModelState.IsValid)
            {
                studentDB.Students.Add(std);
                studentDB.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Details(int id)
        {
           var std = studentDB.Students.FirstOrDefault(s => s.Id == id);

            return View(std);
        }

        public IActionResult Delete(int id)
        {
            var std = studentDB.Students.FirstOrDefault(s => s.Id == id);

            return View(std);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var std = studentDB.Students.FirstOrDefault(s => s.Id == id);
            studentDB.Students.Remove(std);
            studentDB.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(int id) 
        { 
            var std = studentDB.Students.Find(id);
            return View(std);

        }

        [HttpPost]
        public IActionResult Edit(int id, Student std)
        {
            if(ModelState.IsValid)
            {
                studentDB.Students.Update(std);
                studentDB.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(std);
        }

 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
