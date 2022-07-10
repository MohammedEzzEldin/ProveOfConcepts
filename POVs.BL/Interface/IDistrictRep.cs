using POVs.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace POVs.BL.Interface
{
    public interface IDistrictRep
    {
        Task<IEnumerable<District>> GetAsync(Expression<Func<District, bool>> filter = null);
    }
}
