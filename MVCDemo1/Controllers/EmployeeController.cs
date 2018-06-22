using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using MVCDemo1.Models;

namespace MVCDemo1.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        //public ActionResult Details(int id)
        //{
        //    using (EmployeeContext context = new EmployeeContext())
        //    {
        //        Employee employeeResult = context.Employees.FirstOrDefault( emp => emp.Id == id);
        //        return View(employeeResult);
        //    }                
        //}
        //public ActionResult Index(int deptid)
        //{
        //    using (EmployeeContext context = new EmployeeContext())
        //    {
        //        List<Employee> employeeResult = context.Employees.Where(emp => emp.DepartmentId == deptid).ToList();
        //        return View(employeeResult);
        //    }
        //}
        public ActionResult Index()
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            List<BusinessLayer.Employee> employees = employeeBusinessLayer.Employees.ToList();
            return View(employees);
        }
    }
}