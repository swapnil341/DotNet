using System.Collections.Immutable;

namespace Part_B_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 5. Given a list of integers: { 10, 2, 30, 4, 55, 60, 7, 8 }:
            List<int> list = new List<int>()
            {
                10, 2, 30, 4, 55, 60, 7, 8
            };

            //a.Find all even numbers using LINQ.
            Console.WriteLine("***** Even Numbers *****");
            var evenList = from l in list
                           where l % 2 == 0
                           select l;

            foreach (var item in evenList)
            {
                Console.WriteLine(item);
            }

            //b. Find max, min, average.
            int min = list.Min();
            int max = list.Max();
            double avg = list.Average();
            Console.WriteLine($"Min: {min}\nMax: {max}\nAverage: {avg} ");

            //c.Display numbers greater than 20 sorted descending.
            Console.WriteLine("**** numbers greater than 20 sorted descending *****");
            var temp = from i in list
                       where i > 20
                       orderby i descending
                       select i;

            foreach (var item in temp)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region 6. Create a list of Employees (Id, Name, Dept, Salary). Using LINQ:
            List<Employee> Employees = new List<Employee>()
            {
                new Employee { Id = 1, Name = "Amit", Dept = "IT", Salary = 55000 },
                new Employee { Id = 2, Name = "Sita", Dept = "HR", Salary = 45000 },
                new Employee { Id = 3, Name = "Rohan", Dept = "IT", Salary = 70000 },
                new Employee { Id = 4, Name = "Neha", Dept = "Sales", Salary = 65000 },
            };

            //a.Print names of employees from 'IT' department.
            Console.WriteLine("***** names of employees from 'IT' department *****");
            var res = from i in Employees
                      where i.Dept == "IT"
                      select i.Name;

            foreach (var emp in res)
            {
                Console.WriteLine(emp);
            }


            //b.Find employee with highest salary.
            var res1 = from j in Employees
                       orderby j.Salary descending
                       select j;

            var name = res1.First();

            Console.WriteLine($"Employee with highest salary is: {name.Name}");


            //c.Group employees by department.
            var groups = from e in Employees
                         group e by e.Dept into g
                         select g;

            foreach (var deptGroup in groups)
            {
                Console.WriteLine("Department: " + deptGroup.Key);
                foreach (var emp in deptGroup)
                    Console.WriteLine("  " + emp.Name);
            }


            #endregion

            #region 7. Using LINQ, join two lists:
            //List1: Student(Id, Name)
            List<Student> Students = new List<Student>()
            {
                new Student { Id = 1, Name = "Swapnil" },
                new Student { Id = 2, Name = "Riya" },
                new Student { Id = 3, Name = "Amit" }
            };

            //List2: Marks(StudentId, Subject, Score)
            List<Marks> marks = new List<Marks>()
            {
                new Marks { StudentId = 1, Subject = "Math", Score = 90 },
                new Marks { StudentId = 1, Subject = "Science", Score = 85 },
                new Marks { StudentId = 2, Subject = "Math", Score = 70 },
                new Marks { StudentId = 3, Subject = "English", Score = 88 }
            };

            //Display: Student Name – Subject – Score.
            Console.WriteLine("***** Join two tables Student and Marks *****");
            var result = from s in Students
                         join m in marks
                         on s.Id equals m.StudentId
                         select new
                         {
                             s.Name,
                             m.Subject,
                             m.Score
                         };

            foreach (var r in result)
            {
                Console.WriteLine($"{r.Name} - {r.Subject} - {r.Score}");
            }


            #endregion

            #region 8. Create a list of strings (city names). Using LINQ, return only names which start with 'P' and have length > 
            List<string> cities = new List<string>
            {
                "Pune", "Panipat", "Mumbai", "Paris", "Patiala", "Nagpur", "Pandharpur"
            };

            var res2 = from c in cities
                         where c.StartsWith("P") && c.Length > 5
                         select c;

            Console.WriteLine("City names which starts with 'P'");

            foreach (var item in res2)
            {
                Console.WriteLine(item);
            }

            #endregion
        }
    }
}
