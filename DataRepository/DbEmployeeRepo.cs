using DemoProject.Data;
using DemoProject.Interface;
using DemoProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.DataRepository
{
    public class DbEmployeeRepo : IDbEmployee
    {
        private readonly DemoDBContext _demoDBContext;

        public DbEmployeeRepo(DemoDBContext demoDBContext)
        {
            _demoDBContext = demoDBContext;
        }
        public Employee SetEmployeeData(Employee employee)
        {
            _demoDBContext.Employees.Add(employee);
           
            return employee;
        }
        public List<Employee> GetAllEmployee()
        {
            List<Employee> EmpLists = new List<Employee>();
            EmpLists = _demoDBContext.Employees.Select(e => new Employee()
            {
                Id = e.Id,
                City = e.City,
                Name = e.Name,
                Email = e.Email,
                IsParmanent = e.IsParmanent,
                Gender = Convert.ToString(e.Gender),

            }).ToList();
            
            return EmpLists;
        }
        public List<CityEmp> GetAllCityList()
        {
            List<CityEmp> citryLists = new List<CityEmp>();
            citryLists = _demoDBContext.CityEmp.Select(s => new CityEmp()
            {
                Id = s.Id,
                CityID = s.CityID,
                CityName = s.CityName,
            }).ToList();
          
            return citryLists;
        }
        public Employee GetEmployeeById(Guid id)
        {
            Employee emp = _demoDBContext.Employees.Where(a => a.Id == id).FirstOrDefault();
            return emp;
        }
        public Employee UpdateEmployeeById(AddEmployee emp)
        {
            Employee employee = _demoDBContext.Employees.Where(a => a.Id == emp.Id).FirstOrDefault();
            if (emp != null)
            {
                employee.Name = string.IsNullOrEmpty(emp.Name) ? employee.Name : emp.Name;
                employee.Gender = string.IsNullOrEmpty(emp.Gender) ? employee.Gender : emp.Gender;
                if (string.IsNullOrEmpty(Convert.ToString(emp.IsParmanent)))
                {
                    employee.IsParmanent = employee.IsParmanent;
                }
                else
                {
                    employee.IsParmanent = Convert.ToString(emp.IsParmanent);
                }
                employee.City = string.IsNullOrEmpty(emp.SelectedCityId.ToString()) ? employee.City : emp.SelectedCityId.ToString();
                employee.Email = string.IsNullOrEmpty(emp.Email) ? employee.Email : emp.Email;
            }

            _demoDBContext.SaveChanges();
            return employee;
        }
        public bool DeleteEmployeeById(Guid id)
        {
            Employee employee = _demoDBContext.Employees.Where(a => a.Id == id).FirstOrDefault();
            _demoDBContext.Employees.Remove(employee);
            _demoDBContext.SaveChanges();
            return false;
        }
        public Employee AddEmployee(AddEmployee emp)
        {
            Employee employee = _demoDBContext.Employees.Where(a => a.Id == emp.Id).FirstOrDefault();
            if (emp == null)
            {
                return new Employee();
            }
            Employee addemployeeObj = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = emp.Name,
                City = emp.SelectedCityId.ToString(),
                Gender = Convert.ToString(emp.Gender),
                IsParmanent = Convert.ToString(emp.IsParmanent),
                Email = emp.Email,

            };
            _demoDBContext.Employees.AddAsync(addemployeeObj);
            _demoDBContext.SaveChangesAsync();
            return addemployeeObj;
        }
        public bool testmethod()
        {
            return false;
        }
    }
}
