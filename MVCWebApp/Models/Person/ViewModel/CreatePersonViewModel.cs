using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Models.Person.ViewModel
{
    public class CreatePersonViewModel
    {
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string City { get; set; }

        [Required]
        [RegularExpression(@"[\d]+\-?[\d]+",
            ErrorMessage = "Please enter a valid phone number!")]
        [StringLength(15, MinimumLength = 7)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public CreatePersonViewModel() { }

        public CreatePersonViewModel(string name, string city, string pNumber)
        {
            Name = name;
            City = city;
            PhoneNumber = pNumber;
        }
    }
}
