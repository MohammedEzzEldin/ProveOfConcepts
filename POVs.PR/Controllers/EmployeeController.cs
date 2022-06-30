using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using POVs.BL.Interface;
using POVs.BL.Models;
using POVs.BL.ModelView;
using POVs.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POVs.PR.Controllers
{
    public class EmployeeController : Controller
    {
        #region Prop
        private readonly IEmployeeRep employee;
        private readonly IMapper mapper;
        private readonly IDepartmentRep department;
        #endregion

        #region Ctor
        public EmployeeController(IEmployeeRep employee, IMapper mapper,IDepartmentRep department)
        {
            this.employee = employee;
            this.mapper = mapper;
            this.department = department;
        }
        #endregion

        #region Actions
        public async Task<IActionResult> Index()
        {
            var data = await employee.GetAsync(emp => emp.IsActive == true && emp.IsDeleted == false);
            var result = mapper.Map<IEnumerable<EmployeeVM>>(data);
            return View(result);
        }
        public async Task<IActionResult> Details(int id)
        {
            var data = await employee.GetByIdAsync(emp => emp.Id == id && emp.IsActive == true && emp.IsDeleted == false);
            var result = mapper.Map<EmployeeVM>(data);
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeVM emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Employee>(emp);
                    await employee.CreateAsync(data);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            //ModelState.Clear();
            return View(emp);
        }
        public async Task<IActionResult> Update(int id)
        {
            var data = await employee.GetByIdAsync(emp => emp.Id == id && emp.IsDeleted == false);
            var result = mapper.Map<EmployeeVM>(data);

            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Update(EmployeeVM emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Employee>(emp);
                    await employee.UpdateAsync(data);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            //ModelState.Clear();
            return View(emp);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var data = await employee.GetByIdAsync(emp => emp.Id == id);
            var result = mapper.Map<EmployeeVM>(data);

            return View(result);
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await employee.DeleteAsync(id);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            //ModelState.Clear();
            return RedirectToAction("Delete", new { id = id });
        }
    }
    #endregion

    #region Ajax Call

    #endregion
}
