using DemoProject.Data;
using DemoProject.DataRepository;
using DemoProject.Interface;
using DemoProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DemoProject.Controllers
{
    public class EmployeesController : Controller
    {
        //private readonly DemoDBContext _dbContext;
        private readonly IDbEmployee _dbEmployee;
        //private readonly IDbEmployee _dbEmployee;

        //public EmployeesController(DemoDBContext demoDBContext, IDbEmployee dbEmployee)
        //{
        //    _dbContext = demoDBContext;
        //    _dbEmployee = dbEmployee;
        //}
        public EmployeesController(IDbEmployee dbEmployee)
        {

            _dbEmployee = dbEmployee;
        }

        public bool TestMEthod()
        {
            return true;
        }
        public bool CheckEmailExist(string EmailId)
        {
            if (EmailId == "")
            {
                return false;
            }
            var Emplist = GetEmployeeList();
            if (Emplist != null)
            {
                if (Emplist.Count > 0)
                {
                    var isEmailExist = Emplist.Find(a => a.Email == EmailId);
                    if (isEmailExist != null)
                    {
                        ViewBag.IsEmailExist = "Email is Already Exist";
                        return true;
                    }
                }
            }
            return false;
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddEmployee employee = new AddEmployee();
            ViewBag.IsEmailExist = null;
            employee.Cities = GetCityList();

            return View(employee);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddEmployee addEmployee)
        {
            if (!ModelState.IsValid)
            {
                addEmployee.Cities = GetCityList();
                return View(addEmployee);
            }
            //Check Email 
            var Emplist = GetEmployeeList();
            if (Emplist.Count > 0)
            {
                var isEmailExistDB = Emplist.Find(a => a.Email == addEmployee.Email);
                if (isEmailExistDB != null)
                {
                    ViewBag.IsEmailExist = "Email is Already Exist";
                    return View("Add", addEmployee);
                }
            }

            if (CheckEmailExist(addEmployee.Email))
            {
                return View("Add", addEmployee);
            }
            //AddEmployee employee = new AddEmployee();
            if (!string.IsNullOrEmpty(addEmployee.City))
            {
                List<CityEmp>? citryLists = new List<CityEmp>();
                citryLists = GetCityList();
                var citydata = citryLists.Where(a => a.CityName == addEmployee.City).FirstOrDefault();
                addEmployee.SelectedCityId = Convert.ToInt16(citydata.CityID);
            }
            _dbEmployee.AddEmployee(addEmployee);

            return RedirectToAction("DisplayEmpList");
        }
        [HttpGet]
        public IActionResult DisplayEmpList()
        {
            List<Employee> EmpList = GetEmployeeList();
            return View(EmpList);

        }
        [HttpGet]
        public IActionResult Details(Guid Id)
        {
            Employee employee = _dbEmployee.GetEmployeeById(Id);
            return View(employee);
        }
        [HttpGet]
        public IActionResult Delete(Guid Id)
        {

            if (Id != Guid.Empty)
                _dbEmployee.DeleteEmployeeById(Id);
            return RedirectToAction("DisplayEmpList");
        }
        [HttpGet]
        public IActionResult Edit(Guid Id)
        {
            Employee emp = _dbEmployee.GetEmployeeById(Id);
            List<CityEmp>? citryLists = new List<CityEmp>();
            citryLists = GetCityList();
            AddEmployee addemp = new AddEmployee()
            {
                Id = emp.Id,
                Name = emp.Name,
                //City = 
                Gender = Convert.ToString(emp.Gender),
                IsParmanent = Convert.ToBoolean(emp.IsParmanent),
                Email = emp.Email,
                Cities = citryLists
            };

            return View(addemp);
        }
        [HttpPost]
        public IActionResult Edit(AddEmployee emp)
        {
            Employee employee = _dbEmployee.GetEmployeeById(emp.Id);

            AddEmployee addemployee = new AddEmployee();
            if (!string.IsNullOrEmpty(emp.City))
            {
                List<CityEmp>? citryLists = new List<CityEmp>();
                citryLists = GetCityList();
                var citydata = citryLists.Where(a => a.CityName == emp.City).FirstOrDefault();
                emp.SelectedCityId = Convert.ToInt16(citydata.CityID);
                emp.Cities = citryLists;
            }
            if (employee.Email.ToLower() != emp.Email.ToLower())
            {
                if (CheckEmailExist(emp.Email))
                {
                    return View("Edit", emp);
                }
            }
            _dbEmployee.UpdateEmployeeById(emp);

            return RedirectToAction("DisplayEmpList");
        }
        [HttpGet]
        public List<CityEmp> GetCityList()
        {

            List<CityEmp> citryLists = _dbEmployee.GetAllCityList();

            return citryLists;
        }
        [HttpGet]
        public List<Employee> GetEmployeeList()
        {
            List<Employee> EmpLists = _dbEmployee.GetAllEmployee();
            return EmpLists;
        }
    }
}
