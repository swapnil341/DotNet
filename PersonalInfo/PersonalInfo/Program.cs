using System.Xml.Serialization;

namespace PersonalInfo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fName;
            string lName;
            short age;
            string city;
            char choice;
            do
            {
                Console.WriteLine("Welcome to the Personal Information Filling Form\n\n");

                Console.Write("First Name: ");
                fName = Console.ReadLine();

                Console.Write("Last Name: ");
                lName = Console.ReadLine();

                Console.Write("Age: ");
                age = Convert.ToInt16(Console.ReadLine());

                Console.Write("City: ");
                city = Console.ReadLine();

                Display(fName, lName, age, city);

                Console.WriteLine("Do you want to add one more response! (Y/N)");
                choice = Convert.ToChar(Console.ReadLine());
            } while (choice == 'Y');
        }

        public static void Display(string fName, string lName, short age, string city)
        {
            Console.WriteLine("First Name: " + fName);
            Console.WriteLine("Last Name: " + lName);
            Console.WriteLine("Age: " + age);
            Console.WriteLine("City: " + city);
            Console.WriteLine();

        }
    }
}
