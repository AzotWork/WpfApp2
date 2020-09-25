
using System.Data.Entity;

namespace WpfApp2
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext():base("DefaultConnection")
        { 
        }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
