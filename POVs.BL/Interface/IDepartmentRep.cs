using POVs.DAL.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POVs.BL.Interface
{
    public interface IDepartmentRep
    {
        Task<IEnumerable<Department>> GetAsync();
        Task<Department> GetByIdAsync(int id);
        Task CreateAsync(Department department);
        Task UpdateAsync(Department department);
        Task DeleteAsync(int departmentId);
    }
}
