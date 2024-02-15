using DemoProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Data
{
    public class DemoDBContext : DbContext
    {
        public DemoDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
       // public DbSet<City> City { get; set; }
        public DbSet<CityEmp> CityEmp { get; set; }
    }
}
