using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Job_task.Models;
using Job_task.Services;

namespace Job_task.Controllers
{
    public class DepartmentsController : Controller
    {
       
        private DepartmentServices departmentServices = new DepartmentServices();

        // GET: Departments
        public ActionResult Index()
        {
            if (Request.IsAjaxRequest())
            {
                var data = departmentServices.GetAllDepartmentsWithUser();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            return View(departmentServices.GetAllDepartmentsWithUser());
        }

       

        // GET: Departments/Details/5
        public ActionResult Details(int id)
        {
           
            Department department = departmentServices.FindDepartmentById(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,Description,Active")] Department department)
        {
            if (ModelState.IsValid)
            {
                departmentServices.CreateDepartment(department);
                return RedirectToAction("Index");
            }

            return View(department);
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(int id)
        {
            Department department = departmentServices.FindDepartmentById(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,Description,Active")] Department department)
        {
            if (ModelState.IsValid)
            {
                departmentServices.UpdateDepartment(department);
                return RedirectToAction("Index");
            }
            return View(department);
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(int id)
        {
            Department department = departmentServices.FindDepartmentById(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            departmentServices.DeleteDepartment(id);
            return RedirectToAction("Index");
        }

       
    }
}
