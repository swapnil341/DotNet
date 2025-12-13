namespace Assignment3_1
{
    public class Student 
    { 
        public int StudentId { get; set; } 
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public List<Course> Courses { get; set; } = new List<Course>(); 
    }
    

}
