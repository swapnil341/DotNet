
using Assignment4a.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment4a.Models
{
    public class SbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=Assignment4Db;Trusted_Connection = True");
        }
    }
}
