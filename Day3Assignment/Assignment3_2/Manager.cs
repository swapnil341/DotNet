using System.ComponentModel.DataAnnotations;

namespace Assignment3_2
{
    public class Manager
    {
        [Key]
        public int ManagerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        
        public List<Staff> Staffs { get; set; } = new List<Staff>();

    }

}
