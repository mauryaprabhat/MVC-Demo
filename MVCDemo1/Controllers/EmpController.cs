using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo1.Controllers
{
    public class EmpController : Controller
    {
        // GET: Emp
        public ActionResult Index()
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            List<Employee> employees = employeeBusinessLayer.Employees.ToList();
            return View(employees);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(/*FormCollection formCollection*/ string name,string gender, string city)
        {
            //foreach( string key in formCollection.AllKeys)
            //{
            //    Response.Write("Key = " + key + " ");
            //    Response.Write(formCollection[key]);
            //    Response.Write("<br/>");
            //}

            //Employee employee = new Employee();
            //employee.Name = formCollection["Name"];
            //employee.Gender = formCollection["Gender"];
            //employee.City = formCollection["City"];
            //EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            //employeeBusinessLayer.AddEmployee(employee);
            //return RedirectToAction("Index");

            Employee employee = new Employee();
            employee.Name = name;
            employee.City = city;
            employee.Gender = gender;
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            employeeBusinessLayer.AddEmployee(employee);
            return RedirectToAction("Index");
        }
    }
}