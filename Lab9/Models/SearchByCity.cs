using System.ComponentModel.DataAnnotations;

namespace Lab9.Models
{
    public class SearchByCity
    {
        [Required(ErrorMessage ="City name is empty!")]
        [Display(Name ="CityName")]
        [StringLength(30,MinimumLength =2, ErrorMessage = "Invalid input") ]
        public string CityName { get; set; }
    }
}
