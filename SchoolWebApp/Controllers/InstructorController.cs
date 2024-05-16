using Microsoft.AspNetCore.Mvc;
using SchoolWebApp.Data;
using SchoolWebApp.Models.Entities;

namespace SchoolWebApp.Controllers
{
    public class InstructorController : Controller
    {
        public readonly IGenericRepository<Instructor> _instructorRepo;
        public InstructorController(IGenericRepository<Instructor> instructorRepo)
        {
           _instructorRepo=instructorRepo;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Email, string Password)
        {

            var getobj = _instructorRepo.Read().FirstOrDefault((u) => u.Email == Email && u.Password == Password);
            ViewBag.val = getobj.ID;
            if (getobj != null)
                return View("Homepage");
            else
                return View();
        }
        [HttpGet]
        public IActionResult Registration()
        {
            ViewData["Title"] = "Registration";
            return View();
        }

        [HttpPost]
        public IActionResult Registration(Instructor obj)
        {

            if (obj != null)
            {
                bool temp = _instructorRepo.Create(obj);
                if (temp)
                {
                    return View("Login");
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Homepage()
        {
            ViewData["Title"] = "Homepage";
            return View();
        }

    }
}
