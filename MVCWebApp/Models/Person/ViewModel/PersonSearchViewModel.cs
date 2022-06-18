using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Models.Person.ViewModel
{
    public class PersonSearchViewModel
    {
        [Display(Name = "Search Term")]
        public string SearchTerm { get; set; }

        [Display(Name = "Case Sensitive")]
        public bool CaseSensitive { get; set; }
    }
}
