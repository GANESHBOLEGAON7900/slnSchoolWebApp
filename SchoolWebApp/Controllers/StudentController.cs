using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolWebApp.Data;
using SchoolWebApp.Models.Entities;

namespace SchoolWebApp.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        public readonly IGenericRepository<Student> _studentRepo;
        public readonly IGenericRepository<Course> _cousreRepo;
        public readonly IGenericRepository<Instructor> _instructorRepo;
        public StudentController(IGenericRepository<Student> studentRepo, IGenericRepository<Course> cousreRepo, IGenericRepository<Instructor> instructorRepo)
        {
            _studentRepo = studentRepo;
            _cousreRepo = cousreRepo;
            _instructorRepo = instructorRepo;

        }
        public IActionResult Index()
        {
            return View();
        }
        //[HttpGet]
        //public IActionResult Login()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Login(string Email, string Password)
        //{

        //    var getobj = _studentRepo.Read().FirstOrDefault((u) => u.Email == Email && u.Password == Password);
        //    ViewBag.val=getobj.ID;
        //    if (getobj != null)
        //        return View("Homepage");
        //    else
        //        return View();
        //}
        //[HttpGet]
        //public IActionResult Registration()
        //{
        //    ViewData["Title"] = "Registration";
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Registration(Student obj)
        //{

        //    if (obj != null)
        //    {
        //        bool temp = _studentRepo.Create(obj);
        //        if (temp)
        //        {
        //            return View("Login");
        //        }
        //    }
        //    return View();
        //}
        [HttpGet]
        public IActionResult Homepage()
        {
            ViewData["Title"] = "Homepage";
            return View();
        }

        [HttpGet]
        public IActionResult Edit(string Email, string Password)
        {
            ViewData["Title"] = "Edit-Admin";

            var lst = _studentRepo.Read().FirstOrDefault((u) => u.Email == Email && u.Password == Password);

            return View(lst);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            var lst = _studentRepo.Read().FirstOrDefault(u => u.ID == student.ID);
            lst.FirstName = student.FirstName;
            lst.LastName = student.LastName;
            lst.Email = student.Email;
            lst.Password = student.Password;
            _studentRepo.Update(lst);
            return View("Homepage");
        }

        [HttpPost]
        public IActionResult Delete(int ID)
        {
            ViewData["Title"] = "Edit-Admin";

            var lst = _studentRepo.Read().FirstOrDefault(u => u.ID == ID);
            _studentRepo.Delete(lst);
            var list = _studentRepo.Read();
            return View("Homepage", list);

        }
       
        [HttpGet]
     
        public IActionResult Course(int?ID)
        {

            if (ID>0)
            {
                ViewBag.lst = _studentRepo.Read().FirstOrDefault(u => u.ID == ID);

                return View("Course");
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddCourse()
        {
            ViewBag.Instructor = _instructorRepo.Read();
            
            return View();
        }
        [HttpPost]
        public IActionResult AddCourse(Course course,int ID)
        {
            var student=_studentRepo.Read().FirstOrDefault(x => x.ID == ID);
            var instructor = _instructorRepo.Read().FirstOrDefault(x => x.ID == course.InstructorID);
            course.Instructors = instructor;
            student.Courses.Add(course);
            
            if (course != null)
            {
                bool temp = _studentRepo.Update(student);
                if (temp)
                {
                    return View("Homepage");
                }
            }
            return View();
        }
    }
}
