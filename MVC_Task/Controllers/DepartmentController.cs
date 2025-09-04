using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Task.Models;
using System;

namespace MVC_Task.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly AppDbcontext dep;

        public DepartmentController()
        {
        dep= new AppDbcontext();
        }
        public IActionResult Index()
        { var result= dep.Departments.ToList();
           
            return View(result);
        }
        public IActionResult Create()
        {
            ViewBag.ErrorMessage = null;
            return View();
        }

        public IActionResult SaveDepartment(Department depa)
        {
            if (string.IsNullOrEmpty(depa.Name))
            {
                ViewBag.ErrorMessage = "Department name is required.";
                return View("Create", dep);
            }

            var department = new Department { Name = depa.Name };
            dep.Departments.Add(department);
            dep.SaveChanges();

            return RedirectToAction("Index", "Department");
        }
        public IActionResult Edit(int id)
        {
            var department = dep.Departments.FirstOrDefault(d => d.Id == id);
            if (department == null)
            {
                ViewBag.ErrorMessage = "Department not found.";
                return View();
            }
            return View(department);
        }

        [HttpPost]
        public IActionResult UpdateDepartment(Department depa)
        {
            if (string.IsNullOrEmpty(depa.Name))
            {
                ViewBag.ErrorMessage = "Department name is required.";
                return View("Edit", depa);
            }

            var department = dep.Departments.FirstOrDefault(d => d.Id == depa.Id);
            if (department == null)
            {
                ViewBag.ErrorMessage = "Department not found.";
                return View("Edit", depa);
            }

            department.Name = depa.Name;
            dep.SaveChanges();

            return RedirectToAction("Index", "Department");
        }
        public IActionResult GetDepartmentById(int id)
        {
            var department = dep.Departments.FirstOrDefault(d => d.Id == id);
            if (department == null)
            {
                ViewBag.ErrorMessage = "Department not found.";
                return View();
            }
            return View(department);
        }

        public IActionResult Delete(int id)
        {
            var department = dep.Departments.FirstOrDefault(d => d.Id == id);

            if (department == null)
            {
                ViewBag.ErrorMessage = "Department not found";
                return View("GetDepartmentById");
            }

            dep.Departments.Remove(department);
            dep.SaveChanges();

            return RedirectToAction("Index", "Department");
        }
    }
}

