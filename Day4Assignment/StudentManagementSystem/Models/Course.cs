using Assignment4a.Models;
using System.ComponentModel.DataAnnotations;

namespace Assignment4a.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string Course_Name { get; set; }

        public int StudentId { get; set; }
        Student Student { get; set; }

    }
}
