using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCWebApp.Models.Person;
using MVCWebApp.Models.Person.ViewModel;


namespace MVCWebApp.Controllers
{
    public class AjaxController : Controller
    {
        private readonly Iperson _person;

        public AjaxController(Iperson personRepository)
        {
            _person = personRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeletePerson(int id)
        {
            bool status = _person.Delete(id);

            if (status)
                return Ok("Person with ID: " + id + " was deleted");
            else
                return Content("Person with ID: " + id + " not found! Person was not deleted!");
        }

        [HttpGet]
        public IActionResult GetPeople()
        {
            IEnumerable<personproperties> PersonList = _person.GetAllPersons();

            return PartialView("_partialPersonList", PersonList);
        }

        [HttpPost]
        public IActionResult GetPerson(int id)
        {
            personproperties person = _person.GetPerson(id);

            if (person != null)
            {
                List<personproperties> PersonList = new List<personproperties>();
                PersonList.Add(person);
                return PartialView("_partialPersonList", PersonList);
            }

            return Content("Person with ID: " + id + " not found! No Details to show!");
        }
    }
}
