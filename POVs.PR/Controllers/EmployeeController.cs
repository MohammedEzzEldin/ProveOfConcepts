﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using POVs.BL.Class;
using POVs.BL.Helper;
using POVs.BL.Interface;
using POVs.BL.ModelView;
using POVs.DAL.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace POVs.PR.Controllers
{
    public class EmployeeController : Controller
    {
        #region Prop
        private readonly IEmployeeRep employee;
        private readonly IMapper mapper;
        private readonly IDepartmentRep department;
        private readonly ICityRep city;
        private readonly IDistrictRep district;
        #endregion

        #region Ctor
        public EmployeeController(
            IEmployeeRep employee, IMapper mapper, IDepartmentRep department, ICityRep city, IDistrictRep district
        )
        {
            this.employee = employee;
            this.mapper = mapper;
            this.department = department;
            this.city = city;
            this.district = district;
        }
        #endregion

        #region Actions
        public async Task<IActionResult> Index(string searchVal = null)
        {
            dynamic data;

            if (searchVal != null)
            {
                data = await employee.SearchAsync(emp => emp.Name.Contains(searchVal) && emp.IsActive == true && emp.IsDeleted == false);
            }
            else
            {
                data = await employee.GetAsync(emp => emp.IsActive == true && emp.IsDeleted == false);
            }
            var result = mapper.Map<IEnumerable<EmployeeVM>>(data);

            return View(result);
        }
        public async Task<IActionResult> Details(int id)
        {
            var data = await employee.GetByIdAsync(emp => emp.Id == id && emp.IsActive == true && emp.IsDeleted == false);
            var result = mapper.Map<EmployeeVM>(data);
            ViewBag.DepartmentsList = await GetDepartmentsListAsync(data.DepartmentId);
            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.DepartmentsList = await GetDepartmentsListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeVM emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string ImageNameOrErrorMsg = string.Empty;
                    string CvNameOrErrorMsg = string.Empty;
                    bool IsVal;

                    ImageNameOrErrorMsg = FileUploader.UploadFile(Constant.ImgsFolder,emp.Image,out IsVal);
                   
                    if(IsVal)
                    {
                        emp.ImageName = ImageNameOrErrorMsg;
                    }
                    else
                    {
                        throw new Exception(ImageNameOrErrorMsg);
                    }

                    IsVal = false;

                    CvNameOrErrorMsg = FileUploader.UploadFile(Constant.DocsFolder,emp.Cv,out IsVal);

                    if (IsVal)
                    {
                        emp.CvName = CvNameOrErrorMsg;
                    }
                    else
                    {
                        throw new Exception(CvNameOrErrorMsg);
                    }

                    var data = mapper.Map<Employee>(emp);
                    await employee.CreateAsync(data);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.DepartmentsList = await GetDepartmentsListAsync();
                TempData["Error"] = ex.Message;
            }
            //ModelState.Clear();
            return View(emp);
        }
        public async Task<IActionResult> Update(int id)
        {
            var data = await employee.GetByIdAsync(emp => emp.Id == id && emp.IsDeleted == false);
            var result = mapper.Map<EmployeeVM>(data);
            ViewBag.DepartmentsList = await GetDepartmentsListAsync(data.DepartmentId);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Update(EmployeeVM emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string ImageNameOrErrorMsg = string.Empty;
                    string CvNameOrErrorMsg = string.Empty;
                    bool IsVal;

                    ImageNameOrErrorMsg = FileUploader.UploadFile(Constant.ImgsFolder, emp.Image, out IsVal);

                    if (IsVal)
                    {
                        emp.ImageName = ImageNameOrErrorMsg;
                    }
                    else
                    {
                        throw new Exception(ImageNameOrErrorMsg);
                    }

                    IsVal = false;

                    CvNameOrErrorMsg = FileUploader.UploadFile(Constant.DocsFolder, emp.Cv, out IsVal);

                    if (IsVal)
                    {
                        emp.CvName = CvNameOrErrorMsg;
                    }
                    else
                    {
                        throw new Exception(CvNameOrErrorMsg);
                    }

                    var data = mapper.Map<Employee>(emp);
                    await employee.UpdateAsync(data);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                ViewBag.DepartmentsList = await GetDepartmentsListAsync(emp.DepartmentId);
            }
            //ModelState.Clear();
            return View(emp);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var data = await employee.GetByIdAsync(emp => emp.Id == id);
            var result = mapper.Map<EmployeeVM>(data);
            ViewBag.DepartmentsList = await GetDepartmentsListAsync(data.DepartmentId);

            return View(result);
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(EmployeeVM emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string SubPath = FileUploader.GetFullPath(Directory.GetCurrentDirectory(), Constant.WwwrootFilePath);
                    string ImagePath = FileUploader.GetFullPath(SubPath, Constant.ImgsFolder, emp.ImageName);
                    string CvPath = FileUploader.GetFullPath(SubPath, Constant.DocsFolder, emp.CvName);
                    FileUploader.RemoveFile(ImagePath);
                    FileUploader.RemoveFile(CvPath);
                    var result = mapper.Map<Employee>(emp);
                    await employee.DeleteAsync(result);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                //var data = await employee.GetByIdAsync(emp => emp.Id == id);
                ViewBag.DepartmentsList = await GetDepartmentsListAsync(emp.DepartmentId);
            }
            //ModelState.Clear();
            return RedirectToAction("Delete", new { id = emp.Id });
        }
        #endregion

        #region NoActionMethods
        [NonAction]
        private async Task<SelectList> GetDepartmentsListAsync()
        {
            return new SelectList(await department.GetAsync(), "Id", "Name");
        }
        [NonAction]
        private async Task<SelectList> GetDepartmentsListAsync(int DepartmentId)
        {
            return new SelectList(await department.GetAsync(), "Id", "Name", DepartmentId);
        }
        #endregion

        #region Ajax Call 
        // Get Cities Data based on Country ID
        [HttpPost]
        //[AllowAnonymous]
        public async Task<JsonResult> GetCitiesByCountryId(int CountryId)
        {
            var data = await city.GetAsync(c => c.CountryId == CountryId);
            var cities = mapper.Map<IEnumerable<CityVM>>(data);
            return Json(cities);
            //return Json(data);
        }
        // Get District Data based on City ID
        [HttpPost]
        //[AllowAnonymous]
        public async Task<JsonResult> GetDistrictByCityId(int CityId)
        {
            var data = await district.GetAsync(c => c.CityId == CityId);
            var districts = mapper.Map<IEnumerable<DistrictVM>>(data);
            return Json(districts);
            //return Json(data);
        }
        #endregion
    }

}
