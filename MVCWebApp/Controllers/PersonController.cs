using Microsoft.AspNetCore.Mvc;
using MVCWebApp.Models.Person;
using MVCWebApp.Models.Person.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Controllers
{
    public class PersonController : Controller
    {
        private readonly Iperson _person;
        public PersonController(Iperson _iperson)
        {
            _person = _iperson;
        }
        public IActionResult Index()
        {
            AllPersonViewModel allmodel = new AllPersonViewModel();
            allmodel.PersonList = _person.GetAllPersons();
            return View(allmodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreatePersonViewModel CreateViewModel)
        {
            if (ModelState.IsValid)
            {

                _person.Add(CreateViewModel);

                return RedirectToAction(nameof(Index));
            }

            AllPersonViewModel model = new AllPersonViewModel();
            model.PersonList = _person.GetAllPersons();

            return View(nameof(Index), model);
        }
        [HttpGet]
        public IActionResult Search(PersonSearchViewModel searchOptions)
        {

            AllPersonViewModel model = new AllPersonViewModel();
            model.PersonList = _person.Search(searchOptions.SearchTerm, searchOptions.CaseSensitive);

            return View(nameof(Index), model);
        }

        [HttpGet]
        public IActionResult SortByCity(PersonReorderVIewModel pessortOptions)
        {
            AllPersonViewModel model = new AllPersonViewModel();

            model.PersonList = _person.Sort(pessortOptions, "city");

            return View(nameof(Index), model);
        }

        [HttpGet]
        public IActionResult SortByName(PersonReorderVIewModel sortOptions)
        {
            AllPersonViewModel model = new AllPersonViewModel();

            model.PersonList = model.PersonList = _person.Sort(sortOptions, "name");

            return View(nameof(Index), model);
        }
    }
}
