using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Task.Models;

namespace MVC_Task.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbcontext emp;
        public EmployeeController()
        {
            emp = new AppDbcontext();
        }
        public IActionResult Index()
        {
            var result = emp.Employees
                           .Include(e => e.Department)
                           .ToList();
            return View(result);
        }
        public IActionResult Create()
        {
            ViewBag.ErrorMessage = null;
            ViewBag.Departments = emp.Departments.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult SaveEmployee(Employee empl)
        {
            bool hasError = false;

            if (string.IsNullOrEmpty(empl.Name))
            {
                ViewBag.NameError = "Name is required.";
                hasError = true;
            }

            if (empl.Age <= 0)
            {
                ViewBag.AgeError = "Age must be greater than 0.";
                hasError = true;
            }

            if (string.IsNullOrEmpty(empl.Position))
            {
                ViewBag.PositionError = "Position is required.";
                hasError = true;
            }

            if (empl.Salary <= 0)
            {
                ViewBag.SalaryError = "Salary must be greater than 0.";
                hasError = true;
            }

            if (empl.DepartmentId <= 0)
            {
                ViewBag.DepartmentError = "Please select a department.";
                hasError = true;
            }

            if (hasError)
            {
                ViewBag.Departments = emp.Departments.ToList();   
                return View("Create", empl);
            }

            emp.Employees.Add(empl);
            emp.SaveChanges();

            return RedirectToAction("Index", "Employee");
        }



        public IActionResult Edit(int id)
        {
            var employee = emp.Employees.Where(a => a.Id == id).FirstOrDefault();
            if (employee == null)
            {
                ViewBag.ErrorMessage = "Employee not found";
                return View();
            }
            ViewBag.Departments = emp.Departments.ToList();
            return View(employee);
        }

        [HttpPost]
        public IActionResult UpdateEmployee(Employee empl)
        {
            bool hasError = false;

            if (string.IsNullOrEmpty(empl.Name))
            {
                ViewBag.NameError = "Name is required.";
                hasError = true;
            }

            if (empl.Age <= 0)
            {
                ViewBag.AgeError = "Age must be greater than 0.";
                hasError = true;
            }

            if (string.IsNullOrEmpty(empl.Position))
            {
                ViewBag.PositionError = "Position is required.";
                hasError = true;
            }

            if (empl.Salary <= 0)
            {
                ViewBag.SalaryError = "Salary must be greater than 0.";
                hasError = true;
            }

            if (empl.DepartmentId <= 0)
            {
                ViewBag.DepartmentError = "Please select a department.";
                hasError = true;
            }

            if (hasError)
            {
                ViewBag.Departments = emp.Departments.ToList();  
                return View("Edit", empl);
            }

            var employee = emp.Employees.FirstOrDefault(a => a.Id == empl.Id);
            if (employee == null)
            {
                ViewBag.ErrorMessage = "Employee not found";
                ViewBag.Departments = emp.Departments.ToList();   
            }

            employee.Name = empl.Name;
            employee.Age = empl.Age;
            employee.Salary = empl.Salary;
            employee.Position = empl.Position;
            employee.DepartmentId = empl.DepartmentId;

            emp.SaveChanges();

            return RedirectToAction("Index", "Employee");
        }
        public IActionResult GetEmployeeById(int id)
        {
            var employee = emp.Employees.Where(a => a.Id == id).FirstOrDefault();
            if (employee == null)
            {
                ViewBag.ErrorMessage = "Employee not found";
                return View();
            }
            ViewBag.Departments = emp.Departments.ToList();
            return View(employee);
        }
        public IActionResult Delete(int id)
        {
            var employee = emp.Employees.FirstOrDefault(a => a.Id == id);

            if (employee == null)
            {
                ViewBag.ErrorMessage = "Employee not found";
                return View("GetEmployeeById");
            }

            emp.Employees.Remove(employee);
            emp.SaveChanges();

            return RedirectToAction("Index", "Employee");
        }


    }
}




