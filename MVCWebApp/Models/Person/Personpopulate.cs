using MVCWebApp.EFwk;
using MVCWebApp.Models.Person.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Models.Person
{
    public class Personpopulate:Iperson
    {
        private readonly personSeedDbContext _context;

        public Personpopulate(personSeedDbContext context)
        {
            _context = context;
        }

        public List<personproperties> GetAllPersons()
        {
            return _context.People.ToList();
        }

        public personproperties GetPerson(int id)
        {
            return _context.People.Find(id);
        }

        public List<personproperties> Search(string searchTerm, bool caseSensitive)
        {
            List<personproperties> searchList = new List<personproperties>();

            if (searchTerm != null)
            {
                if (caseSensitive)
                {
                    IEnumerable<personproperties> searchList2 = from Person in _context.People
                                                      where Person.Name.Contains(searchTerm) || Person.City.Contains(searchTerm)
                                                      select Person;

                    //cheat case sensitive
                    foreach (personproperties item in searchList2)
                    {
                        if (item.Name.Contains(searchTerm) || item.City.Contains(searchTerm))
                        {
                            searchList.Add(item);
                        }
                    }
                }
                else
                {
                    searchList = _context.People.Where(p => p.City.Contains(searchTerm) ||
                                                    p.Name.Contains(searchTerm)).ToList();
                }
            }

            return searchList;
        }

        public List<personproperties> Sort(PersonReorderVIewModel sortOptions, string sortType)
        {
            
            List<personproperties> sortedList = _context.People.ToList();

            if (sortType == "city")
            {
                sortedList = _context.People.OrderBy(p => p.City).ToList();
            }
            else if (sortType == "name")
            {
                sortedList = _context.People.OrderBy(p => p.Name).ToList();
            }

            if (sortOptions.ReverseAplhabeticalOrder == true)
            {
                sortedList.Reverse();
            }

            return sortedList;
        }

        public personproperties Add(CreatePersonViewModel createPersonViewModel)
        {
            personproperties person = new personproperties();
            person.Name = createPersonViewModel.Name;
            person.City = createPersonViewModel.City;
            person.PhoneNumber = createPersonViewModel.PhoneNumber;

            _context.People.Add(person);
            _context.SaveChanges();

            return person;
        }

        public bool Delete(int id)
        {
            if (id > 0)
            {
                var personToDelete = _context.People.Find(id);

                if (personToDelete != null)
                {
                    _context.People.Remove(personToDelete);
                    _context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

    }
}
