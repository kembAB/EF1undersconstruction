using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult FeverCheck(string patientTemp)
        {
            if (int.TryParse(patientTemp, out int temp))
            {

                ViewBag.Message = Models.Doctor.CheckFeverInCentigrade.FeverCheck(temp);
            }
            else
            {

                ViewBag.Message = "Enter the temprature in integer value";
            }
            return View("index");
        }
    }
}
