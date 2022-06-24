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
        public async Task CreateAsync(DepartmentVM department)
        {
            Department _department = new Department()
            {
                Name = department.Name,
                Code = department.Code
            };
           await db.Department.AddAsync(_department);
           await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int departmentId)
        {
            var data = await db.Department.FindAsync(departmentId);
            db.Remove(data);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<DepartmentVM>> GetAsync()
        {
            var data = db.Department.Select(x => new DepartmentVM()
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code
            }).ToList();

            return await Task.Run(() =>  data);
        }

        public async Task<DepartmentVM> GetByIdAsync(int id)
        {
            var data = db.Department.Where(x => x.Id == id).Select(x => new DepartmentVM()
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code
            }).FirstOrDefault();

            return await Task.Run(() => data);
        }

        public async Task UpdateAsync(DepartmentVM department)
        {
            var data = await db.Department.FindAsync(department.Id);
            data.Name = department.Name;
            data.Code = department.Code;
            
            await db.SaveChangesAsync();
        }
    }
}
