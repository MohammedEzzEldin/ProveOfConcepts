using Microsoft.EntityFrameworkCore;
using POVs.BL.Interface;
using POVs.BL.ModelView;
using POVs.DAL.Database;
using POVs.DAL.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POVs.BL.Repository
{
    public class DepartmentRep : IDepartmentRep
    {
        private readonly ApplicationContext db;
        public DepartmentRep(ApplicationContext db)
        {
            this.db = db;
        }
        public async Task CreateAsync(Department department)
        {
           await db.Department.AddAsync(department);
           await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int departmentId)
        {
            var data = await db.Department.FindAsync(departmentId);
            db.Remove(data);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Department>> GetAsync()
        {
            var data = db.Department.ToList();

            return await Task.Run(() =>  data);
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            var data = db.Department.Where(x => x.Id == id).FirstOrDefault();

            return await Task.Run(() => data);
        }

        public async Task UpdateAsync(Department department)
        {
            db.Entry(department).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
