using POVs.BL.Interface;
using POVs.DAL.Database;
using POVs.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace POVs.BL.Repository
{
    public class CountryRep : ICountryRep
    {
        private readonly ApplicationContext db;

        public CountryRep(ApplicationContext db)
        {
            this.db = db;
        }


        public async Task<IEnumerable<Country>> GetAsync(Expression<Func<Country, bool>> filter = null)
        {
            if (filter != null)
                return await Task.Run(() => db.Countries.Where(filter).ToList());
            else
                return await Task.Run(() => db.Countries.ToList());
        }
    }
}
