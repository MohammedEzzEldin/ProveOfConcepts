using Microsoft.EntityFrameworkCore;
using POVs.DAL.Entity;

namespace POVs.DAL.Database
{
    public class ApplicationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .; Database = ProveOfConceptsDb; Integrated Security = true");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Department> Department { get; set; }
    }
}


