using POVs.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace POVs.BL.Interface
{
    public interface ICityRep
    {
        Task<IEnumerable<City>> GetAsync(Expression<Func<City, bool>> filter = null);
    }
}
