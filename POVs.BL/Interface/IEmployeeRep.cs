using POVs.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace POVs.BL.Interface
{
    public interface IEmployeeRep
    {
        Task<IEnumerable<Employee>> GetAsync(Expression<Func<Employee, bool>> filter = null);
        Task<Employee> GetByIdAsync(Expression<Func<Employee, bool>> filter = null);
        Task<IEnumerable<Employee>> SearchAsync(Expression<Func<Employee, bool>> filter);
        Task CreateAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(Employee employee);
    }
}
