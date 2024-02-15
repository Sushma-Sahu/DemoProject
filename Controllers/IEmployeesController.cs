using DemoProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Controllers
{
    public interface IEmployeesController
    {
        IActionResult Add();
        Task<IActionResult> Add(AddEmployee addEmployee);
        bool CheckEmailExist(string EmailId);
        IActionResult Delete(Guid Id);
        IActionResult Details(Guid Id);
        IActionResult DisplayEmpList();
        IActionResult Edit(AddEmployee emp);
        IActionResult Edit(Guid Id);
        List<CityEmp> GetCityList();
        List<Employee> GetEmployeeList();
        bool TestMEthod();
    }
}