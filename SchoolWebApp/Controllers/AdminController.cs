using Microsoft.AspNetCore.Mvc;
using SchoolWebApp.Data;
using SchoolWebApp.Models.Entities;

namespace SchoolWebApp.Controllers
{
    public class AdminController : Controller
    {
        public readonly IGenericRepository<Course> _courseObj;
        public readonly IGenericRepository<Instructor> _instructorObj;
        public AdminController(IGenericRepository<Course> courseObj, IGenericRepository<Instructor> instructorObj)
        {
            _courseObj= courseObj;
            _instructorObj= instructorObj;
        }
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Login()
        //{
        //    return View("Login");
        //}
        //[HttpPost]
        //public IActionResult Login(string Username, string Password)
        //{
        //    var getobj = _adminObj.Read().FirstOrDefault((u) => u.UserName == Username && u.Password == Password);
        //    if (getobj != null)
        //    {
        //        var lst = _adminObj.Read();
        //        return View("Homepage", lst);
        //    }
        //    else
        //        return View();
        //}

        //[HttpGet]
        //public IActionResult Registration()
        //{
        //    ViewData["Title"] = "Admin-Registration";
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Registration(Admin obj)
        //{

        //    if (obj != null)
        //    {
        //        bool temp = _adminObj.Create(obj);
        //        if (temp)
        //        {
        //            return View("AdminLogin", "Admin");
        //        }
        //    }
        //    return View();
        //}
        //[HttpGet]
        //public IActionResult Homepage()
        //{
        //    ViewData["Title"] = "Homepage";
        //    var list = _adminObj.Read();
        //    return View("Homepage", list);
        //}

        //[HttpGet]
        //public IActionResult Edit(string userName, string Password)
        //{
        //    ViewData["Title"] = "Edit-Admin";

        //    var lst = _adminObj.Read().FirstOrDefault((u) => u.UserName == userName && u.Password == Password);

        //    return View("Edit", lst);

        //}
        //[HttpPost]
        //public IActionResult Edit(Admin admin)
        //{
        //    var lst = _adminObj.Read().FirstOrDefault(u => u.ID == admin.ID);
        //    lst.Name = admin.Name;
        //    lst.Email = admin.Email;
        //    lst.Phone = admin.Phone;
        //    lst.UserName = admin.UserName;
        //    lst.Password = admin.Password;
        //    _adminObj.Update(lst);
        //    var list = _adminObj.Read();
        //    return View("Homepage", list);
        //}
        //[HttpGet]
        //public IActionResult Delete(int ID)
        //{
        //    ViewData["Title"] = "Edit-Admin";

        //    var lst = _adminObj.Read().FirstOrDefault((u) => u.ID == ID);


        //    return View("Delete", lst);

        //}

        //[HttpPost]
        //public IActionResult Delete(Admin admin, bool delete)
        //{
        //    ViewData["Title"] = "Edit-Admin";

        //    var lst = _adminObj.Read().FirstOrDefault(u => u.ID == admin.ID);
        //    _adminObj.Delete(lst);
        //    var list = _adminObj.Read();
        //    return View("Homepage", list);


        [HttpGet]
        public IActionResult AddCourse()
        {
            ViewBag.Instructor = _instructorObj.Read();
            return View();
        }
        [HttpPost]
        public IActionResult AddCourse(Course course)
        {
            var instructor=_instructorObj.Read().FirstOrDefault(x => x.ID == course.InstructorID);
            course.Instructors = instructor;
            if (course != null)
            {
                bool temp = _courseObj.Create(course);
                if (temp)
                {
                    return View("Index");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult ReadCourse()
        {
            var list = _courseObj.Read();
            return View(list);
        }




        [HttpGet]
        public IActionResult AddInstructor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddInstructor(Instructor instructor)
        {
            if (instructor != null)
            {
                //instructor.Role="instructor"
                bool temp = _instructorObj.Create(instructor);
                if (temp)
                {
                    return View();
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult ReadInstructors()
        {
            var list = _instructorObj.Read();
            return View(list);
        }

    }

    }

