using DemoProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoProject.Controllers
{
    public class HomeController : Controller 
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

   
}
public class myCalss
{
    public int add(int a, int b)
    {
        return a + b;
    }
}
public class ggCalss
{
    public int multi(int a, int b)
    {
        return a + b;
    }
}
public class yourCalss : myCalss
{
    public int subtract(int a, int b)
    {
        var t = add(a, b);
        return a + b;
    }
    
}