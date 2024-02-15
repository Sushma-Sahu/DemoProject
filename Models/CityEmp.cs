using System.ComponentModel.DataAnnotations;

namespace DemoProject.Models
{
    public class CityEmp
    {
        public int Id { get; set; }
        public long CityID { get; set; }
        public string? CityName { get; set; }
    }
}
