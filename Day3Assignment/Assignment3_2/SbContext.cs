using Microsoft.EntityFrameworkCore;

namespace Assignment3_2
{
    class SbContext : DbContext
    {
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<TaskItem> taskItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database = TaskManagement;Trusted_Connection=True;");
        }
    } 
}
