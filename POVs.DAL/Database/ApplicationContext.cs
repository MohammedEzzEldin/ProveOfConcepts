using Microsoft.EntityFrameworkCore;
using POVs.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace POVs.DAL.Database
{
    public class ApplicationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer()
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Department> Department { get; set; }
    }
}


