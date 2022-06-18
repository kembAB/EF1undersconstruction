using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCWebApp.Models.Person.ViewModel;
namespace MVCWebApp.Models.Person
{
    public interface Iperson
    {
        public List<personproperties> GetAllPersons();
        public personproperties GetPerson(int id);
        public personproperties Add(CreatePersonViewModel createPersonViewModel);
        public bool Delete(int id);
        public List<personproperties> Search(string searchTerm, bool caseSensitive);
        public List<personproperties> Sort(PersonReorderVIewModel sortOptions, string sortType);
    }
}
