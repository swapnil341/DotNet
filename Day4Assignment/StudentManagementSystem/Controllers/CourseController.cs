using Assignment4a.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment4a.Controllers
{
    public class CourseController : Controller
    {
        SbContext sb = new SbContext();
        public IActionResult Index()
        {
            return View();
        }
       

        public IActionResult DisplayAllCourses()
        {
            
            List<Course> list = sb.Courses.ToList();

            return View(list);
        }

        public IActionResult AddCourse(int id )
        {
            Course s = sb.Courses.Find(id);
            return View(s);
        }

        public IActionResult AfterAddCourse(Course c)
        {

            sb.Courses.Add(c);
            sb.SaveChanges();
            return Redirect("/Course/DisplayAllCourses/");
        }

        public IActionResult EditCourse(int id)
        {
            Course s = sb.Courses.Find(id);
            ViewBag.StudentId = id;
            return View(s);
        }
        public IActionResult AfterEditCourse(Course s1)
        {
            sb.Courses.Update(s1);
            sb.SaveChanges();

            return Redirect("/Course/DisplayAllCourses/");
        }
        public IActionResult DeleteCourse(int id)
        {
            Course course = sb.Courses.Find(id);
            sb.Courses.Remove(course);
            sb.SaveChanges();
            return Redirect("/Course/DisplayAllCourses/");
        }

    }
}
