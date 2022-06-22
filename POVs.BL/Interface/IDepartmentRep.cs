using POVs.BL.ModelView;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POVs.BL.Interface
{
    public interface IDepartmentRep
    {
        Task<IEnumerable<DepartmentVM>> GetAsync();
        Task<DepartmentVM> GetByIdAsync(int id);
        Task CreateAsync(DepartmentVM department);
    }
}
