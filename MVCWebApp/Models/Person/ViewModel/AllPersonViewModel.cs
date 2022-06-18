using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Models.Person.ViewModel
{
    public class AllPersonViewModel
    {
        public IEnumerable<personproperties> PersonList { get; set; }

        public CreatePersonViewModel CreateViewModel { get; set; }

        public string SearchTerm { get; set; }

        public PersonSearchViewModel SearchOptions { get; set; }

        public PersonReorderVIewModel SortOptions { get; set; }
    }
}
