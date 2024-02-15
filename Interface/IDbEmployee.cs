using DemoProject.Models;

namespace DemoProject.Interface
{
    public interface IDbEmployee
    {
        Employee SetEmployeeData(Employee employee);
        List<Employee> GetAllEmployee();
        List<CityEmp> GetAllCityList();
        Employee GetEmployeeById(Guid id);
        Employee UpdateEmployeeById(AddEmployee emp);
        bool DeleteEmployeeById(Guid id);
        Employee AddEmployee(AddEmployee emp);
        bool testmethod();
    }
}
