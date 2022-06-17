using POVs.BL.Interface;
using POVs.BL.ModelView;
using POVs.DAL.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POVs.BL.Repository
{
    public class DepartmentRep : IDepartmentRep
    {
        ApplicationContext db = new ApplicationContext();
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
    }
}
