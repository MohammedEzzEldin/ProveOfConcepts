using Microsoft.EntityFrameworkCore;
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
    public class CityRep : ICityRep
    {
        private readonly ApplicationContext db;

        public CityRep(ApplicationContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<City>> GetAsync(Expression<Func<City, bool>> filter = null)
        {
            if (filter != null)
                return await Task.Run(() => db.Cities.Where(filter).Include("Country").ToList());
            else
                return await Task.Run(() => db.Cities.Include("Country").ToList());
        }
    }
}
