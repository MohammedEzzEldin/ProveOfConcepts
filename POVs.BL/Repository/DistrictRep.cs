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
    public class DistrictRep : IDistrictRep
    {
        private readonly ApplicationContext db;

        public DistrictRep(ApplicationContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<District>> GetAsync(Expression<Func<District, bool>> filter = null)
        {
            if (filter != null)
                return await Task.Run(() => db.Districts.Where(filter).Include("City").ToList());
            else
                return await Task.Run(() => db.Districts.Include("City").ToList());
        }
    }
}
