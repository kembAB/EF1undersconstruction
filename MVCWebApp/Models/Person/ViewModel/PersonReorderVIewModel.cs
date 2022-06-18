using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Models.Person.ViewModel
{
    public class PersonReorderVIewModel
    {
        [Display(Name = "Reverse ")]
        public bool ReverseAplhabeticalOrder { get; set; }
    }
}
