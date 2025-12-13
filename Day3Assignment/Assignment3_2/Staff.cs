using System.ComponentModel.DataAnnotations;

namespace Assignment3_2
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int ManagerId { get; set; }

        public Manager Manager = new Manager();

        public List<TaskItem> Tasks { get; set; }

    }

}
