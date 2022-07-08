﻿using Microsoft.EntityFrameworkCore;
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
    public class EmployeeRep : IEmployeeRep
    {
        private readonly ApplicationContext db;
        public EmployeeRep(ApplicationContext db)
        {
            this.db = db;
        }
        public async Task CreateAsync(Employee employee)
        {
           await db.Employees.AddAsync(employee);
           await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int employeeId)
        {
            var data = await db.Employees.FindAsync(employeeId);
            //db.Remove(data);
            data.IsDeleted = true;
            data.DeleteDate = DateTime.Now;
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAsync(Expression<Func<Employee, bool>> filter)
        {
            if(filter != null)
               return await Task.Run(() => db.Employees.Where(filter).Include("Department").ToList());
            else 
               return await Task.Run(() => db.Employees.Include("Department").ToList());
        }

        public async Task<Employee> GetByIdAsync(Expression<Func<Employee, bool>> filter)
        {
            var data = await Task.Run(() => db.Employees.Where(filter).Include("Department").FirstOrDefault());

            return data;
        }

        public async Task UpdateAsync(Employee employee)
        {
            employee.IsUpdated = true;
            employee.UpdateDate = DateTime.Now;
            db.Entry(employee).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
