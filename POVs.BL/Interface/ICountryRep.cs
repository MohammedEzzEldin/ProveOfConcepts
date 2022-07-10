using POVs.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace POVs.BL.Interface
{
    public interface ICountryRep
    {
        Task<IEnumerable<Country>> GetAsync(Expression<Func<Country, bool>> filter = null);

    }
}
