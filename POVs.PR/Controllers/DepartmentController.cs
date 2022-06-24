using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using POVs.BL.Interface;
using POVs.BL.ModelView;
using POVs.DAL.Entity;
using System;
using System.Collections.Generic;
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

       //private readonly DepartmentRep department;// tightly coupled
        private readonly IDepartmentRep department;// loosly coupled
        private readonly IMapper mapper;

        public DepartmentController(IDepartmentRep department, IMapper mapper)
        {
            this.department = department;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            //ViewData["x"] = "Hi I'm View Data";
            //ViewBag.y = "Hi I'm View Bag";
            //TempData["z"] = "Hi I'm Temp Data";
            //return RedirectToAction("Test", "Department");
            var data = await department.GetAsync();
            var result = mapper.Map<IEnumerable<DepartmentVM>>(data);
            return View(result);
        }
        public async Task<IActionResult> Details(int id)
        {
            var data = await department.GetByIdAsync(id);
            var result = mapper.Map<DepartmentVM>(data);
            return View(result);
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
                    var data = mapper.Map<Department>(dep);
                    await department.CreateAsync(data);
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
            var result = mapper.Map<DepartmentVM>(data);

            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Update(DepartmentVM dep)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Department>(dep);
                    await department.UpdateAsync(data);
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
            var result = mapper.Map<DepartmentVM>(data);

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
