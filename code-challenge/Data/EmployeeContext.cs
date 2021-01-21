using challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace challenge.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }

        /// <summary>
        /// Employee database set.
        /// </summary>
        public DbSet<Employee> Employees { get; set; }
    }
}
