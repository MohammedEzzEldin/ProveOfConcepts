using Microsoft.EntityFrameworkCore;
using POVs.DAL.Entity;

namespace POVs.DAL.Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> option) :base(option)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server = .; Database = ProveOfConceptsDb; Integrated Security = true");
        //    base.OnConfiguring(optionsBuilder);
        //}
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
    }
}


