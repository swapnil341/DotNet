using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Assignment3_1
{
    internal class Program
    {
        static SchoolContext db = new SchoolContext();
        static List<Student> StdList;
        static void Main(string[] args)
        {
            int choice,status;
            do
            {
                Console.WriteLine("1. Add Student \n2. Add Course \n3. View all Students with Courses \n4. Update Course Name \n5. Delete Course \n6. Exit");
                choice = Convert.ToInt32(Console.ReadLine());
                
                switch (choice)
                {
                    case 1:
                        status = AddStudent();
                        if (status == 0)
                            Console.WriteLine("Failed to add student");
                        else
                            Console.WriteLine("Student added");
                        break;

                    case 2:
                        status = AddCourse();
                        if (status == 0)
                            Console.WriteLine("Failed to add course");
                        else
                            Console.WriteLine("Course added");
                        break;

                    case 3:
                        Display();
                        break;

                    case 4:
                        status = UpdateCourseName();
                        if (status == 0)
                            Console.WriteLine("Failed to Update!");
                        else
                            Console.WriteLine("Course Name Changed");
                        break;

                    case 5:
                        status = DeleteCourse();
                        if (status == 0)
                            Console.WriteLine("Failed to Delete!");
                        else
                            Console.WriteLine();
                        break;
                    
                }


            } while (choice != 6);
        }


        // 1.Add Students 
        public static int AddStudent()
        {
            Student s = new Student();

            Console.Write("First Name: ");
            s.FirstName = Console.ReadLine();

            Console.Write("Last Name: ");
            s.LastName = Console.ReadLine();

            db.Students.Add(s);
            return db.SaveChanges();
        }

        public static int AddCourse()
        {
            Course c = new Course();

            Console.Write("Student Id: ");
            c.StudentId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Course Name: ");
            c.CourseName = Console.ReadLine();

            db.Courses.Add(c);
            return db.SaveChanges();
        }

        public static void Display()
        {
            StdList = GetAllStudents();
            foreach (var stud in StdList)
            {
                Console.WriteLine($"Id: {stud.StudentId}  First Name: {stud.FirstName}  Last Name: {stud.LastName}");
                Console.Write("**** Courses ****\n");
                foreach (var c in stud.Courses) 
                {
                    Console.WriteLine($"Course Id: {c.CourseId}  Course Name: {c.CourseName}");
                    
                }
                Console.WriteLine();    
            }
            Console.WriteLine();
                        
        }
        public static List<Student> GetAllStudents()
        {
            return db.Students.Include(s => s.Courses).ToList();
        }

        public static Course FindCourse(int id)
        {
            return db.Courses.Find(id);
        }

        // update course name
        public static int UpdateCourseName()
        {
            Console.Write("Course Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Course c = FindCourse(id);

            if(c != null)
            {
                Console.Write("Course Name: ");
                c.CourseName = Console.ReadLine();

                return db.SaveChanges();
            }
            else
            {
                Console.WriteLine("No course found with id "+c.StudentId);
                return 0;
            }

        }

        public static int DeleteCourse()
        {
            Console.Write("Course Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Course c = FindCourse(id);

            if (c != null)
            {
                db.Courses.Remove(c);
                Console.WriteLine("Course has been deleted!");
                return db.SaveChanges();
            }
            else
            {
                Console.WriteLine("No course found with id " + c.StudentId);
                return 0;
            }
        }
    }

}
