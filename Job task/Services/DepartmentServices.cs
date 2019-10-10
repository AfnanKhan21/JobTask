using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Job_task.Models;
using Job_task.ViewModel;

namespace Job_task.Services
{
    public class DepartmentServices
    {
        private Job_task_DatabaseEntities db = new Job_task_DatabaseEntities();


        public Department FindDepartmentById(int id)
        {
            
            Department department = db.Departments.Find(id);
            
             return (department);
           
        }

        public void CreateDepartment(Department department)
        {

            db.Departments.Add(department);
            db.SaveChanges();
        }

        public void UpdateDepartment(Department department)
        {
            db.Entry(department).State = EntityState.Modified;
            db.SaveChanges();
        }


        public List<Department> GetDepartments()
        {
            return db.Departments.ToList();
        }

        public List<DepartmentViewModel> GetAllDepartmentsWithUser()
        {
          
            var departments =db.Departments.ToList();

            var departmentViewModel = new List<DepartmentViewModel>();

            foreach (var department in departments)
            {
                var viewModel = TransformToViewModel(department);

                departmentViewModel.Add(viewModel);
            }

            return departmentViewModel;
        }
        private DepartmentViewModel TransformToViewModel(Department model)
        {
            return new DepartmentViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Address = model.Address,
                Active = model.Active,
                Description = model.Description,
                NoOfUsers = NumberOfUserInDepartment(model.Id)
            };
        }

        private int NumberOfUserInDepartment(int id)
        {
            return db.Users.ToList().FindAll(x => id == x.DepartmentId).Count;
        }

        public void DeleteDepartment(int id)
        {
            Department department = FindDepartmentById(id);
            db.Departments.Remove(department);
            db.SaveChanges();
        }
    }
}