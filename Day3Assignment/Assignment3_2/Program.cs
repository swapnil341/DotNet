using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net.NetworkInformation;
using System.Xml.Serialization;

namespace Assignment3_2
{
    internal class Program
    {
        public static SbContext db = new SbContext();

        static void Main(string[] args)
        {
            int choice,status;
            do
            {
                Console.WriteLine("1. Add Manager \n2. Add Staff \n3. Add Task " +
                    "\n4. View all Managers, Staff & Tasks \n5. Update Task \n6. Delete Task \n7. Exit!");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        status = AddManager();
                        if (status != 0)
                            Console.WriteLine("Manager Added");
                        else
                            Console.WriteLine("Failed to add Manager!");
                        break;

                    case 2:
                        status = AddStaff();
                        if (status != 0)
                            Console.WriteLine("Staff Added");
                        else
                            Console.WriteLine("Failed to add Staff!");
                        break;

                    case 3:
                        status = AddTask();
                        if (status != 0)
                            Console.WriteLine("Task Added");
                        else
                            Console.WriteLine("Failed to add task");
                        break;
                        
                    case 4:
                        Display();
                        break;

                    case 5:
                        status = UpdateTask();
                        if (status != 0)
                            Console.WriteLine("Task Updated");
                        else
                            Console.WriteLine("Failed to update task");
                        break;

                    case 6:
                        status = DeleteTask();
                        if (status != 0)
                            Console.WriteLine("Task Deleted");
                        else
                            Console.WriteLine("Failed to delete task");
                        break;

                    case 7:
                        Console.WriteLine("Exit!");
                        break;

                    default:
                        Console.WriteLine("Enter valid choice");
                        break;

                }

            } while (choice != 7);
        
        }

        //1. Add Manager
        public static int AddManager()
        {
            Manager m = new Manager();

            Console.WriteLine("Name: ");
            m.Name = Console.ReadLine();

            Console.WriteLine("Email: ");
            m.Email = Console.ReadLine();

            db.Managers.Add(m);
            return db.SaveChanges();
        }

        //2. Add Staff
        public static int AddStaff()
        {
            Staff f = new Staff();

            Console.WriteLine("Name: ");
            f.Name = Console.ReadLine();

            Console.WriteLine("Email: ");
            f.Email = Console.ReadLine();

            Console.WriteLine("Manager Id: ");
            f.ManagerId = Convert.ToInt32(Console.ReadLine());

            db.Staffs.Add(f);
            return db.SaveChanges();
        }

        //3. Add Task
        public static int AddTask()
        {
            TaskItem t = new TaskItem();

            Console.WriteLine("Title: ");
            t.Title = Console.ReadLine();

            Console.WriteLine("Discription: ");
            t.Description = Console.ReadLine();

            Console.WriteLine("Is Completed: ");
            t.IsCompleted = Convert.ToBoolean(Console.ReadLine());

            Console.WriteLine("Staff Id: ");
            t.StaffId = Convert.ToInt32(Console.ReadLine());

            db.taskItems.Add(t);
            return db.SaveChanges();

        }

        //4. View all Managers, Staff & Tasks
        public static void Display()
        {
            List<Manager> m = GetAllManagers();
            foreach (var mgr in m)
            {
                Console.WriteLine($"Manager id: {mgr.ManagerId}  Name: {mgr.Name}  Email: {mgr.Email}");
                foreach (var stf in mgr.Staffs)
                {
                    Console.WriteLine($"  - Staff id: {stf.StaffId}  Name: {stf.Name}  Email: {stf.Email}");
                    foreach (var tsk in stf.Tasks)
                    {
                        Console.WriteLine($"    - Task id: {tsk.TaskItemId}  Title: {tsk.Title}  Discription: {tsk.Description}  Is Completed: {tsk.IsCompleted}");
                    }
                }
                Console.WriteLine();
            }
        }


        //5. Update Task
        public static int UpdateTask()
        {
            TaskItem t = FindTask();

            if(t != null)
            {
                t.IsCompleted = true;

                return db.SaveChanges();
            }
            else
            {
                return 0;
            }

        }

        //6. Delete Task
        public static int DeleteTask()
        {
            TaskItem t = FindTask();
            
            if(t != null)
            {
                db.taskItems.Remove(t);
                return db.SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        // Utility methods
        public static TaskItem FindTask()
        {
            Console.Write("Task Id: ");
            return db.taskItems.Find(Convert.ToInt32(Console.ReadLine()));
        }

        public static List<Manager> GetAllManagers()
        {
            return db.Managers.Include(s => s.Staffs).ThenInclude(st => st.Tasks).ToList();
        }

    }
}
