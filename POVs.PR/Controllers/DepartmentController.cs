﻿using Microsoft.AspNetCore.Mvc;
using POVs.BL.ModelView;
using POVs.BL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POVs.PR.Controllers
{
    public class DepartmentController : Controller
    {
        #region Explaination

        #region ViewData
        // View Data: => like var, ref type , need to cast 
        /* 
             * transfers data from Controller to View. 
             * ViewData is of Dictionary type.
             * ViewData["x"] => store as object
        */
        #endregion

        #region ViewBag
        // View Bag => like dynamic , did not need to cast (Controller to Action)
        /*
             * used to transfer temporary data (which is not included in the model) from the controller to the view.
             * ViewBag is of dynamic type.
             * ViewBag.y 
             * ViewBag is better that ViewData in the performance
         */
        #endregion

        #region TempData
        // Temp Data => need to cast 
        /*
             * TempData is used to transfer data from view to controller, controller to view, or 
             * from one action method to another action method of the same or a different controller.
             * TempData["z"] => store as object
         */
        #endregion

        #region diff between IEnumarable and IQuerable
        /// <summary>
        /// IEnumarable => filter after getting the data
        /// IQuerable => filter before getting the data
        /// </summary>
        #endregion

        #endregion

        #region Notes
        // @inject is the alternative for ViewModel to call more than one Model inside the view
        #endregion

        DepartmentRep department = new DepartmentRep();

        public async Task<IActionResult> Index()
        {
            //ViewData["x"] = "Hi I'm View Data";
            //ViewBag.y = "Hi I'm View Bag";
            //TempData["z"] = "Hi I'm Temp Data";
            //return RedirectToAction("Test", "Department");
            var data = await department.GetAsync();

            return View(data);
        }
        public async Task<IActionResult> Details(int id)
        {

            var data = await department.GetByIdAsync(id);

            return View(data);
        }
        public IActionResult Test()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DepartmentVM dep)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await department.CreateAsync(dep);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            //ModelState.Clear();
            return View(dep);
        }
        public async Task<IActionResult> Update(int id)
        {
            var data = await department.GetByIdAsync(id);

            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Update(DepartmentVM dep)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await department.UpdateAsync(dep);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            //ModelState.Clear();
            return View(dep);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var data = await department.GetByIdAsync(id);

            return View(data);
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await department.DeleteAsync(id);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            //ModelState.Clear();
            return RedirectToAction("Delete", new { id = id } );
        }
    }
}
