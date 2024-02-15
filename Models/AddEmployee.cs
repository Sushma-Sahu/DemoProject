using System.ComponentModel.DataAnnotations;

namespace DemoProject.Models
{
    public class AddEmployee
    {
        [Required(ErrorMessage = "Name is required")]
        //[Range(6,30)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Select Employee is Parmanent or not")]
        public bool IsParmanent { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        public List<CityEmp> Cities { get; set; }
        public int SelectedCityId { get; set; }
        public Guid Id { get; set; }
    }
    //public class CitryList
    //{
    //    public Guid id { get; set; }
    //    public long CityID { get; set; }
    //    public string CityName { get; set; }
    //}
    public class CityViewModel
    {
        public int SelectedCityId { get; set; }
        public List<CityEmp> Cities { get; set; }
    }
}
