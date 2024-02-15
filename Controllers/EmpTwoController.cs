using DemoProject.DataRepository;
using DemoProject.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Controllers
{
    public class EmpTwoController : Controller
    {
        private readonly IDbEmployee _dbEmployeeRepo;

        public EmpTwoController(IDbEmployee dbEmployeeRepo)
        {
            _dbEmployeeRepo = dbEmployeeRepo;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
