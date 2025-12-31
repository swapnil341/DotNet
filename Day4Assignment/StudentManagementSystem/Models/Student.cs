
using Assignment4a.Models;
using System.ComponentModel.DataAnnotations;

namespace Assignment4a.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }

        public List<Course> Courses { get; set; }

    }
}
