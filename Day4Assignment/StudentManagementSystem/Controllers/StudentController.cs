using Assignment4a.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment4a.Controllers
{
    public class StudentController : Controller
    {
        SbContext sb = new SbContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DisplayAllStudents()
        {
            List<Student> list = sb.Students.ToList();

            return View(list);
        }

        public IActionResult AddStudent()
        {
            List<Course> list = sb.Courses.ToList();

            ViewBag.Courses = list;
           return View(list);
        }

        public IActionResult AfterAddStudent(int id , Student s)
        {

            sb.Students.Add(s);
            sb.SaveChanges();
            Course c=sb.Courses.Find(id);
            c.StudentId=s.Id;
            sb.SaveChanges();

            /* Student s = new Student();
             s.First_Name= First_Name;
             s.Last_Name= Last_Name;*/



            return Redirect("/Student/DisplayAllStudents/");
        }

        public IActionResult EditStudent(int id)
        {
            Student s = sb.Students.Find(id);
            
            return View(s);
        }
        public IActionResult AfterEditStudent(Student s1)
        {
            sb.Students.Update(s1);
            sb.SaveChanges();

            return Redirect("/Student/DisplayAllStudents/");
        }
        public IActionResult DeleteStudent(int id)
        {
            Student student = sb.Students.Find(id);
            sb.Students.Remove(student);
            sb.SaveChanges();
            return Redirect("/Student/DisplayAllStudents/");
        }

    }
}
