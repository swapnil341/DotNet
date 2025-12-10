namespace Day1Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student();

            Console.Write("Name: ");
            s1.Name = Console.ReadLine();

            Console.Write("Age: ");
            s1.Age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Roll No: ");
            s1.RollNo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Course: ");
            s1.Course = Console.ReadLine();


            // Display Student Info

            Console.WriteLine($"Name: {s1.Name}");
            Console.WriteLine($"Age: {s1.Age}");
            Console.WriteLine($"Roll No: {s1.RollNo}");
            Console.WriteLine($"Course: {s1.Course}");
        }
    }

    class Student
    {
        private string _name;
        private int _age;
        private int _rollNo;
        private string _course;

        public string Course
        {
            get { return _course; }
            set { _course = value; }
        }


        public int RollNo
        {
            get { return _rollNo; }
            set { _rollNo = value; }
        }


        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

    }


}
